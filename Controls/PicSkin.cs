using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FYJ.Winform.Forms;

namespace FYJ.Winform.Controls
{
    public partial class PicSkin : UserControl
    {
        public PicSkin()
        {
            InitializeComponent();
        }
        public delegate void SkinFileChangedEventHandler(String filePath);
        public event SkinFileChangedEventHandler SkinFileChanged;

        private void PicSkin_Load(object sender, EventArgs e)
        {
            LoadShadList();
        }

        private void LoadShadList()
        {
            int i = 0;
            Size picSize = new Size((this.Width - 7) / 6, (this.Height - 2) / 2);
            this.Controls.Clear();
            if (Directory.Exists(Application.StartupPath + "\\skin"))
            {
                foreach (String s in Directory.GetFiles(Application.StartupPath + "\\skin", "*small.*"))
                {
                    if (i > 11)
                        break;
                    // pic.SizeMode = PictureBoxSizeMode.AutoSize;
                    if (File.Exists(s.Replace("small", "big")))
                    {
                        SkinImageButton pic = new SkinImageButton();
                        pic.Size = picSize;
                        pic.Tag = s.Replace("small", "big");
                        FileStream fs = new FileStream(s,FileMode.Open);
                        Image img = Image.FromStream(fs);
                        fs.Close();
                        pic.DrawImage =img;

                        if (i < 6)
                        {
                            pic.Left = i * pic.Size.Width + 1 + i;
                            pic.Top = 1;
                        }
                        else
                        {
                            pic.Left = (i - 6) * pic.Size.Width + 1 + (i - 6);
                            pic.Top = pic.Size.Height + 2;
                        }


                        pic.DeleteEvent += new EventHandler(pic_DeleteEvent);
                        pic.Click += new EventHandler(pic_Click);
                        this.Controls.Add(pic);
                        i++;
                    }
                    else
                    {
                        try
                        {
                            File.Delete(s);
                            i--;
                        }
                        catch (Exception ex) { MessageBox.Show("加载异常"+ex.Message); }
                        
                    }
                }
            }

            SkinImageButton add = new SkinImageButton();
            add.Size = picSize;
            add.Tag = "add";
            add.DrawImage = global::FYJ.Winform.Properties.Resources.add;
            add.IsCha = false;
            add.Location = new Point(this.Width-1-picSize.Width,this.Height-1-picSize.Height); 
            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(add,"添加");
            add.Click += new EventHandler(pic_Click);
            this.Controls.Add(add);
        }

        void pic_DeleteEvent(object sender, EventArgs e)
        {
            String filePath = (sender as PictureBox).Tag.ToString();
            try
            {

               // File.Delete(filePath.Replace("big", "small")); 
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                using (MessageBoxForm frm = new MessageBoxForm("移除异常"+ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error))
                {
                    frm.ShowDialog(this);
                }
                return;
            }
            LoadShadList();
        }

        void pic_Click(object sender, EventArgs e)
        {
            String str = (sender as PictureBox).Tag.ToString();
            if (SkinFileChanged != null)
            {
                SkinFileChanged(str);
            }

            if (str == "add")
            {
                using (OpenFileDialog of = new OpenFileDialog())
                {
                    of.Filter = "图片文件|*.png;*.jpg;*.bmp;*.jpeg";
                    if (of.ShowDialog() == DialogResult.OK)
                    {
                        FileStream fs = new FileStream(of.FileName,FileMode.Open);
                        Image oldImage = Bitmap.FromStream(fs);
                        fs.Close();
                      Bitmap bit = new Bitmap(oldImage, 66, 45);
                      if (!Directory.Exists(Application.StartupPath + "\\skin"))
                          Directory.CreateDirectory(Application.StartupPath + "\\skin");
                      int r = new Random().Next(10000);
                      File.Copy(of.FileName, Application.StartupPath + "\\skin\\" + r + "_big" + Path.GetExtension(of.FileName));
                    
                      bit.Save(Application.StartupPath + "\\skin\\" + r + "_small" + Path.GetExtension(of.FileName));
                    }
                    LoadShadList();
                }
            }
        }

        //private void pic_MouseLeave(object sender, EventArgs e)
        //{
        //    (sender as PictureBox).Invalidate();
        //}

        //private void pic_MouseEnter(object sender, EventArgs e)
        //{
        //    PictureBox qp = sender as PictureBox;
        //    Graphics g = qp.CreateGraphics();
        //    g.DrawImage(global::FYJ.Winform.Properties.Resources.shading_highlight, new Rectangle(0, 0, 66, 45), 0, 0, 20, 20, GraphicsUnit.Pixel);
        //    global::FYJ.Winform.Properties.Resources.shading_highlight.Dispose();
        //    g.Dispose();
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen = new Pen(Brushes.White,1);
            e.Graphics.DrawLine(pen,new Point(0,0),new Point(this.Width,0));  //第一条横线
            e.Graphics.DrawLine(pen, new Point(0, (this.Height-2)/2), new Point(this.Width, (this.Height-2)/2));  //第二条横线
            e.Graphics.DrawLine(pen, new Point(0, this.Height), new Point(this.Width, this.Height));  //第三条横线
            for (int i = 0; i < 6; i++)
            {
                e.Graphics.DrawLine(pen, new Point((this.Width / 6) * i, 0), new Point((this.Width / 6) * i, this.Height));  
            }
        }
    }
}
