using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FYJ.Winform.Util
{
   public class MyFormTemp
    {
       private static Color _currentBackgroundColor = Color.FromArgb(47, 180, 240);

       public static Image CurrentBackgroundImage
       {
           get;
           set;
       }

       public static Color CurrentBackgroundColor
       {
           get { return _currentBackgroundColor; }
           set { _currentBackgroundColor = value; }
       }

       private static ImageLayout _currentImageLayout=ImageLayout.Stretch;
       public static ImageLayout CurrentImageLayout
       {
           get { return _currentImageLayout; }
           set { _currentImageLayout = value; }
       }

       public static double _opacity = 1;
       public static double DrawOpacity
       {
           get 
           { 
           if (_opacity < 0)
               _opacity = 0;

           if (_opacity > 1)
               _opacity = 1;

           return _opacity;
           }
           set
           {
               _opacity = value;
           }
       }
    }
}
