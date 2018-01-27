namespace FYJ.Winform.Controls
{
    partial class ColorSkin
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_S = new System.Windows.Forms.PictureBox();
            this.label_S = new System.Windows.Forms.Label();
            this.pictureBox_HL = new System.Windows.Forms.PictureBox();
            this.label_HL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_S)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_HL)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_S
            // 
            this.pictureBox_S.Location = new System.Drawing.Point(0, 112);
            this.pictureBox_S.Name = "pictureBox_S";
            this.pictureBox_S.Size = new System.Drawing.Size(360, 20);
            this.pictureBox_S.TabIndex = 21;
            this.pictureBox_S.TabStop = false;
            this.pictureBox_S.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_S_MouseDown);
            // 
            // label_S
            // 
            this.label_S.BackColor = System.Drawing.Color.White;
            this.label_S.Image = global::FYJ.Winform.Properties.Resources.xiaoyuanquan;
            this.label_S.Location = new System.Drawing.Point(372, 6);
            this.label_S.Name = "label_S";
            this.label_S.Size = new System.Drawing.Size(8, 8);
            this.label_S.TabIndex = 20;
            // 
            // pictureBox_HL
            // 
            this.pictureBox_HL.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_HL.Name = "pictureBox_HL";
            this.pictureBox_HL.Size = new System.Drawing.Size(360, 100);
            this.pictureBox_HL.TabIndex = 18;
            this.pictureBox_HL.TabStop = false;
            this.pictureBox_HL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_HL_MouseDown);
            // 
            // label_HL
            // 
            this.label_HL.BackColor = System.Drawing.Color.White;
            this.label_HL.Image = global::FYJ.Winform.Properties.Resources.xiaoyuanquan;
            this.label_HL.Location = new System.Drawing.Point(372, 29);
            this.label_HL.Name = "label_HL";
            this.label_HL.Size = new System.Drawing.Size(8, 8);
            this.label_HL.TabIndex = 19;
            // 
            // ColorSkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox_S);
            this.Controls.Add(this.label_S);
            this.Controls.Add(this.pictureBox_HL);
            this.Controls.Add(this.label_HL);
            this.Name = "ColorSkin";
            this.Size = new System.Drawing.Size(388, 142);
            this.Load += new System.EventHandler(this.ColorSkin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_S)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_HL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_S;
        private System.Windows.Forms.PictureBox pictureBox_HL;
        private System.Windows.Forms.Label label_HL;
        private System.Windows.Forms.PictureBox pictureBox_S;
    }
}
