using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CSharpWin
{
    /* 作者：Starts_2000
     * 日期：2010-01-25
     * 网站：http://www.csharpwin.com CS 程序员之窗。
     * 你可以免费使用或修改以下代码，但请保留版权信息。
     * 具体请查看 CS程序员之窗开源协议（http://www.csharpwin.com/csol.html）。
     */

    public class TrackBarColorTable
    {
        private static readonly Color _trackBegin = Color.FromArgb(120, 120, 120);
        private static readonly Color _trackEnd = Color.FromArgb(255, 255, 255);
        private static readonly Color _trackBorder = Color.FromArgb(109, 109, 109);
        private static readonly Color _trackInnerBorder = Color.FromArgb(200, 250, 250, 250);
        private static readonly Color _thumbBackNormal = Color.FromArgb(200, 193, 227, 247);
        private static readonly Color _thumbBackHover = Color.FromArgb(200, 50, 162, 228);
        private static readonly Color _thumbBackPressed = Color.FromArgb(200, 50, 162, 228);
        private static readonly Color _thumbBorderNormal = Color.FromArgb(103, 165, 216);
        private static readonly Color _thumbBorderHover = Color.FromArgb(70, 146, 207);
        private static readonly Color _tickLight = Color.FromArgb(233, 238, 238);
        private static readonly Color _tickDark = Color.FromArgb(197, 197, 197);

        public TrackBarColorTable() { }

        public virtual Color TrackBegin
        {
            get { return _trackBegin; }
        }

        public virtual Color TrackEnd
        {
            get { return _trackEnd; }
        }

        public virtual Color TrackBorder
        {
            get { return _trackBorder; }
        }

        public virtual Color TrackInnerBorder
        {
            get { return _trackInnerBorder; }
        }

        public virtual Color ThumbBackNormal
        {
            get { return _thumbBackNormal; }
        }

        public virtual Color ThumbBackHover
        {
            get { return _thumbBackHover; }
        }

        public virtual Color ThumbBackPressed
        {
            get { return _thumbBackPressed; }
        }

        public virtual Color ThumbBorderNormal
        {
            get { return _thumbBorderNormal; }
        }

        public virtual Color ThumbBorderHover
        {
            get { return _thumbBorderHover; }
        }

        public virtual Color TickLight
        {
            get { return _tickLight; }
        }

        public virtual Color TickDark
        {
            get { return _tickDark; }
        }
    }
}
