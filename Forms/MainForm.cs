using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FYJ.Winform.Controls;
using System.IO;
using FYJ.Winform.Util;
using System.Runtime.InteropServices;
using FYJ.Winform.Properties;

namespace FYJ.Winform.Forms
{
    public partial class MainForm : BaseForm
    {
        

        public MainForm()
        {
            InitializeComponent();
           
        }
        private SkinForm skinForm = new SkinForm();
       // private ChildForm childForm=new ChildForm();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                if (Settings.Default.skinColor != null)
                {
                    this.BackColor = Settings.Default.skinColor;
                    MyFormTemp.CurrentBackgroundColor = Settings.Default.skinColor;
                }
                if (Settings.Default.skinPic != null)
                {
                    if (File.Exists(Settings.Default.skinPic))
                    {
                        FileStream fs=new FileStream(Settings.Default.skinPic,FileMode.Open);
                        this.BackgroundImage = Image.FromStream(fs);
                        fs.Close();
                        MyFormTemp.CurrentBackgroundImage = this.BackgroundImage;
                    }
                }
            }
            catch
            {  }
            skinForm.ColorChanged += new SkinForm.ColorChangedEventHandler(skinPanel_ColorChanged);
            skinForm.SkinFileChanged += new SkinForm.SkinFileChangedEventHandler(skinPanel_SkinFileChanged);
            Control c = this.Controls.Find("ButtonMin",true)[0];
            this.ButtonMenu.Left = c.Left - ButtonMenu.Width;
            this.ButtonSkin.Left = ButtonMenu.Left - ButtonSkin.Width;
            if (!this.DesignMode)
            {
               // this.childForm.Owner = this;    // 这支所属窗体
               // this.childForm.Dock = DockStyle.Fill;
               // this.childForm.Show();
               // this.childForm.BringToFront();
               // this.childForm.Click += new EventHandler(childForm_Click);
               // OnSizeChanged(e);
                //OnLocationChanged(e);
            }
           
