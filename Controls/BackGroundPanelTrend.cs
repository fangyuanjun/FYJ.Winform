using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FYJ.Winform.Controls
{
    public class BackGroundPanelTrend : Panel
    {


        // Don't use the Paint-event like this: panel.Paint += ...
        //Instead of using a Panel, create a custom control class and override the OnPaint-method. To reduce flickering, also override the OnPaintBackground-method.

        // using System.Drawing;
        //using System.Windows.Forms;

        //public class RenderControl : Control
        //{
        // protected override void OnPaint(PaintEventArgs e)
        // {
        // // render-code goes here

        // base.OnPaint(e);
        // }

        // protected override void OnPaintBackground(PaintEventArgs e)
        // {
        // // do nothing here: doesn't paint background => no flickering
        // }
        //}
        //
        //Then use the RenderControl in your form, like any other control.
        //



        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 
            // 重载基类的背景擦除函数，
            // 解决窗口刷新，放大，图像闪烁

            // do nothing here: doesn't paint background => no flickering

            return;


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // render-code goes here

            this.DoubleBuffered = true;


            if (this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.DrawImage(this.BackgroundImage, new System.Drawing.Rectangle(0, 0, this.Width, this.Height),
                0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height,
                System.Drawing.GraphicsUnit.Pixel);
            }


            base.OnPaint(e);
        }

    }
}
