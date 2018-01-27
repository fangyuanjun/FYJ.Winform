using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace FYJ.Winform.Util
{
  public  class BitmapHelper
    {
        /// <summary>  
        /// 给定一个矩形（长方形 正方形）剪切的范围 传入一张图片的原始尺寸   
        /// 得到一个在该矩形范围内的最佳尺寸(原图的比例不会变)  
        /// add 2goo 2011-4-8  
        /// </summary>  
        /// <param name="specifySize">指定尺寸</param>  
        /// <param name="originalSize">原始尺寸</param>  
        /// <returns>返回（原图片等比例）最佳尺寸</returns>  
        private static Size ResizeSite(Size specifySize, Size originalSize)
        {
            Size finaSize = new Size();
            float specifyScale = (float)specifySize.Width / (float)specifySize.Height;
            float originalScale = (float)originalSize.Width / (float)originalSize.Height;
            if (specifySize.Width >= originalSize.Width)
            {
                finaSize.Height = specifySize.Height;
                finaSize.Width = (int)(finaSize.Height * originalScale);
                if (finaSize.Width > specifySize.Width)
                {
                    finaSize.Width = specifySize.Width;
                    finaSize.Height = (int)(finaSize.Width / originalScale);
                }
            }
            else
            {
                finaSize.Width = specifySize.Width;
                finaSize.Height = (int)(finaSize.Width / originalScale);
                if (finaSize.Height > specifySize.Height)
                {
                    finaSize.Height = specifySize.Height;
                    finaSize.Width = (int)(finaSize.Height * originalScale);
                }
            }
            return finaSize;
        }

        /// <summary>
        /// 缩小或放大图片
        /// </summary>

        public static Bitmap SmallOrBigPic(Bitmap oldPic,Size newSize)
        {
            Size finaSize = ResizeSite(oldPic.Size,newSize);

            if (newSize.Width > oldPic.Size.Width || newSize.Height > oldPic.Size.Height)
            {
                Bitmap resultImage = new Bitmap(newSize.Width, newSize.Height);
                Graphics g = Graphics.FromImage(resultImage);
                g.DrawImage(oldPic, new Rectangle(0, 0, newSize.Width, newSize.Height), 0, 0, oldPic.Width, oldPic.Height, GraphicsUnit.Pixel);
                return resultImage;
            }
            else
            return new System.Drawing.Bitmap(oldPic, finaSize.Width, finaSize.Height);
        }

        /// <summary>
        /// 参数 0-1   1表示不透明
        /// </summary>
        /// <param name="opacity"></param>
        public static Bitmap MakePngImage(Image srcImage, float opacity)
        {
            float[][] nArray ={ new float[] {1, 0, 0, 0, 0},
                                new float[] {0, 1, 0, 0, 0},
                                new float[] {0, 0, 1, 0, 0},
                                new float[] {0, 0, 0, opacity, 0},
                                new float[] {0, 0, 0, 0, 1}};
            ColorMatrix matrix = new ColorMatrix(nArray);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap resultImage = new Bitmap(srcImage.Width, srcImage.Height);
            Graphics g = Graphics.FromImage(resultImage);
            g.DrawImage(srcImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, attributes);

            return resultImage;
        }

        //UpdateLayeredWindow
        private void SetBackground(Image img,System.Windows.Forms.Control control)
        {
            try
            {
                Bitmap bitmap = (Bitmap)img;
                if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                {
                    throw new ApplicationException("图片必须为32位图像");
                }
                IntPtr hObject = IntPtr.Zero;
                IntPtr zero = IntPtr.Zero;
                IntPtr hDC = Win32.GetDC(IntPtr.Zero);
                IntPtr ptr2 = Win32.CreateCompatibleDC(hDC);
                try
                {
                    hObject = bitmap.GetHbitmap(Color.FromArgb(0));
                    zero = Win32.SelectObject(ptr2, hObject);
                    Win32.Size size2 = new Win32.Size(bitmap.Width, bitmap.Height);
                    Win32.Size psize = size2;
                    Win32.Point point3 = new Win32.Point(0, 0);
                    Win32.Point pprSrc = point3;
                    point3 = new Win32.Point(control.Left, control.Top);
                    Win32.Point pptDst = point3;
                    Win32.BLENDFUNCTION pblend = new Win32.BLENDFUNCTION();
                    pblend.BlendOp = 0;
                    pblend.BlendFlags = 0;
                    pblend.SourceConstantAlpha = 0xff;
                    pblend.AlphaFormat = 1;
                    Win32.UpdateLayeredWindow(control.Handle, hDC, ref pptDst, ref psize, ptr2, ref pprSrc, 0, ref pblend, 2);
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    throw exception;
                }
                finally
                {
                    Win32.ReleaseDC(IntPtr.Zero, hDC);
                    if (hObject != IntPtr.Zero)
                    {
                        Win32.SelectObject(ptr2, zero);
                        Win32.DeleteObject(hObject);
                    }
                    Win32.DeleteDC(ptr2);
                }
            }
            catch (ApplicationException exception4)
            {
                ApplicationException exception2 = exception4;
                throw new Exception("请检测你的png文件");
            }
            catch (Exception exception5)
            {
                Exception exception3 = exception5;
                throw new Exception("无法打开png文件");
            }
        }

        /*获取图片不完全透明的部分*/
        private GraphicsPath GetWindowRegion(Bitmap bitmap)
        {
            Color TempColor;
            GraphicsPath gp = new GraphicsPath();
            if (bitmap == null) return null;

            /*横向扫描，当扫描到的点并非需要剔除的点时，将这个点记为起始点，继续扫描直到找到下一个需要剔除的点时，
            将上一个非需要剔除的点记为结束点，将这个宽为1像素的矩形记录至GraphicsPath中，
            循环以上直到这一列的最后一个点。循环以上步骤直到扫面完整幅图片*/

            for (int nX = 0; nX < bitmap.Width; nX++)
            {
                int startPos = 0;
                int lastPos = 0;
                bool flag = false;
                for (int nY = 0; nY < bitmap.Height; nY++)
                {
                    TempColor = bitmap.GetPixel(nX, nY);
                    if (TempColor.A != 0)
                    {
                        if (startPos == 0)
                        {
                            flag = true;
                            startPos = nY;
                            lastPos = nY;
                        }
                        else if (nY == lastPos + 1)
                        {
                            lastPos = nY;
                        }
                        else
                        {
                            flag = false;
                            gp.AddRectangle(new Rectangle(nX, startPos, 1, lastPos - startPos + 1));
                            startPos = nY;
                            lastPos = nY;
                        }
                    }
                    else
                    {
                        if (flag)
                        {
                            flag = false;
                            gp.AddRectangle(new Rectangle(nX, startPos, 1, lastPos - startPos + 1));
                            startPos = 0;
                        }
                    }
                }
                if (flag == true)
                {
                    gp.AddRectangle(new Rectangle(nX, startPos, 1, lastPos - startPos + 1));
                }
            }
            return gp;
        }
    }
}
