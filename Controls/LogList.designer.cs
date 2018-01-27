namespace FYJ.Winform.Controls
{
    partial class LogList
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.错误ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.警告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.正常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(630, 184);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "信息";
            this.columnHeader2.Width = 257;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.错误ToolStripMenuItem,
            this.警告ToolStripMenuItem,
            this.正常ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 158);
            // 
            // 错误ToolStripMenuItem
            // 
            this.错误ToolStripMenuItem.Checked = true;
            this.错误ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.错误ToolStripMenuItem.Name = "错误ToolStripMenuItem";
            this.错误ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.错误ToolStripMenuItem.Text = "错误";
            this.错误ToolStripMenuItem.Click += new System.EventHandler(this.错误ToolStripMenuItem_Click);
            // 
            // 警告ToolStripMenuItem
            // 
            this.警告ToolStripMenuItem.Checked = true;
            this.警告ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.警告ToolStripMenuItem.Name = "警告ToolStripMenuItem";
            this.警告ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.警告ToolStripMenuItem.Text = "警告";
            this.警告ToolStripMenuItem.Click += new System.EventHandler(this.警告ToolStripMenuItem_Click);
            // 
            // 正常ToolStripMenuItem
            // 
            this.正常ToolStripMenuItem.Checked = true;
            this.正常ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.正常ToolStripMenuItem.Name = "正常ToolStripMenuItem";
            this.正常ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.正常ToolStripMenuItem.Text = "正常";
            this.正常ToolStripMenuItem.Click += new System.EventHandler(this.正常ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出ToolStripMenuItem.Text = "导出...";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // LogList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "LogList";
            this.Size = new System.Drawing.Size(630, 184);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 错误ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 警告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 正常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
    }
}
