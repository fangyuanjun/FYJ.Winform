using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace FYJ.Winform.Controls
{
   public partial class CommonTextBox :System.Windows.Forms.UserControl
    {
        private Graphics g = null;
        private Bitmap Bmp = null;
        private Color borderColor = Color.FromArgb(84, 165, 213);
        private Bitmap _icon;

        public CommonTextBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            Bmp = global::FYJ.Winform.Properties.Resources.frameBorderEffect_normalDraw;
            Icon = global::FYJ.Winform.Properties.Resources.keyboard;
            InitializeComponent();
         
        }

        [Description("文本"), Category("Appearance")]
        public string Texts
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                this.Invalidate();
            }
        }

        [Description("图标"), Category("Appearance")]
        public Bitmap Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                if (value == null)
                    this.textBox1.Location = new Point(3,this.textBox1.Location.Y);
                this.Invalidate();
            }
        }

        [Description("图标描述文字"), Category("Appearance")]
        public String IconToolTipText
        {
            get;
            set;
        }

        [Description("密码框"), Category("Appearance")]
        public bool IsPass
        {
            get
            {
                return textBox1.UseSystemPasswordChar;
            }
            set
            {
                textBox1.UseSystemPasswordChar = value;
                if(value)
                    Icon = global::FYJ.Winform.Properties.Resources.keyboard;
            }
        }

        [Description("只读"), Category("Appearance")]
        public bool ReadOn
        {
            get
            {
                return textBox1.ReadOnly;
            }
            set
            {
                textBox1.ReadOnly = value;
                if (value)
                    textBox1.BackColor = Color.Gray;
                else
                    textBox1.BackColor = Color.White;
            }
        }

        public System.Windows.Forms.TextBox textBox
        {
            get
            {
                return textBox1;
            }
            set
            {
                textBox1 = value;
            }
        }

        [Description("右键菜单"), Category("Appearance")]
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return textBox1.ContextMenuStrip;
            }
            set
            {
                textBox1.ContextMenuStrip = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;
            if(Bmp==null)
                Bmp = global::FYJ.Winform.Properties.Resources.frameBorderEffect_normalDraw;
            if (Bmp != null)
            {
                g.DrawImage(Bmp, new Rectangle(0, 0, 4, 4), 0, 0, 4, 4, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(4, 0, this.Width - 8, 4), 4, 0, Bmp.Width - 8, 4, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(this.Width - 4, 0, 4, 4), Bmp.Width - 4, 0, 4, 4, GraphicsUnit.Pixel);

                g.DrawImage(Bmp, new Rectangle(0, 4, 4, this.Height - 6), 0, 4, 4, Bmp.Height - 8, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(this.Width - 4, 4, 4, this.Height - 6), Bmp.Width - 4, 4, 4, Bmp.Height - 6, GraphicsUnit.Pixel);

                g.DrawImage(Bmp, new Rectangle(0, this.Height - 2, 2, 2), 0, Bmp.Height - 2, 2, 2, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(2, this.Height - 2, this.Width - 2, 2), 2, Bmp.Height - 2, Bmp.Width - 4, 2, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(this.Width - 2, this.Height - 2, 2, 2), Bmp.Width - 2, Bmp.Height - 2, 2, 2, GraphicsUnit.Pixel);
            }
                if (Icon != null)
                g.DrawImage(Icon, new Rectangle(1, 1, Bmp.Width, Bmp.Height), 0, 0, Bmp.Width, Bmp.Height, GraphicsUnit.Pixel);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            Bmp = global::FYJ.Winform.Properties.Resources.frameBorderEffect_mouseDownDraw;
            this.Invalidate();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            Bmp = global::FYJ.Winform.Properties.Resources.frameBorderEffect_normalDraw;
            this.Invalidate();
        }

        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            textBox1.Font = this.Font;
        }

        protected override void OnParentForeColorChanged(EventArgs e)
        {
            base.OnParentForeColorChanged(e);
            textBox1.ForeColor = this.ForeColor;
        }

        public event EventHandler IconEvent;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Icon == null)
                return;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (e.X > 3 && e.X < (this.Icon.Width+3)&&e.Y > 3 && e.Y < (this.Icon.Height+3))
                {
                    if (IconEvent != null)
                        IconEvent(this, null);
                }
                //else
                //    this.OnClick(e);    不要  否则会执行2次
            }
        }
        System.Windows.Forms.ToolTip toolTip1 = new ToolTip();
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.Icon == null)
                return;
            if (e.X > 3 && e.X < (this.Icon.Width + 3) && e.Y > 3 && e.Y < (this.Icon.Height + 3))
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
            if (IconToolTipText!=null)
            toolTip1.SetToolTip(this, "打开软键盘");
        }

       
    }
}
