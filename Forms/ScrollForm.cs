using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace FYJ.Winform.Forms
{
   public class ScrollForm : System.Windows.Forms.Form
    {
        // Fields
        private FormClosingEventArgs closeArgs;
        private Timer closeScrollTimer = new Timer();
        private IContainer components = null;
        private int fromH = 0;
        private int fromW = 0;
        private Timer hideTimer = new Timer();
        private Point location = new Point(0, 0);
        private Timer showTimer = new Timer();
        private Timer startScrollTimer = new Timer();

        // Methods
        public ScrollForm()
        {
            this.InitializeComponent();
            this.closeScrollTimer.Interval = 1;
            this.closeScrollTimer.Tick += new EventHandler(this.closeScrollTimer_Tick);
            this.startScrollTimer.Interval = 1;
            this.startScrollTimer.Tick += new EventHandler(this.startScrollTimer_Tick);
            this.showTimer.Interval = 1;
            this.showTimer.Tick += new EventHandler(this.showTimer_Tick);
            this.hideTimer.Interval = 1;
            this.hideTimer.Tick += new EventHandler(this.hideTimer_Tick);
        }

        private void closeScrollTimer_Tick(object sender, EventArgs e)
        {
            if (base.Height > 50)
            {
                base.Size = new Size(base.Width, base.Height - 0x12);
                base.Location = new Point(base.Location.X, base.Location.Y + 9);
                base.Opacity -= 0.05;
            }
            else if (base.Width > 150)
            {
                base.Size = new Size(base.Width - 0x12, base.Height);
                base.Location = new Point(base.Location.X + 9, base.Location.Y);
                base.Opacity -= 0.05;
            }
            else
            {
                this.closeScrollTimer.Stop();
                base.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void HideEx()
        {
            this.refreshStateParam();
            this.hideTimer.Start();
        }

        private void hideTimer_Tick(object sender, EventArgs e)
        {
            if (base.Height > 50)
            {
                base.Size = new Size(base.Width, base.Height - 0x12);
                base.Location = new Point(base.Location.X, base.Location.Y + 9);
                base.Opacity -= 0.05;
            }
            else if (base.Width > 150)
            {
                base.Size = new Size(base.Width - 0x12, base.Height);
                base.Location = new Point(base.Location.X + 9, base.Location.Y);
                base.Opacity -= 0.05;
            }
            else
            {
                this.hideTimer.Stop();
                base.Visible = false;
                base.Width = this.fromW;
                base.Height = this.fromH;
                base.Location = new Point(this.location.X, this.location.Y);
            }
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.ClientSize = new Size(0x11c, 0x106);
            base.Name = "ScrollForm";
            this.Text = "ScrollForm";
            base.FormClosed += new FormClosedEventHandler(this.ScrollForm_FormClosed);
            base.ResumeLayout(false);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (base.Height > 50)
                {
                    this.closeArgs = e;
                    e.Cancel = true;
                    this.closeScrollTimer.Start();
                    this.Text = "";
                    if (base.WindowState == FormWindowState.Maximized)
                    {
                        base.WindowState = FormWindowState.Normal;
                    }
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.refreshStateParam();
            base.OnLoad(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void refreshStateParam()
        {
            this.fromW = base.Width;
            this.fromH = base.Height;
            this.location = new Point(base.Location.X, base.Location.Y);
        }

        private void ScrollForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.startScrollTimer.Stop();
            this.closeScrollTimer.Stop();
            this.showTimer.Stop();
            this.hideTimer.Stop();
            this.startScrollTimer.Dispose();
            this.closeScrollTimer.Dispose();
            this.showTimer.Dispose();
            this.hideTimer.Dispose();
        }

        public void ShowEx()
        {
            base.Show();
            base.Opacity = 0.0;
            base.Width = 1;
            base.Visible = true;
            this.showTimer.Start();
            this.startScrollTimer.Start();
        }

        private void showTimer_Tick(object sender, EventArgs e)
        {
            base.Opacity += 0.02;
            if (base.Opacity == 1.0)
            {
                this.showTimer.Stop();
            }
        }

        private void startScrollTimer_Tick(object sender, EventArgs e)
        {
            base.Width += 40;
            if (base.Width >= this.fromW)
            {
                base.Width = this.fromW;
                this.startScrollTimer.Stop();
            }
        }

    }
}
