using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using FYJ.Winform.Util;

namespace FYJ.Winform.Controls
{
     [DefaultEvent("Click")]
  public  class BaseButton:System.Windows.Forms.UserControl,IButtonControl
    {
        private Image _mouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_normal;
        private Image _mouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_highlight;
        private Image _mouseDownImage = global::FYJ.Winform.Properties.Resources.btn_down;
        private Image _currentImage = global::FYJ.Winform.Properties.Resources.btn_normal;
        private Image _disabledImage = global::FYJ.Winform.Properties.Resources.btn_disabled;
        public BaseButton()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Color.Transparent;
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
           // InitializeComponent();
          
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
        public Image DisabledImage
        {
            get
            {
                return _disabledImage == null ? BackgroundImage : _disabledImage;
            }
            set
            {
                _disabledImage = value;
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
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackgroundImage = this.MouseNormalImage;
            this.Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.BackgroundImage = this.MouseDownImage;
            this.Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.BackgroundImage = MouseNormalImage;
            this.Invalidate();
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
        private string _text = "";

        [Browsable(true)]
        public override string Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Font f = new Font("宋体", 10f, FontStyle.Regular);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Brush br = Brushes.Black;
            if (this.Enabled == false)
            {
                br = Brushes.Gray;
                this.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_disabled;
            }
            g.DrawString(Text, f, br, this.ClientRectangle, sf);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if(this.Enabled)
                this.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_normal;
        }
     
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(69, 21);
            this.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_normal;
            this.BackColor = Color.Transparent;
            this.ResumeLayout(false);

        }

        private DialogResult myDialogResult;
        // Add implementation to the IButtonControl.DialogResult property.
        public DialogResult DialogResult
        {
            get
            {
                return this.myDialogResult;
            }

            set
            {
                if (Enum.IsDefined(typeof(DialogResult), value))
                {
                    this.myDialogResult = value;
                }
            }
        }
         private bool IsDefault=true;
        // Add implementation to the IButtonControl.NotifyDefault method.
        public void NotifyDefault(bool value)
        {
            if (this.IsDefault != value)
            {
                this.IsDefault = value;
            }
        }

        // Add implementation to the IButtonControl.PerformClick method.
        public void PerformClick()
        {
            if (this.CanSelect)
            {
                this.OnClick(EventArgs.Empty);
            }
        }

    }
}
