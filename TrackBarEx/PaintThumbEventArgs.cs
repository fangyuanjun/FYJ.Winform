using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpWin
{
    /* 作者：Starts_2000
     * 日期：2010-01-25
     * 网站：http://www.csharpwin.com CS 程序员之窗。
     * 你可以免费使用或修改以下代码，但请保留版权信息。
     * 具体请查看 CS程序员之窗开源协议（http://www.csharpwin.com/csol.html）。
     */

    public class PaintThumbEventArgs : PaintEventArgs
    {
        private ControlState _controlState;

        public ControlState ControlState
        {
            get { return _controlState; }
        }

        public PaintThumbEventArgs(
            Graphics g, Rectangle clipRect, ControlState state)
            : base(g, clipRect)
        {
            _controlState = state;
        }
    }
}
