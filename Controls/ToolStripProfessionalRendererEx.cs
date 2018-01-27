using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using FYJ.Winform.Util;

namespace FYJ.Winform.Controls
{
   public class ToolStripProfessionalRendererEx:ToolStripProfessionalRenderer
    {
       private Color _color = MyFormTemp.CurrentBackgroundColor;
       public Color CurrentColor
       {
           get { return _color; }
           set { _color = value; }
       }
         public ToolStripProfessionalRendererEx():base()
         {
        }
         public ToolStripProfessionalRendererEx(Color color)
             : base()
        {
            _color = color;
         }
       
         //渲染背景 包括menustrip背景 toolstripDropDown背景
         protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
         {
             
             base.OnRenderToolStripBackground(e);
             ToolStrip toolStrip = e.ToolStrip;
             Graphics g = e.Graphics;
             g.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿
             Rectangle bounds = e.AffectedBounds;
             LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(0, toolStrip.Height), Color.FromArgb(255, Color.White), Color.FromArgb(150, _color));
         
              if (toolStrip is ToolStripDropDown)
             {
                 g.FillRectangle(lgbrush, new Rectangle(25, 0, toolStrip.Size.Width-25, toolStrip.Size.Height));
             }
             else
             {
                 base.OnRenderToolStripBackground(e);
             }
         }
         //渲染边框 
         protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
         {
             Pen pen = new Pen(_color, 1);
             e.Graphics.DrawRectangle(pen, e.AffectedBounds);
    
                // int Rgn = Win32.CreateRoundRectRgn(1, 1, e.ToolStrip.Width , e.ToolStrip.Height , 3, 3);
               // Win32.SetWindowRgn(e.ToolStrip.Handle, Rgn, true);
             //base.OnRenderToolStripBorder(e);
         }

      
         //渲染箭头 更改箭头颜色
         protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
         {
             e.ArrowColor = _color;
             base.OnRenderArrow(e);
         }
         //渲染项 不调用基类同名方法
         protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
         {
             Graphics g = e.Graphics;
             g.SmoothingMode = SmoothingMode.HighQuality;
             ToolStripItem item = e.Item;
             ToolStrip toolstrip = e.ToolStrip;

             //渲染下拉项
              if (toolstrip is ToolStripDropDown)
             {
                 if (item.Selected)
                 {
                     SolidBrush brush = new SolidBrush(_color);
                     g.FillRectangle(brush, new Rectangle(0, 0, item.Width, item.Height));
                 }
             }
             else
             {
                 base.OnRenderMenuItemBackground(e);
             }
         }

       //渲染分隔线
         protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
         {
             Graphics g = e.Graphics;
             Pen pen = new Pen(_color, 1);
             g.DrawLine(pen,new Point(25,0),new Point(e.Item.Width,0));
         }
         //渲染图片区域 下拉菜单左边的图片区域
         protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
         {
             base.OnRenderImageMargin(e);
             //屏蔽掉左边图片竖条
         }

       
    }
}
