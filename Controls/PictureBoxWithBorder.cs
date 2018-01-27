using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace FYJ.Winform.Controls
{
   public class PictureBoxWithBorder :System.Windows.Forms.PictureBox
    {
       public PictureBoxWithBorder()
       {
          
       }
       protected override void OnMouseLeave(EventArgs e)
       {
           Graphics g = this.CreateGraphics();
           Pen pen = new Pen(this.BackColor, 1);
           g.DrawLine(pen, new Point(1, 1), new Point(this.Width - 2, 1));  //上边框
           g.DrawLine(pen, new Point(1, this.Height - 2), new Point(this.Width - 2, this.Height - 2));  //下边框
           g.DrawLine(pen, new Point(1, 1), new Point(1, this.Height - 2));  //左边框
         
           if (this.IsDrawRightBorder)
           {
               g.DrawLine(pen, new Point(this.Width-2, 1), new Point(this.Width-2, this.Height - 2));
           }
           else
               g.DrawLine(pen, new Point(this.Width - 1, 1), new Point(this.Width - 1, this.Height - 2));  //右边框
           base.OnMouseLeave(e);
          
       }

       protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
       {
           Graphics g = this.CreateGraphics();
           Pen pen = new Pen(Color.White, 1);
           g.DrawLine(pen, new Point(1, 1), new Point(this.Width - 2, 1));  //上边框
           g.DrawLine(pen, new Point(1, this.Height - 2), new Point(this.Width - 2, this.Height - 2));  //下边框
           g.DrawLine(pen, new Point(1, 1), new Point(1, this.Height - 2));  //左边框
           if (this.IsDrawRightBorder)
               g.DrawLine(pen, new Point(this.Width-2, 1), new Point(this.Width-2, this.Height - 2));  //右边框
           else
                g.DrawLine(pen, new Point(this.Width - 1, 1), new Point(this.Width - 1, this.Height - 2));  //右边框
           base.OnMouseMove(e);
       }

       private bool isDrawRightBorder = true;
       public bool IsDrawRightBorder
       {
           get { return isDrawRightBorder; }
           set { isDrawRightBorder = value; }
       }
       private bool isDrawBottomBorder = true;

       public bool IsDrawBottomBorder
       {
           get { return isDrawBottomBorder; }
           set { isDrawBottomBorder = value; }
       }
       protected override void OnPaint(PaintEventArgs pe)
       {
           Graphics g = pe.Graphics;
           Pen pen = new Pen(Color.Black, 1);
           g.DrawLine(pen, new Point(0, 0), new Point(this.Width - 1, 0));  //上边框
           if (IsDrawBottomBorder)
               g.DrawLine(pen, new Point(0, this.Height - 1), new Point(this.Width - 1, this.Height - 1));  //下边框
           g.DrawLine(pen, new Point(0, 0), new Point(0, this.Height - 1));  //左边框
           if (isDrawRightBorder)
               g.DrawLine(pen, new Point(this.Width - 1, 0), new Point(this.Width - 1, this.Height - 1));  //右边框
           base.OnPaint(pe);
       }

       protected override void OnCreateControl()
       {
          
           base.OnCreateControl();
       }

     
    }
}
