using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FYJ.Winform.Controls
{
    public partial class LogList : UserControl
    {
        #region 结构
        struct CustomItem
        {
           private DateTime date;  //时间
           private string msg;   //消息
           private  int index;   //位置
           private int flag;    //标识  0正常  1警告  2错误
           
            public CustomItem(DateTime date, string msg, int index, int flag)
            {
                this.date = date;
                this.msg = msg;
                this.index = index;
                this.flag = flag;
            }

            public DateTime Date
            {
                get { return this.date; }
            }
            public string Msg
            {
                get { return this.msg; }
            }
            public int Index
            {
                get { return this.index; }
            }
            public int Flag
            {
                get { return this.flag; }
            }
        }
        #endregion

        private List<ListViewItem> list = new List<ListViewItem>();

        public LogList()
        {
            InitializeComponent();
          
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.listView1.HeaderStyle = ColumnHeaderStyle.None;
            this.listView1.FullRowSelect = true;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //设置第二列自动调整大小
            this.listView1.Columns[0].Width = 150;
            this.listView1.Columns[1].Width = this.listView1.Width - this.listView1.Columns[0].Width-6;
        }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="msg"></param>
        public void AddErrorItem(string msg)
        {
            lock (this)
            {
                DateTime date = DateTime.Now;
                ListViewItem item = new ListViewItem(new string[] { date.ToString(), msg });
                item.Tag = 2;
                this.listView1.BeginUpdate();//
                this.listView1.Items.Add(item);
                this.listView1.Items[this.listView1.Items.Count - 1].ForeColor = Color.Red;
                list.Add(item);
                this.listView1.EndUpdate();//
            }
        }

        /// <summary>
        /// 添加警告信息
        /// </summary>
        /// <param name="msg"></param>
        public void AddWarnItem(string msg)
        {
            lock (this)
            {
                DateTime date = DateTime.Now;
                ListViewItem item = new ListViewItem(new string[] { date.ToString(), msg });
                item.Tag = 1;
                this.listView1.BeginUpdate();
                this.listView1.Items.Add(item);
                this.listView1.Items[this.listView1.Items.Count - 1].ForeColor = Color.Yellow;
                list.Add(item);
                this.listView1.EndUpdate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void AddItem(string msg)
        {
            lock (this)
            {
                DateTime date = DateTime.Now;
                ListViewItem item = new ListViewItem(new string[] { date.ToString(), msg });
                item.Tag = 0;
                this.listView1.BeginUpdate();
                this.listView1.Items.Add(item);
                list.Add(item);
                this.listView1.EndUpdate();
            }
        }


        private void FlagShowChange(int flag, bool isShow)
        {
            if (isShow)
            {
                foreach (ListViewItem item in list)
                {
                    if (item.Tag.ToString() == flag+"")
                    {
                        this.listView1.Items.Add(item);
                    }
                }
            }
            else
            {
                foreach (ListViewItem item in list)
                {
                    if (item.Tag.ToString() == flag+"")
                    {
                        this.listView1.Items.Remove(item);
                    }
                }
            }
        }
        private void 错误ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.错误ToolStripMenuItem.Checked = !this.错误ToolStripMenuItem.Checked;
            FlagShowChange(2,this.错误ToolStripMenuItem.Checked);
        }

        private void 警告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.警告ToolStripMenuItem.Checked = !this.警告ToolStripMenuItem.Checked;
            FlagShowChange(1, this.警告ToolStripMenuItem.Checked);
        }

        private void 正常ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.正常ToolStripMenuItem.Checked = !this.正常ToolStripMenuItem.Checked;
            FlagShowChange(0, this.正常ToolStripMenuItem.Checked);
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "*.txt|*.txt";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (ListViewItem item in this.listView1.Items)
                    {
                        sb.AppendLine(item.SubItems[0].Text+"   "+item.SubItems[1].Text);
                    }
                    StreamWriter write = new StreamWriter(sf.FileName, false, Encoding.Default, 40960);
                    write.Write(sb.ToString());
                    write.Close();
                }
            }
        }

        public void Clear()
        {
            this.listView1.Items.Clear();
            this.list.Clear();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string s = this.listView1.SelectedItems[0].SubItems[1].Text;
                Clipboard.SetText(s);
                MessageBox.Show("已复制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("复制到剪贴板失败:"+ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
