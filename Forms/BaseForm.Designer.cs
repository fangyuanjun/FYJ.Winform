namespace FYJ.Winform.Forms
{
    partial class BaseForm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ButtonClose = new FYJ.Winform.Controls.PictureBoxEx();
            this.ButtonMax = new FYJ.Winform.Controls.PictureBoxEx();
            this.ButtonMin = new FYJ.Winform.Controls.PictureBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.ButtonClose.Image = global::FYJ.Winform.Properties.Resources.btn_close_normal;
            this.ButtonClose.Location = new System.Drawing.Point(534, 0);
            this.ButtonClose.MouseDownImage = global::FYJ.Winform.Properties.Resources.btn_close_down;
            this.ButtonClose.MouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_close_highlight;
            this.ButtonClose.MouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_close_normal;
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(38, 18);
            this.ButtonClose.TabIndex = 21;
            this.ButtonClose.TabStop = false;
            this.ButtonClose.ToolTipString = "关闭";
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonMax
            // 
            this.ButtonMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMax.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMax.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_max_normal;
            this.ButtonMax.Location = new System.Drawing.Point(509, 0);
            this.ButtonMax.MouseDownImage = global::FYJ.Winform.Properties.Resources.btn_max_down;
            this.ButtonMax.MouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_max_highlight;
            this.ButtonMax.MouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_max_normal;
            this.ButtonMax.Name = "ButtonMax";
            this.ButtonMax.Size = new System.Drawing.Size(25, 18);
            this.ButtonMax.TabIndex = 23;
            this.ButtonMax.TabStop = false;
            this.ButtonMax.ToolTipString = "最大化";
            this.ButtonMax.Click += new System.EventHandler(this.ButtonMax_Click);
            // 
            // ButtonMin
            // 
            this.ButtonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMin.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMin.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_mini_normal;
            this.ButtonMin.Location = new System.Drawing.Point(484, 0);
            this.ButtonMin.MouseDownImage = global::FYJ.Winform.Properties.Resources.btn_mini_down;
            this.ButtonMin.MouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_mini_highlight;
            this.ButtonMin.MouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_mini_normal;
            this.ButtonMin.Name = "ButtonMin";
            this.ButtonMin.Size = new System.Drawing.Size(25, 18);
            this.ButtonMin.TabIndex = 20;
            this.ButtonMin.TabStop = false;
            this.ButtonMin.ToolTipString = "最小化";
            this.ButtonMin.Click += new System.EventHandler(this.ButtonMin_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(572, 286);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonMax);
            this.Controls.Add(this.ButtonMin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(230, 125);
            this.Name = "BaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).EndInit();
            this.ResumeLayout(false);

        }
        private Controls.PictureBoxEx ButtonMin;
        private Controls.PictureBoxEx ButtonMax;
        private Controls.PictureBoxEx ButtonClose;
        #endregion
        private System.Windows.Forms.Timer timer1;


    }
}