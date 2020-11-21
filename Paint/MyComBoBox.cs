using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public class MyComboBox : System.Windows.Forms.ComboBox
    {
        public MyComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            //I removed you int startX... endy... stuff, unless you want to keep it for readability there is no need
            Point p1 = new Point(e.Bounds.Left + 5, e.Bounds.Y + 5);
            Point p2 = new Point(e.Bounds.Right - 5, e.Bounds.Y + 5);

            //I am not sure why you would want to call the base.OnDrawItem, feel free to uncomment it if you wish though
            //base.OnDrawItem(e);

            switch (e.Index)
            {
                case 0:
                    using (Pen SolidmyPen = new Pen(e.ForeColor, 2))
                        e.Graphics.DrawLine(SolidmyPen, p1, p2);
                    break;
                case 1:
                    using (Pen DashedPen = new Pen(e.ForeColor, 2))
                    {
                        DashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawLine(DashedPen, p1, p2);
                    }
                    break;
                case 2:
                    using (Pen Dot = new Pen(e.ForeColor, 2))
                    {
                        Dot.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        e.Graphics.DrawLine(Dot, p1, p2);
                    }
                    break;
                case 3:
                    using (Pen DashDot = new Pen(e.ForeColor, 2))
                    {
                        DashDot.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        e.Graphics.DrawLine(DashDot, p1, p2);
                    }
                    break;

            }
        }
    }
}
