namespace FYJ.Winform.Forms
{
    partial class MessageBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.baseButton1 = new FYJ.Winform.Controls.BaseButton();
            this.baseButton2 = new FYJ.Winform.Controls.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(29, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(79, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 62);
            this.label1.TabIndex = 29;
            // 
            // baseButton1
            // 
            this.baseButton1.BackColor = System.Drawing.Color.Transparent;
            this.baseButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.BackgroundImage")));
            this.baseButton1.Location = new System.Drawing.Point(205, 148);
            this.baseButton1.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.MouseDownImage")));
            this.baseButton1.MouseEnterImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.MouseEnterImage")));
            this.baseButton1.MouseNormalImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.MouseNormalImage")));
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(69, 21);
            this.baseButton1.TabIndex = 30;
            this.baseButton1.ToolTipString = "";
            this.baseButton1.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButton2
            // 
            this.baseButton2.BackColor = System.Drawing.Color.Transparent;
            this.baseButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("baseButton2.BackgroundImage")));
            this.baseButton2.Location = new System.Drawing.Point(280, 148);
            this.baseButton2.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("baseButton2.MouseDownImage")));
            this.baseButton2.MouseEnterImage = ((System.Drawing.Image)(resources.GetObject("baseButton2.MouseEnterImage")));
            this.baseButton2.MouseNormalImage = ((System.Drawing.Image)(resources.GetObject("baseButton2.MouseNormalImage")));
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.Size = new System.Drawing.Size(69, 21);
            this.baseButton2.TabIndex = 31;
            this.baseButton2.ToolTipString = "";
            this.baseButton2.Click += new System.EventHandler(this.baseButton2_Click);
            // 
            // MessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 176);
            this.Controls.Add(this.baseButton2);
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MessageBoxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBoxForm";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.baseButton1, 0);
            this.Controls.SetChildIndex(this.baseButton2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Controls.BaseButton baseButton1;
        private Controls.BaseButton baseButton2;
    }
}