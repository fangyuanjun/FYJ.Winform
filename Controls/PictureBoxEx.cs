using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace FYJ.Winform.Controls
{
   public class PictureBoxEx :System.Windows.Forms.PictureBox
    {
        private Image _mouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_normal;
        private Image _mouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_highlight;
        private Image _mouseDownImage = global::FYJ.Winform.Properties.Resources.btn_down;
        public PictureBoxEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        #region 状态图属性
        [Browsable(true)]
        public Image MouseEnterImage
        {
            get
            {
                return _mouseEnterImage == null ? BackgroundImage : _mouseEnterImage;
            }
            set
            {
                _mouseEnterImage = value;
            }
        }

        [Browsable(true)]
        public Image MouseNormalImage
        {
            get
            {
                return _mouseNormalImage == null ? BackgroundImage : _mouseNormalImage;
            }
            set
            {
                _mouseNormalImage = value;
            }
        }
        [Browsable(true)]
        public Image MouseDownImage
        {
            get
            {
                return _mouseDownImage == null ? BackgroundImage : _mouseDownImage;
            }
            set
            {
                _mouseDownImage = value;
            }
        }
       

        #endregion


        #region 重写4种鼠标事件
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackgroundImage = MouseEnterImage;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackgroundImage = MouseNormalImage;
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.BackgroundImage = MouseDownImage;
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.BackgroundImage = MouseNormalImage;
        }
        #endregion

        private ToolTip toolTip1 = new ToolTip();
        [Browsable(true)]
        public string ToolTipString
        {
            get { return this.toolTip1.GetToolTip(this); }
            set
            {
                this.toolTip1.SetToolTip(this, value);
            }
        }
    }
}
