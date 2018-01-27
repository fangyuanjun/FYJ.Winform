using System;
using System.Collections.Generic;
using System.Text;

namespace FYJ.Winform.Util
{
    public class TaskbarManager
    {

        private TaskbarManager()
        {
        }

        // Best practice recommends defining a private object to lock on
        private static Object syncLock = new Object();
        // Internal implemenation of ITaskbarList4 interface
        private ITaskbarList4 taskbarList;

        internal ITaskbarList4 TaskbarList
        {
            get
            {
                if (taskbarList == null)
                {
                    // Create a new instance of ITaskbarList3
                    lock (syncLock)
                    {
                        if (taskbarList == null)
                        {
                            taskbarList = (ITaskbarList4)new CTaskbarList();
                            taskbarList.HrInit();
                        }
                    }
                }

                return taskbarList;
            }
        }



        private static volatile TaskbarManager instance;

        /// <summary>
        /// Represents an instance of the Windows Taskbar
        /// </summary>

        public static TaskbarManager Instance
        {
            get
            {
                ThrowIfNotSupport();

                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new TaskbarManager();
                    }
                }
                return instance;
            }
        }

        public static void ThrowIfNotSupport()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                throw new PlatformNotSupportedException("Only supported on Windows 7/Sever2008 R2 or newer.");
            }
        }

        public bool IsWin7OrSever2008R2
        {
            get
            {
                return Environment.OSVersion.Version.Major >= 6;
            }
        }
    }
}
