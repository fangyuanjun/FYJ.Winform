using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace FYJ.Winform.Util
{
    /// <summary>
    /// 对 System.Security.Permissions.StrongNameIdentityPermission 的简化与修正。
    /// 只允许与待检查程序集相同强名称签名的程序才可以访问代码。
    /// 系统 StrongNameIdentityPermission 权限对于相同强名称程序集的反射调用会抛出异常。本类不会。
    /// </summary>
    public sealed class StrongNameCodeAccessPermission
    {

        private const string EXCEPTION_MESSAGE = "No Permission To Access The Code!";
        private static readonly string[] SYSTEM_PUBLIC_KEYS;    // 系统动态库的强名称公钥

        private StrongNameCodeAccessPermission()
        {
        }

        static StrongNameCodeAccessPermission()
        {
            SYSTEM_PUBLIC_KEYS = new string[2];
            SYSTEM_PUBLIC_KEYS[0] = "b77a5c561934e089";
            SYSTEM_PUBLIC_KEYS[1] = "b03f5f7f11d50a3a";
        }

        // 将字节转换成16进制字符
        private static string ToHex(byte[] data)
        {
            string result = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                result += Convert.ToString(data[i], 16).ToLower().PadLeft(2, '0');
            }
            return result;
        }

        // 检查是否是系统调用
        private static bool IsSystemCalling(string publicKeyToken)
        {
            for (int j = 0; j < SYSTEM_PUBLIC_KEYS.Length; j++)
            {
                if (publicKeyToken == SYSTEM_PUBLIC_KEYS[j])
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 对堆栈中所有的调用进行强名称代码访问检查。
        /// </summary>
        /// <remarks>本方法必须被需要进行强名称检查的代码段<B>直接调用</B>。</remarks>
        public static void Demand()
        {
            // 获得验证代码段所在的程序集的强名称公钥标识
         //   string callingAssemblyKey = ToHex(Assembly.GetCallingAssembly().GetName().GetPublicKeyToken());
            string callingAssemblyKey = ToHex(Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken());
            // 获得访问堆栈，跳过本方法以及需验证代码的直接调用堆栈
            StackTrace st = new StackTrace(2, false);

            // 遍历检查所有上级调用堆栈
            string stackAssemblyKey;
            for (int i = 2; i < st.FrameCount; i++)
            {
                // 获得调用方程序集的强名称公钥标识
                stackAssemblyKey = ToHex(st.GetFrame(i).GetMethod().DeclaringType
                    .Assembly.GetName().GetPublicKeyToken());

                // 如果是相同强名称签名的程序集，允许调用
                if (callingAssemblyKey == stackAssemblyKey)
                    continue;

                // 允许系统动态库的访问权限
                if (IsSystemCalling(stackAssemblyKey) == false)
                {
                    throw new System.Security.SecurityException(EXCEPTION_MESSAGE);
                }
            }
        }

        /// <summary>
        /// 对堆栈中的非系统直接调用者进行强名称代码访问检查。
        /// </summary>
        /// <remarks>
        /// 1. 本方法必须被需要进行强名称检查的代码段<B>直接调用</B>。
        /// 2. 本方法只检查第一级直接调用者（如果上级调用是系统函数，则继续向上递归，主要考虑到反射的问题）。
        /// 3. 系统的 System.Security.Permissions.StrongNameIdentityPermission 可以检查直接调用者，但如果是通过反射调用，则会报错。
        /// 4. 除非对安全要求极高，要求检查堆栈中的所有调用者，一般情况下极力推荐使用本方法，只检查直接调用方的权限即可。
        /// </remarks>
        public static void LinkDemand()
        {

            // 获得验证代码段所在的程序集的强名称公钥标识
            //string callingAssemblyKey = ToHex(Assembly.GetCallingAssembly().GetName().GetPublicKeyToken());
            string callingAssemblyKey = ToHex(Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken());
            // 获得访问堆栈，跳过本方法以及需验证代码的直接调用堆栈
            StackTrace st = new StackTrace(2, false);

            // 遍历检查所有上级调用堆栈
            string stackAssemblyKey;
            for (int i = 2; i < st.FrameCount; i++)
            {
                // 获得调用方程序集的强名称公钥标识
                stackAssemblyKey = ToHex(st.GetFrame(i).GetMethod().DeclaringType
                    .Assembly.GetName().GetPublicKeyToken());

                // 如果上级调用是系统函数，继续向上递归
                if (IsSystemCalling(stackAssemblyKey))
                    continue;

                // 判断非系统直接调用者的强名称签名
                if (callingAssemblyKey == stackAssemblyKey)
                {
                    return;
                }
                else
                {
                    throw new System.Security.SecurityException(EXCEPTION_MESSAGE + stackAssemblyKey);
                }
            }
        }
    }

}
