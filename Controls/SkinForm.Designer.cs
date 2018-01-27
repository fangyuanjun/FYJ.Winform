namespace FYJ.Winform.Controls
{
    partial class SkinForm
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
            this.components = new System.ComponentModel.Container();
            CSharpWin.TrackBarColorTable trackBarColorTable1 = new CSharpWin.TrackBarColorTable();
            FYJ.Winform.Util.HSLColor hslColor1 = new FYJ.Winform.Util.HSLColor();
            this.trackBarEx1 = new CSharpWin.TrackBarEx();
            this.colorSkin1 = new FYJ.Winform.Controls.ColorSkin();
            this.pictureBoxEx_color = new FYJ.Winform.Controls.PictureBoxEx();
            this.pictureBoxEx_pic = new FYJ.Winform.Controls.PictureBoxEx();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEx_color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEx_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarEx1
            // 
            this.trackBarEx1.BackgroundImage = global::FYJ.Winform.Properties.Resources.透明度;
            this.trackBarEx1.ColorTable = trackBarColorTable1;
            this.trackBarEx1.Location = new System.Drawing.Point(4, 181);
            this.trackBarEx1.Maximum = 80;
            this.trackBarEx1.Name = "trackBarEx1";
            this.trackBarEx1.Size = new System.Drawing.Size(349, 45);
            this.trackBarEx1.TabIndex = 3;
            this.trackBarEx1.Value = 20;
            this.trackBarEx1.Scroll += new System.EventHandler(this.trackBarEx1_Scroll);
            // 
            // colorSkin1
            // 
            this.colorSkin1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.colorSkin1.CurrentColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(235)))), ((int)(((byte)(236)))));
            hslColor1.Alpha = 255;
            hslColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(235)))), ((int)(((byte)(236)))));
            hslColor1.Hue = 356;
            hslColor1.Lightness = 0.96D;
            hslColor1.Saturation = 0.91388888888888886D;
            this.colorSkin1.CurrentHSL = hslColor1;
            this.colorSkin1.Location = new System.Drawing.Point(4, 40);
            this.colorSkin1.Name = "colorSkin1";
            this.colorSkin1.Size = new System.Drawing.Size(358, 135);
            this.colorSkin1.TabIndex = 2;
            // 
            // pictureBoxEx_color
            // 
            this.pictureBoxEx_color.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEx_color.BackgroundImage = global::FYJ.Winform.Properties.Resources.TbAdjustColorNormal;
            this.pictureBoxEx_color.Location = new System.Drawing.Point(18, 10);
            this.pictureBoxEx_color.MouseDownImage = global::FYJ.Winform.Properties.Resources.TbAdjustColorPushed;
            this.pictureBoxEx_color.MouseEnterImage = global::FYJ.Winform.Properties.Resources.TbAdjustColorPushed;
            this.pictureBoxEx_color.MouseNormalImage = global::FYJ.Winform.Properties.Resources.TbAdjustColorNormal;
            this.pictureBoxEx_color.Name = "pictureBoxEx_color";
            this.pictureBoxEx_color.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxEx_color.TabIndex = 1;
            this.pictureBoxEx_color.TabStop = false;
            this.pictureBoxEx_color.ToolTipString = "";
            this.pictureBoxEx_color.Click += new System.EventHandler(this.pictureBoxExColor_Click);
            // 
            // pictureBoxEx_pic
            // 
            this.pictureBoxEx_pic.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEx_pic.BackgroundImage = global::FYJ.Winform.Properties.Resources.TbShadingNormal;
            this.pictureBoxEx_pic.Location = new System.Drawing.Point(57, 10);
            this.pictureBoxEx_pic.MouseDownImage = global::FYJ.Winform.Properties.Resources.TbShadingPushed;
            this.pictureBoxEx_pic.MouseEnterImage = global::FYJ.Winform.Properties.Resources.TbShadingPushed;
            this.pictureBoxEx_pic.MouseNormalImage = global::FYJ.Winform.Properties.Resources.TbShadingNormal;
            this.pictureBoxEx_pic.Name = "pictureBoxEx_pic";
            this.pictureBoxEx_pic.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxEx_pic.TabIndex = 0;
            this.pictureBoxEx_pic.TabStop = false;
            this.pictureBoxEx_pic.ToolTipString = "";
            this.pictureBoxEx_pic.Click += new System.EventHandler(this.pictureBoxExPic_Click);
            // 
            // SkinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(365, 204);
            this.Controls.Add(this.trackBarEx1);
            this.Controls.Add(this.colorSkin1);
            this.Controls.Add(this.pictureBoxEx_color);
            this.Controls.Add(this.pictureBoxEx_pic);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SkinForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEx_color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEx_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBoxEx pictureBoxEx_pic;
        private PictureBoxEx pictureBoxEx_color;
        private ColorSkin colorSkin1;
        private CSharpWin.TrackBarEx trackBarEx1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
