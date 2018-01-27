using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FYJ.Winform.Forms
{
    public partial class MessageBoxForm : BaseForm
    {
        private MessageBoxButtons _buttons = MessageBoxButtons.OK;
        public MessageBoxForm(String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = caption;
            this.label1.Text = text;
            this.baseButton1.Text = "确定";
            this.baseButton2.Text = "取消";
            this.BackgroundImageLayout = ImageLayout.Stretch;

            if (this.Owner != null)
            {
                this.BackColor = this.Owner.BackColor;
                this.BackgroundImage = this.Owner.BackgroundImage;
            }

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    this.baseButton2.Visible = false;
                    this.baseButton1.Location = new Point(this.baseButton1.Location.X + 69, this.baseButton1.Location.Y);
                    break;
                case MessageBoxButtons.YesNo:
                    _buttons = MessageBoxButtons.YesNo;
                    this.baseButton1.Text = "是";
                    this.baseButton2.Text = "否";
                    break;
            }

            switch (icon)
            {
                case MessageBoxIcon.Asterisk:
                    this.pictureBox1.Image = global::FYJ.Winform.Properties.Resources.sysmessagebox_inforFile;
                    break;
                case MessageBoxIcon.Error:
                    this.pictureBox1.Image = global::FYJ.Winform.Properties.Resources.sysmessagebox_errorFile;
                    break;
                case MessageBoxIcon.Exclamation:
                    this.pictureBox1.Image = global::FYJ.Winform.Properties.Resources.sysmessagebox_warningFile;
                    break;
                case MessageBoxIcon.None:
                    break;
                case MessageBoxIcon.Question:
                    this.pictureBox1.Image = global::FYJ.Winform.Properties.Resources.sysmessagebox_questionFile;
                    break;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Enter)
            {
                baseButton1_Click(null, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                baseButton2_Click(null, null);
            }
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            if (_buttons == MessageBoxButtons.YesNo)
            {
                this.DialogResult = DialogResult.Yes;
            }
            if (_buttons == MessageBoxButtons.OK || _buttons == MessageBoxButtons.OKCancel)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void baseButton2_Click(object sender, EventArgs e)
        {
            if (_buttons == MessageBoxButtons.YesNo)
            {
                this.DialogResult = DialogResult.No;
            }
            this.Close();
        }
    }
}
