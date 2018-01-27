using System;
using System.Collections.Generic;
using System.Text;
using FYJ.Winform.Forms;

namespace FYJ.Winform.Controls
{
   public class CommonButton :BaseButton
    {
       public CommonButton()
       {

           this.BackgroundImage = global::FYJ.Winform.Properties.Resources.btn_normal;
           this.Location = new System.Drawing.Point(205, 148);
           this.MouseDownImage = global::FYJ.Winform.Properties.Resources.btn_down;
           this.MouseEnterImage = global::FYJ.Winform.Properties.Resources.btn_highlight;
           this.MouseNormalImage = global::FYJ.Winform.Properties.Resources.btn_normal;
           this.DisabledImage = global::FYJ.Winform.Properties.Resources.btn_disabled;
           this.Size = new System.Drawing.Size(69, 21);
         
       }

      
    }
}
