using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FYJ.Winform.Controls
{
  public  class SkinImageButton :ImageButton
    {
      private bool _isCha = true;
      public bool IsCha
      {
          get { return _isCha; }
          set { _isCha = value; }
      }
      public event EventHandler DeleteEvent;
      protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
      {
          if (isBorder)
          {
              Graphics g = pe.Graphics;
             
              if (this.DrawImage != null)
                  g.DrawImage(this.DrawImage, new Rectangle(0, 0, this.Width, this.Height));
              g.DrawImage(global::FYJ.Winform.Properties.Resources.shading_highlight, new Rectangle(0, 0, this.Width, this.Height), 0, 0, 20, 20, GraphicsUnit.Pixel); //一定在上句下面
              global::FYJ.Winform.Properties.Resources.shading_highlight.Dispose();
              if(IsCha)
              g.DrawImage(global::FYJ.Winform.Properties.Resources.cha, new Rectangle(this.Width - 19,3, 16, 16));  //画X
             // g.Dispose();  如果不是create这里不能用
          }
          else
          {
              Graphics g = pe.Graphics;
              if (this.DrawImage != null)
                  g.DrawImage(this.DrawImage, new Rectangle(0, 0, this.Width, this.Height));
              // g.Dispose();如果不是create这里不能用
          }

      }
      private ToolTip toolTip1 = new ToolTip();
      
      protected override void OnMouseDown(MouseEventArgs e)
      {
          base.OnMouseDown(e);
          if (!IsCha)
              return;
          if (e.Button == MouseButtons.Left&&e.Clicks==1)
          {
              if (e.X > this.Width - 19 && e.X < this.Width - 3 && e.Y > 3 && e.Y < 19)
              {
                  if (DeleteEvent != null)
                      DeleteEvent(this,null);
              }
              //else
              //    this.OnClick(e);    不要  否则会执行2次
          }
      }
    
      protected override void OnMouseMove(MouseEventArgs e)
      {
          base.OnMouseMove(e);
          if (!IsCha)
              return;
          if (e.X > this.Width - 19 && e.X < this.Width - 3 && e.Y > 3 && e.Y < 19)
          {
          }
          else
          {
              toolTip1.Hide(this);
          }
      }

      protected override void OnCreateControl()
      {
          base.OnCreateControl();
          if (!IsCha)
              return;
          toolTip1.SetToolTip(this, "删除");
      }

      private void InitializeComponent()
      {
          ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
          this.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
          this.ResumeLayout(false);

      }
      
     
    }
}
