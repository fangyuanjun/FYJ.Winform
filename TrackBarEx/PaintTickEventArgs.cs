using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace CSharpWin
{
    /* 作者：Starts_2000
     * 日期：2010-01-25
     * 网站：http://www.csharpwin.com CS 程序员之窗。
     * 你可以免费使用或修改以下代码，但请保留版权信息。
     * 具体请查看 CS程序员之窗开源协议（http://www.csharpwin.com/csol.html）。
     */

    public class PaintTickEventArgs : IDisposable
    {
        private Graphics _graphics;
        private Rectangle _trackRect;
        private IList<float> _tickPosList;

        public PaintTickEventArgs(
            Graphics g, Rectangle trackRect, IList<float> tickPosList)
        {
            _graphics = g;
            _trackRect = trackRect;
            _tickPosList = tickPosList;
        }

        public Graphics Graphics
        {
            get { return _graphics; }
        }

        public Rectangle TrackRect
        {
            get { return _trackRect; }
        }

        public IList<float> TickPosList
        {
            get { return _tickPosList; }
        }

        #region IDisposable 成员

        public virtual void Dispose()
        {
            _graphics = null;
            _tickPosList = null;
        }

        #endregion
    }
}