            skinForm.OpacityFileChanged += new SkinForm.OpacityChangedEventHandler(skinForm_OpacityFileChanged);
        }

       
        void childForm_Click(object sender, EventArgs e)
        {
            this.skinForm.Visible = false;
        }

      public  void skinForm_OpacityFileChanged(double opacity)
        {
            MyFormTemp.DrawOpacity = opacity;
            this.Opacity = opacity;
            
        }
      public void ButtonMenu_Click(FYJ.Winform.Controls.ContextMenuStripEx menuStripEx)
      {
          if (menuStripEx == null)
              return;
          //((ToolStripProfessionalRendererEx)this.contextMenuStripEx1.Renderer).CurrentColor = FYJ.Winform.Util.MyFormTemp.CurrentBackgroundColor;
          menuStripEx.Show(this.Left + this.ButtonMenu.Left - menuStripEx.Width + this.ButtonMenu.Width, this.ButtonMenu.Top + this.ButtonMenu.Height + this.Top);
      }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.skinForm.Visible = false;
            //if (this.childForm != null)
            //    this.childForm.Size = new Size(this.Width - 4, this.Height - 130 - 34);
           
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            //if (this.childForm != null)
            //    this.childForm.Location = new Point(this.Location.X + 2, this.Location.Y + 130);
        }

        protected virtual void ButtonMenu_Click(object sender, EventArgs e)
        {
          
        }

        private void ButtonSkin_Click(object sender, EventArgs e)
        {
            if (skinForm.Visible == false)
            {
                skinForm.Visible = true;
                skinForm.Left =this.Left+ this.ButtonSkin.Left + this.ButtonSkin.Width - 365;
                skinForm.Top =this.Top+ this.ButtonSkin.Top + this.ButtonSkin.Height;
                skinForm.BringToFront();
                skinForm.Focus();
               
            }
            else
            {
                skinForm.Visible = false;
            }
        }

       
        public virtual void skinPanel_SkinFileChanged(string filePath)
        {
            if (File.Exists(filePath))
            {
                
                FileStream fs = new FileStream(filePath,FileMode.Open);
                Image img = Image.FromStream(fs);
                fs.Close();
                    this.BackgroundImage = img;
                    this.BackgroundImageLayout = MyFormTemp.CurrentImageLayout;
                    MyFormTemp.CurrentBackgroundImage = this.BackgroundImage;
                   // this.childForm.BackgroundImage = this.BackgroundImage;
                    try
                    {
                        Settings.Default.skinPic = filePath;
                        Settings.Default.Save();
                    }
                    catch { }
            }
        }

        public virtual void skinPanel_ColorChanged(HSLColor hsl, Color color)
        {
            this.BackgroundImage = null;
            this.BackColor = color;
            try
            {
                Settings.Default.skinColor = color;
                Settings.Default.skinPic = null;
                Settings.Default.Save();
            }
            catch { }
          //  this.childForm.BackColor = color;
            //this.childForm.BackgroundImage = null;
            MyFormTemp.CurrentBackgroundColor = color;
            MyFormTemp.CurrentBackgroundImage = null;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x00A1 || m.Msg == 0x00A4 || m.Msg == 0x00A7)   //按下鼠标左键右键中键(非客户区)
            {
                skinForm.Visible = false;
                base.WndProc(ref m);
            }
            else
                base.WndProc(ref m);
        }

        #region 绘制
        protected override void DrawBackground(PaintEventArgs e)
        {
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            BufferedGraphics myBuffer = currentContext.Allocate(e.Graphics, e.ClipRectangle);
            Graphics g = myBuffer.Graphics;
            g.Clear(this.BackColor);

            if (this.BackgroundImage != null)
            {
                g.DrawImage(this.BackgroundImage,new Rectangle(0,0,this.Width,this.Height));
            }
            int titleHeight = 130;
            Bitmap Bmp = global::FYJ.Winform.Properties.Resources.main_form_bg;

            g.DrawImage(Bmp, new Rectangle(0, 0, 5, titleHeight), 0, 0, 5, titleHeight, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, 0, this.Width - 10, titleHeight), 5, 0, Bmp.Width - 10, titleHeight, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, 0, 5, titleHeight), Bmp.Width - 5, 0, 5, titleHeight, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, titleHeight, 2, 25), 0, titleHeight, 2, 25, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(2, titleHeight, this.Width - 4, 25), 2, titleHeight, 5, 25, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 2, titleHeight, 2, 25), Bmp.Width - 2, titleHeight, 2, 25, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, titleHeight + 25, 5, Height - titleHeight - 34 - 25), 0, titleHeight + 25, 5, Bmp.Height - 34 - 25 - titleHeight - 20, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, titleHeight + 25, this.Width - 10, Height - titleHeight - 34 - 25), 5, titleHeight + 25, Bmp.Width - 10, Bmp.Height - 34 - 25 - titleHeight - 20, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, titleHeight + 25, 5, Height - titleHeight - 34 - 25), Bmp.Width - 5, titleHeight + 25, 5, Bmp.Height - 34 - 25 - titleHeight - 20, GraphicsUnit.Pixel);

            //底部
            g.DrawImage(Bmp, new Rectangle(0, this.Height - 34, 5, 34), 0, Bmp.Height - 34, 5, 34, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, this.Height - 34, this.Width - 10, 34), 5, Bmp.Height - 34, Bmp.Width - 10, 34, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, this.Height - 34, 5, 34), Bmp.Width - 5, Bmp.Height - 34, 5, 34, GraphicsUnit.Pixel);
            int strX = 10;
            if (this.ShowIcon)
            {
                strX = 30;
                g.DrawIcon(Icon, new Rectangle(8, 7, 16, 16));
            }
            if (!String.IsNullOrEmpty(this.Text))
            {
                g.DrawString(this.Text, new Font("宋体", 11F, FontStyle.Regular), Brushes.WhiteSmoke, strX, 8);
            }
            Bmp.Dispose();

            myBuffer.Render(e.Graphics);
            g.Dispose();
            myBuffer.Dispose();//释放资源
        }
        #endregion

        #region  拖放图片作为背景
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
            drgevent.Effect = DragDropEffects.Move;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            if (drgevent.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                String[] files = (String[])drgevent.Data.GetData(DataFormats.FileDrop);

                List<String> tempList = new List<string>();
                foreach (String s in files)
                {
                    if (File.Exists(s))
                    {
                        if (s.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase)
                            || s.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase)
                            || s.EndsWith(".bmp", StringComparison.CurrentCultureIgnoreCase))
                        {
                            this.BackgroundImage = Image.FromFile(s);
                            MyFormTemp.CurrentBackgroundImage = this.BackgroundImage;
                        }
                    }

                    //if (Directory.Exists(s))
                    //{
                    //    foreach (String f in Directory.GetFiles(s))
                    //    {
                    //        tempList.Add(f);
                    //    }
                    //}
                }

            }
        }

        #endregion

    }
}
