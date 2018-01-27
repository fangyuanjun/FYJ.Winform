namespace FYJ.Winform.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonSkin = new FYJ.Winform.Controls.PictureBoxEx();
            this.ButtonMenu = new FYJ.Winform.Controls.PictureBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSkin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonSkin
            // 
            this.ButtonSkin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSkin.BackColor = System.Drawing.Color.Transparent;
            this.ButtonSkin.Image = global::FYJ.Winform.Properties.Resources.btn_skin_normal;
            this.ButtonSkin.Location = new System.Drawing.Point(434, 0);
            this.ButtonSkin.MouseDownImage = global::FYJ.Winform.Properties.Resources.btn_skin_down;
            this.ButtonSkin.MouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_skin_highlight;
            this.ButtonSkin.MouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_skin_normal;
            this.ButtonSkin.Name = "ButtonSkin";
            this.ButtonSkin.Size = new System.Drawing.Size(25, 18);
            this.ButtonSkin.TabIndex = 29;
            this.ButtonSkin.TabStop = false;
            this.ButtonSkin.ToolTipString = "";
            this.ButtonSkin.Click += new System.EventHandler(this.ButtonSkin_Click);
            // 
            // ButtonMenu
            // 
            this.ButtonMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMenu.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMenu.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_menu_normal;
            this.ButtonMenu.Location = new System.Drawing.Point(459, 0);
            this.ButtonMenu.MouseDownImage = global::FYJ.Winform.Properties.Resources.btn_menu_down;
            this.ButtonMenu.MouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_menu_highlight;
            this.ButtonMenu.MouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_menu_normal;
            this.ButtonMenu.Name = "ButtonMenu";
            this.ButtonMenu.Size = new System.Drawing.Size(25, 18);
            this.ButtonMenu.TabIndex = 28;
            this.ButtonMenu.TabStop = false;
            this.ButtonMenu.ToolTipString = "";
            this.ButtonMenu.Click += new System.EventHandler(this.ButtonMenu_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(572, 286);
            this.Controls.Add(this.ButtonSkin);
            this.Controls.Add(this.ButtonMenu);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm2";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.Controls.SetChildIndex(this.ButtonMenu, 0);
            this.Controls.SetChildIndex(this.ButtonSkin, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSkin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PictureBoxEx ButtonSkin;
        private Controls.PictureBoxEx ButtonMenu;
    }
}