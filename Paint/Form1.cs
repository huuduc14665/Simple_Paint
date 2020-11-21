using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        
        Bitmap bmp;
        Graphics gp;
        Graphics gptemp;
        string selected;
        bool multiclicking;
        bool multiselecting;
        Point preLocation;
        int selectedIndex;

        bool isStart = false;
        public abstract class clsDrawObjec
        {
            private int startAngle;

            public int StartAngle
            {
                get { return startAngle; }
                set { startAngle = value; }
            }
            private int sweepAngle;

            public int SweepAngle
            {
                get { return sweepAngle; }
                set { sweepAngle = value; }
            }

            private List<Point> listPoint;

            public List<Point> ListPoint
            {
                get { return listPoint; }
                set { listPoint = value; }
            }
            private Pen myPen;

            public Pen MyPen
            {
                get { return myPen; }
                set { myPen = value; }
            }


            private SolidBrush myBrush;

            public SolidBrush MyBrush
            {
                get { return myBrush; }
                set { myBrush = value; }
            }
            private bool filled;

            public bool Filled
            {
                get { return filled; }
                set { filled = value; }
            }
            private bool isSelected;

            public bool IsSelected
            {
                get { return isSelected; }
                set { isSelected = value; }
            }
            private List<clsDrawObjec> myObjs;

            public List<clsDrawObjec> MyObjs
            {
                get { return myObjs; }
                set { myObjs = value; }
            }


            public abstract void Draw(Graphics gp);
            public abstract bool HitTest(Point Pt);
            public abstract void Selected(Graphics gp);
            public abstract void Move(Point start, Point dest);
            public abstract void Zoom(double scale);
        }
        public class clsLine : clsDrawObjec
        {
            public override void Draw(Graphics gp)
            {
                gp.DrawLine(MyPen, ListPoint[0], ListPoint[1]);
            }
            public override bool HitTest(Point Pt)
            {
                if ((Pt.X < ListPoint[0].X && Pt.X < ListPoint[1].X) || (Pt.X > ListPoint[0].X && Pt.X > ListPoint[1].X) ||
                    (Pt.Y < ListPoint[0].Y && Pt.Y < ListPoint[1].Y) || (Pt.Y > ListPoint[0].Y && Pt.Y > ListPoint[1].Y))
                    return false;
                return true;
            }
            public override void Selected(Graphics gp)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Pen newPen = new Pen(Color.Black, 1);
                newPen.DashStyle = DashStyle.Dash;
                gp.DrawRectangle(newPen, min.X, min.Y, max.X - min.X, max.Y - min.Y);
            }
            public override void Move(Point start, Point dest)
            {
                int dx = dest.X - start.X;
                int dy = dest.Y - start.Y;
                for (int i = 0; i < ListPoint.Count; i++)
                {
                    Point newPos = new Point(ListPoint[i].X + dx, ListPoint[i].Y + dy);
                    ListPoint[i] = newPos;
                }
            }
            public override void Zoom(double scale)
            {
                Point min = ListPoint[0];
                Point max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Point Center = new Point();
                Center.X = min.X + (max.X - min.X) / 2;
                Center.Y = min.Y + (max.Y - min.Y) / 2;
                for (int k = 0; k < ListPoint.Count; k++)
                {
                    int dx = Center.X - ListPoint[k].X;
                    int dy = Center.Y - ListPoint[k].Y;
                    ListPoint[k] = new Point(Center.X - (int)(dx * scale), Center.Y - (int)(dy * scale));
                }
            }
        }
        public class clsElipse : clsDrawObjec
        {
            public override void Draw(Graphics gp)
            {
                if (Filled == true)
                    gp.FillEllipse(MyBrush, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[1].Y - ListPoint[0].Y);
                else
                    gp.DrawEllipse(MyPen, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[1].Y - ListPoint[0].Y);
            }
            public override bool HitTest(Point Pt)
            {
                if ((Pt.X < ListPoint[0].X && Pt.X < ListPoint[1].X) || (Pt.X > ListPoint[0].X && Pt.X > ListPoint[1].X) ||
                    (Pt.Y < ListPoint[0].Y && Pt.Y < ListPoint[1].Y) || (Pt.Y > ListPoint[0].Y && Pt.Y > ListPoint[1].Y))
                    return false;
                return true;
            }
            public override void Selected(Graphics gp)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Pen newPen = new Pen(Color.Black, 1);
                newPen.DashStyle = DashStyle.Dash;
                gp.DrawRectangle(newPen, min.X, min.Y, max.X - min.X, max.Y - min.Y);
            }
            public override void Move(Point start, Point dest)
            {
                int dx = dest.X - start.X;
                int dy = dest.Y - start.Y;
                for (int i = 0; i < ListPoint.Count; i++)
                {
                    Point newPos = new Point(ListPoint[i].X + dx, ListPoint[i].Y + dy);
                    ListPoint[i] = newPos;
                }
            }
            public override void Zoom(double scale)
            {
                Point min = ListPoint[0];
                Point max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Point Center = new Point();
                Center.X = min.X + (max.X - min.X) / 2;
                Center.Y = min.Y + (max.Y - min.Y) / 2;
                for (int k = 0; k < ListPoint.Count; k++)
                {
                    int dx = Center.X - ListPoint[k].X;
                    int dy = Center.Y - ListPoint[k].Y;
                    ListPoint[k] = new Point(Center.X - (int)(dx*scale), Center.Y - (int)(dy*scale));
                }
            }
        }
        public class clsRectangle:clsDrawObjec
        {
            public override void Draw(Graphics gp)
            { 
                if(ListPoint[1].X>= ListPoint[0].X && ListPoint[1].Y<= ListPoint[0].Y)//goc phan tu thu nhat
                {
                    if (Filled == true)
                        gp.FillRectangle(MyBrush, ListPoint[0].X, ListPoint[1].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[0].Y - ListPoint[1].Y);
                    else
                        gp.DrawRectangle(MyPen, ListPoint[0].X, ListPoint[1].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[0].Y - ListPoint[1].Y);
                }
                if (ListPoint[1].X<= ListPoint[0].X && ListPoint[1].Y<= ListPoint[0].Y)//goc phan tu thu hai
                {
                    if (Filled == true)
                        gp.FillRectangle(MyBrush, ListPoint[1].X, ListPoint[1].Y, ListPoint[0].X - ListPoint[1].X, ListPoint[0].Y - ListPoint[1].Y);
                    else
                        gp.DrawRectangle(MyPen, ListPoint[1].X, ListPoint[1].Y, ListPoint[0].X - ListPoint[1].X, ListPoint[0].Y - ListPoint[1].Y);
                }
                if(ListPoint[1].X<= ListPoint[0].X && ListPoint[1].Y>= ListPoint[0].Y)//goc phan tu thu ba
                {
                    if (Filled == true)
                        gp.FillRectangle(MyBrush, ListPoint[1].X, ListPoint[0].Y, ListPoint[0].X - ListPoint[1].X, ListPoint[1].Y - ListPoint[0].Y);
                    else
                        gp.DrawRectangle(MyPen, ListPoint[1].X, ListPoint[0].Y, ListPoint[0].X - ListPoint[1].X, ListPoint[1].Y - ListPoint[0].Y);
                }
                else
                {
                    if (Filled == true)
                        gp.FillRectangle(MyBrush, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[1].Y - ListPoint[0].Y);
                    else
                        gp.DrawRectangle(MyPen, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[1].Y - ListPoint[0].Y);
                }              
            }
            public override bool HitTest(Point Pt)
            {
                if ((Pt.X < ListPoint[0].X && Pt.X < ListPoint[1].X) || (Pt.X > ListPoint[0].X && Pt.X > ListPoint[1].X) ||
                    (Pt.Y < ListPoint[0].Y && Pt.Y < ListPoint[1].Y) || (Pt.Y > ListPoint[0].Y && Pt.Y > ListPoint[1].Y))
                    return false;
                return true;
            }
            public override void Selected(Graphics gp)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Pen newPen = new Pen(Color.CornflowerBlue, 2);
                newPen.DashStyle = DashStyle.Dash;
                gp.DrawRectangle(newPen, min.X, min.Y, max.X - min.X, max.Y - min.Y);
            }
            public override void Move(Point start, Point dest)
            {
                int dx = dest.X - start.X;
                int dy = dest.Y - start.Y;
                for (int i = 0; i < ListPoint.Count; i++)
                {
                    Point newPos = new Point(ListPoint[i].X + dx, ListPoint[i].Y + dy);
                    ListPoint[i] = newPos;
                }
            }
            public override void Zoom(double scale)
            {
                Point min = ListPoint[0];
                Point max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Point Center = new Point();
                Center.X = min.X + (max.X - min.X) / 2;
                Center.Y = min.Y + (max.Y - min.Y) / 2;
                for (int k = 0; k < ListPoint.Count; k++)
                {
                    int dx = Center.X - ListPoint[k].X;
                    int dy = Center.Y - ListPoint[k].Y;
                    ListPoint[k] = new Point(Center.X - (int)(dx * scale), Center.Y - (int)(dy * scale));
                }
            }
        }
        public class clsCircle : clsDrawObjec
        {
            public override void Draw(Graphics gp)
            {
                if (ListPoint[1].X >= ListPoint[0].X && ListPoint[1].Y <= ListPoint[0].Y)//goc phan tu thu nhat
                {
                    if (Filled == true)
                        gp.FillEllipse(MyBrush, ListPoint[0].X, ListPoint[0].Y - (ListPoint[1].X - ListPoint[0].X), ListPoint[1].X - ListPoint[0].X, ListPoint[1].X - ListPoint[0].X);
                    else
                        gp.DrawEllipse(MyPen, ListPoint[0].X, ListPoint[0].Y - (ListPoint[1].X - ListPoint[0].X), ListPoint[1].X - ListPoint[0].X, ListPoint[1].X - ListPoint[0].X);
                }
                else
                {
                    if (ListPoint[1].X <= ListPoint[0].X && ListPoint[1].Y >= ListPoint[0].Y)//goc phan tu thu ba
                    {
                        if (Filled == true)
                            gp.FillEllipse(MyBrush, ListPoint[1].X, ListPoint[0].Y, ListPoint[0].X - ListPoint[1].X, ListPoint[0].X - ListPoint[1].X);
                        else
                            gp.DrawEllipse(MyPen, ListPoint[1].X, ListPoint[0].Y, ListPoint[0].X - ListPoint[1].X, ListPoint[0].X - ListPoint[1].X);
                    }
                    else
                    {
                        if (Filled == true)
                            gp.FillEllipse(MyBrush, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[1].X - ListPoint[0].X);
                        else
                            gp.DrawEllipse(MyPen, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[1].X - ListPoint[0].X);
                    }
                }
            }
            public override bool HitTest(Point Pt)
            {
                if (ListPoint[1].X >= ListPoint[0].X && ListPoint[1].Y <= ListPoint[0].Y)//goc phan tu thu nhat
                    {
                    if ((Pt.X < ListPoint[0].X && Pt.X < ListPoint[1].X) || (Pt.X > ListPoint[0].X && Pt.X > ListPoint[1].X) ||
                            (Pt.Y < ListPoint[0].Y && Pt.Y < ListPoint[0].Y - (ListPoint[1].X - ListPoint[0].X)) || (Pt.Y > ListPoint[0].Y && Pt.Y > ListPoint[0].Y - (ListPoint[1].X - ListPoint[0].X)))
                        return false;
                    }
                else
                {
                    if (ListPoint[1].X <= ListPoint[0].X && ListPoint[1].Y <= ListPoint[0].Y) //goc phan tu thu hai
                    {
                        if ((Pt.X < ListPoint[0].X && Pt.X < ListPoint[1].X) || (Pt.X > ListPoint[0].X && Pt.X > ListPoint[1].X) ||
                            (Pt.Y < ListPoint[0].Y && Pt.Y < ListPoint[0].Y - (ListPoint[0].X - ListPoint[1].X)) || (Pt.Y > ListPoint[0].Y && Pt.Y > ListPoint[0].Y - (ListPoint[0].X - ListPoint[1].X)))
                            return false;
                    }      
                    else
                    {
                        if (ListPoint[1].X <= ListPoint[0].X && ListPoint[1].Y >= ListPoint[0].Y)//goc phan tu thu ba
                            {
                                if ((Pt.X < ListPoint[0].X && Pt.X < ListPoint[1].X) || (Pt.X > ListPoint[0].X && Pt.X > ListPoint[1].X) ||
                                (Pt.Y < ListPoint[0].Y && Pt.Y < ListPoint[0].Y + (ListPoint[0].X - ListPoint[1].X)) || (Pt.Y > ListPoint[0].Y && Pt.Y > ListPoint[0].Y + (ListPoint[0].X - ListPoint[1].X)))
                                    return false;
                            }
                        else
                         if ((Pt.X < ListPoint[0].X && Pt.X < ListPoint[1].X) || (Pt.X > ListPoint[0].X && Pt.X > ListPoint[1].X) ||
                           (Pt.Y < ListPoint[0].Y && Pt.Y < ListPoint[0].Y + (ListPoint[1].X - ListPoint[0].X)) || (Pt.Y > ListPoint[0].Y && Pt.Y > ListPoint[0].Y + (ListPoint[1].X - ListPoint[0].X)))
                            return false;
                    }
                }
                   
                      
                return true;
            }
            public override void Selected(Graphics gp)
            {
                Pen newPen = new Pen(Color.Black, 1);
                newPen.DashStyle = DashStyle.Dash;
                if (ListPoint[1].X >= ListPoint[0].X && ListPoint[1].Y <= ListPoint[0].Y)//goc phan tu thu nhat
                    gp.DrawRectangle(newPen, ListPoint[0].X, ListPoint[0].Y - (ListPoint[1].X-ListPoint[0].X), ListPoint[1].X - ListPoint[0].X, ListPoint[1].X - ListPoint[0].X);
                else
                {
                    if (ListPoint[1].X <= ListPoint[0].X && ListPoint[1].Y <= ListPoint[0].Y)//goc phan tu thu hai
                        gp.DrawRectangle(newPen, ListPoint[1].X, ListPoint[0].Y - (ListPoint[0].X - ListPoint[1].X), ListPoint[0].X - ListPoint[1].X, ListPoint[0].X - ListPoint[1].X);
                    else
                    {
                        if (ListPoint[1].X <= ListPoint[0].X && ListPoint[1].Y >= ListPoint[0].Y)//goc phan tu thu ba
                            gp.DrawRectangle(newPen, ListPoint[1].X, ListPoint[0].Y, ListPoint[0].X - ListPoint[1].X, ListPoint[0].X - ListPoint[1].X);
                        else
                            gp.DrawRectangle(newPen, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X - ListPoint[0].X, ListPoint[1].X - ListPoint[0].X);
                    }

                }
            }
            public override void Move(Point start, Point dest)
            {
                int dx = dest.X - start.X;
                int dy = dest.Y - start.Y;
                for (int i = 0; i < ListPoint.Count; i++)
                {
                    Point newPos = new Point(ListPoint[i].X + dx, ListPoint[i].Y + dy);
                    ListPoint[i] = newPos;
                }
            }
            public override void Zoom(double scale)
            {
                Point min = ListPoint[0];
                Point max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Point Center = new Point();
                Center.X = min.X + (max.X - min.X) / 2;
                Center.Y = min.Y + (max.Y - min.Y) / 2;
                for (int k = 0; k < ListPoint.Count; k++)
                {
                    int dx = Center.X - ListPoint[k].X;
                    int dy = Center.Y - ListPoint[k].Y;
                    ListPoint[k] = new Point(Center.X - (int)(dx * scale), Center.Y - (int)(dy * scale));
                }
            }
        }
        public class clsPolygon : clsDrawObjec
        {
            public override void Draw(Graphics gp)
            {
                if (Filled == true)
                    gp.FillPolygon(MyBrush, ListPoint.ToArray());
                else
                    gp.DrawPolygon(MyPen, ListPoint.ToArray());
            }
            public override bool HitTest(Point Pt)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                if ((Pt.X < min.X && Pt.X < max.X) || (Pt.X > min.X && Pt.X > max.X) ||
                    (Pt.Y < min.Y && Pt.Y < max.Y) || (Pt.Y > min.Y && Pt.Y > max.Y))
                    return false;
                return true;
            }
            public override void Selected(Graphics gp)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Pen newPen = new Pen(Color.Black, 1);
                newPen.DashStyle = DashStyle.Dash;
                gp.DrawRectangle(newPen, min.X, min.Y, max.X - min.X, max.Y - min.Y);
            }
            public override void Move(Point start, Point dest)
            {
                int dx = dest.X - start.X;
                int dy = dest.Y - start.Y;
                for (int i = 0; i < ListPoint.Count; i++)
                {
                    Point newPos = new Point(ListPoint[i].X + dx, ListPoint[i].Y + dy);
                    ListPoint[i] = newPos;
                }
            }
            public override void Zoom(double scale)
            {
                Point min = ListPoint[0];
                Point max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Point Center = new Point();
                Center.X = min.X + (max.X - min.X) / 2;
                Center.Y = min.Y + (max.Y - min.Y) / 2;
                for (int k = 0; k < ListPoint.Count; k++)
                {
                    int dx = Center.X - ListPoint[k].X;
                    int dy = Center.Y - ListPoint[k].Y;
                    ListPoint[k] = new Point(Center.X - (int)(dx * scale), Center.Y - (int)(dy * scale));
                }
            }
        }
        public class clsCurve : clsDrawObjec
        {
            public override void Draw(Graphics gp)
            {
                gp.DrawCurve(MyPen, ListPoint.ToArray());
            }
            public override bool HitTest(Point Pt)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                if ((Pt.X < min.X && Pt.X < max.X) || (Pt.X > min.X && Pt.X > max.X) ||
                    (Pt.Y < min.Y && Pt.Y < max.Y) || (Pt.Y > min.Y && Pt.Y > max.Y))
                    return false;
                return true;
            }
            public override void Selected(Graphics gp)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Pen newPen = new Pen(Color.Black, 1);
                newPen.DashStyle = DashStyle.Dash;
                gp.DrawRectangle(newPen, min.X, min.Y, max.X - min.X, max.Y - min.Y);
            }
            public override void Move(Point start, Point dest)
            {
                int dx = dest.X - start.X;
                int dy = dest.Y - start.Y;
                for (int i = 0; i < ListPoint.Count; i++)
                {
                    Point newPos = new Point(ListPoint[i].X + dx, ListPoint[i].Y + dy);
                    ListPoint[i] = newPos;
                }
            }
            public override void Zoom(double scale)
            {
                Point min = ListPoint[0];
                Point max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Point Center = new Point();
                Center.X = min.X + (max.X - min.X) / 2;
                Center.Y = min.Y + (max.Y - min.Y) / 2;
                for (int k = 0; k < ListPoint.Count; k++)
                {
                    int dx = Center.X - ListPoint[k].X;
                    int dy = Center.Y - ListPoint[k].Y;
                    ListPoint[k] = new Point(Center.X - (int)(dx * scale), Center.Y - (int)(dy * scale));
                }
            }
        }
        public class clsArc : clsDrawObjec
        {
            public override void Draw(Graphics gp)
            {
                 if (ListPoint[1].X >= ListPoint[0].X && ListPoint[1].Y <= ListPoint[0].Y)//goc phan tu thu nhat
                 {
                    gp.DrawArc(MyPen, ListPoint[0].X, ListPoint[1].Y, ListPoint[1].X - ListPoint[0].X + 1, ListPoint[0].Y - ListPoint[1].Y + 1, StartAngle, SweepAngle);
                 }
                else
                {
                    if (ListPoint[1].X <= ListPoint[0].X && ListPoint[1].Y <= ListPoint[0].Y)//goc phan tu thu hai
                    {
                        gp.DrawArc(MyPen, ListPoint[1].X, ListPoint[1].Y, ListPoint[0].X - ListPoint[1].X + 1, ListPoint[0].Y - ListPoint[1].Y + 1, StartAngle, SweepAngle);
                    }
                    else
                    {
                        if (ListPoint[1].X <= ListPoint[0].X && ListPoint[1].Y >= ListPoint[0].Y)//goc phan tu thu ba
                            gp.DrawArc(MyPen, ListPoint[1].X, ListPoint[0].Y, ListPoint[0].X - ListPoint[1].X + 1, ListPoint[1].Y - ListPoint[0].Y + 1, StartAngle, SweepAngle);
                        else
                            gp.DrawArc(MyPen, ListPoint[0].X, ListPoint[0].Y, ListPoint[1].X - ListPoint[0].X + 1, ListPoint[1].Y - ListPoint[0].Y + 1, StartAngle, SweepAngle);
                    }
                }
            }
            public override bool HitTest(Point Pt)
            {
                if ((Pt.X < ListPoint[0].X && Pt.X < ListPoint[1].X) || (Pt.X > ListPoint[0].X && Pt.X > ListPoint[1].X) ||
                    (Pt.Y < ListPoint[0].Y && Pt.Y < ListPoint[1].Y) || (Pt.Y > ListPoint[0].Y && Pt.Y > ListPoint[1].Y))
                    return false;
                return true;
            }
            public override void Selected(Graphics gp)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Pen newPen = new Pen(Color.Black, 1);
                newPen.DashStyle = DashStyle.Dash;
                gp.DrawRectangle(newPen, min.X, min.Y, max.X - min.X, max.Y - min.Y);
            }
            public override void Move(Point start, Point dest)
            {
                int dx = dest.X - start.X;
                int dy = dest.Y - start.Y;
                for (int i = 0; i < ListPoint.Count; i++)
                {
                    Point newPos = new Point(ListPoint[i].X + dx, ListPoint[i].Y + dy);
                    ListPoint[i] = newPos;
                }
            }
            public override void Zoom(double scale)
            {
                Point min = ListPoint[0];
                Point max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Point Center = new Point();
                Center.X = min.X + (max.X - min.X) / 2;
                Center.Y = min.Y + (max.Y - min.Y) / 2;
                for (int k = 0; k < ListPoint.Count; k++)
                {
                    int dx = Center.X - ListPoint[k].X;
                    int dy = Center.Y - ListPoint[k].Y;
                    ListPoint[k] = new Point(Center.X - (int)(dx * scale), Center.Y - (int)(dy * scale));
                }
            }
        }
        public class clsObjects:clsDrawObjec
        {
            public clsObjects()
            {
                MyObjs = new List<clsDrawObjec>();
                ListPoint = new List<Point>();
            }
            public override void Draw(Graphics gp)
            {
                for (int i=0;i<MyObjs.Count; i++)
                {
                    MyObjs[i].Draw(gp);
                }
            }
            public override bool HitTest(Point Pt)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                if ((Pt.X < min.X && Pt.X < max.X) || (Pt.X > min.X && Pt.X > max.X) ||
                    (Pt.Y < min.Y && Pt.Y < max.Y) || (Pt.Y > min.Y && Pt.Y > max.Y))
                    return false;
                return true;
                
            }
            public override void Selected(Graphics gp)
            {
                Point min, max;
                min = ListPoint[0];
                max = ListPoint[0];
                foreach (Point pt in ListPoint)
                {
                    if (pt.X < min.X)
                        min.X = pt.X;
                    if (pt.X > max.X)
                        max.X = pt.X;
                    if (pt.Y < min.Y)
                        min.Y = pt.Y;
                    if (pt.Y > max.Y)
                        max.Y = pt.Y;
                }
                Pen newPen = new Pen(Color.Black, 1);
                newPen.DashStyle = DashStyle.Dash;
                gp.DrawRectangle(newPen, min.X, min.Y, max.X - min.X, max.Y - min.Y);
            }
            public override void Move(Point start, Point dest)
            {
                for (int i = 0; i < MyObjs.Count; i++)
                    MyObjs[i].Move(start, dest);
                int d = 0;
                for (int i = 0; i < MyObjs.Count; i++)
                    for (int j = 0; j < MyObjs[i].ListPoint.Count; j++)
                        ListPoint[d++] = MyObjs[i].ListPoint[j];
            }
            public override void Zoom(double scale)
            {
                for (int i = 0; i < MyObjs.Count; i++)
                    MyObjs[i].Zoom(scale);
                int d = 0;
                for (int i = 0; i < MyObjs.Count; i++)
                    for (int j = 0; j < MyObjs[i].ListPoint.Count; j++)
                        ListPoint[d++] = MyObjs[i].ListPoint[j];
            }
        }
        List<clsDrawObjec> myList = new List<clsDrawObjec>();


        public Form1()
        {
            InitializeComponent();
            rdBtnPen.Checked = true;
            this.bmp = new Bitmap(plMain.Width, plMain.Height);
            gp = Graphics.FromImage(bmp);
            gptemp = plMain.CreateGraphics();
            this.plMain.Refresh();
            btnDone.Visible = false;
            btnDone2.Visible = false;
            ArcMenu(false);
            SelectMenu(false);
            btnColors.BackColor = colorDialogPen.Color;
            numDoDay.Value = 2;
            cbbDashStyle.Items.Add(DashStyle.Solid);
            cbbDashStyle.Items.Add(DashStyle.Dash);
            cbbDashStyle.Items.Add(DashStyle.Dot);
            cbbDashStyle.Items.Add(DashStyle.DashDot);
            cbbDashStyle.SelectedIndex = 0;
            this.selected = "Line";
            KeyPreview = true;
            selectedIndex = -1;
        }

        private void btnColors_Click(object sender, EventArgs e)
        {
            colorDialogPen.ShowDialog();
            btnColors.BackColor = colorDialogPen.Color;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            selected = "Line";
            btnDone.PerformClick();
            ArcMenu(false);
            SelectMenu(false);
        }

        private void btnEclipse_Click(object sender, EventArgs e)
        {
            selected = "Ellipse";
            btnDone.PerformClick();
            ArcMenu(false);
            SelectMenu(false);
        }

        private void plMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.selected=="Selecting")
            {
                if (this.multiselecting == false)
                {
                    plMain.Refresh();
                    for (int i = 0; i < myList.Count; i++)
                        myList[i].IsSelected = false;
                }
                for (int i = myList.Count - 1; i >= 0; i--) 
                    if (myList[i].HitTest(e.Location) == true)
                    {
                        myList[i].Selected(gptemp);
                        preLocation = e.Location;
                        myList[i].IsSelected = true;
                        selectedIndex = i;
                        break;
                    }
                this.isStart = true;       
            }
            else
            {
                if (multiclicking == false)
                {
                    if (this.selected == "Line")
                    {
                        clsDrawObjec myObj = new clsLine();
                        myObj.ListPoint = new List<Point>();
                        myObj.ListPoint.Add(e.Location);
                        myObj.ListPoint.Add(e.Location);
                        Pen newPen = new Pen(colorDialogPen.Color, Convert.ToInt32(numDoDay.Value));
                        newPen.DashStyle = (DashStyle)cbbDashStyle.SelectedItem;
                        myObj.MyPen = newPen;
                        myObj.IsSelected = false;
                        this.myList.Add(myObj);
                    }
                    if (this.selected == "Ellipse")
                    {
                        clsDrawObjec myObj = new clsElipse();
                        myObj.ListPoint = new List<Point>();
                        myObj.ListPoint.Add(e.Location);
                        myObj.ListPoint.Add(e.Location);
                        if (rdBtnPen.Checked == true)
                        {
                            Pen newPen = new Pen(colorDialogPen.Color, Convert.ToInt32(numDoDay.Value));
                            newPen.DashStyle = (DashStyle)cbbDashStyle.SelectedItem;
                            myObj.MyPen = newPen;
                            myObj.Filled = false;
                        }
                        else
                        {
                            SolidBrush newBrush = new SolidBrush(colorDialogPen.Color);
                            myObj.MyBrush = newBrush;
                            myObj.Filled = true;
                        }
                        this.myList.Add(myObj);
                    }
                    if (this.selected == "Circle")
                    {
                        clsDrawObjec myObj = new clsCircle();
                        myObj.ListPoint = new List<Point>();
                        myObj.ListPoint.Add(e.Location);
                        myObj.ListPoint.Add(e.Location);
                        if (rdBtnPen.Checked == true)
                        {
                            Pen newPen = new Pen(colorDialogPen.Color, Convert.ToInt32(numDoDay.Value));
                            newPen.DashStyle = (DashStyle)cbbDashStyle.SelectedItem;
                            myObj.MyPen = newPen;
                            myObj.Filled = false;
                        }
                        else
                        {
                            SolidBrush newBrush = new SolidBrush(colorDialogPen.Color);
                            myObj.MyBrush = newBrush;
                            myObj.Filled = true;
                        }
                        this.myList.Add(myObj);
                    }
                    if (this.selected == "Rectangle")
                    {
                        clsDrawObjec myObj = new clsRectangle();
                        myObj.ListPoint = new List<Point>();
                        myObj.ListPoint.Add(e.Location);
                        myObj.ListPoint.Add(e.Location);
                        if (rdBtnPen.Checked == true)
                        {
                            Pen newPen = new Pen(colorDialogPen.Color, Convert.ToInt32(numDoDay.Value));
                            newPen.DashStyle = (DashStyle)cbbDashStyle.SelectedItem;
                            myObj.MyPen = newPen;
                            myObj.Filled = false;
                        }
                        else
                        {
                            SolidBrush newBrush = new SolidBrush(colorDialogPen.Color);
                            myObj.MyBrush = newBrush;
                            myObj.Filled = true;
                        }
                        this.myList.Add(myObj);
                    }
                    if (this.selected == "Polygon")
                    {
                        //btnDone.Visible = true;
                        multiclicking = true;
                        clsDrawObjec myObj = new clsPolygon();
                        myObj.ListPoint = new List<Point>();
                        myObj.ListPoint.Add(e.Location);
                        myObj.ListPoint.Add(e.Location);
                        if (rdBtnPen.Checked == true)
                        {
                            Pen newPen = new Pen(colorDialogPen.Color, Convert.ToInt32(numDoDay.Value));
                            newPen.DashStyle = (DashStyle)cbbDashStyle.SelectedItem;
                            myObj.MyPen = newPen;

                            myObj.Filled = false;
                        }
                        else
                        {
                            SolidBrush newBrush = new SolidBrush(colorDialogPen.Color);
                            myObj.MyBrush = newBrush;
                            myObj.Filled = true;
                        }
                        this.myList.Add(myObj);
                    }
                    if (this.selected == "Curve")
                    {
                        //btnDone.Visible = true;
                        multiclicking = true;
                        clsDrawObjec myObj = new clsCurve();
                        myObj.ListPoint = new List<Point>();
                        myObj.ListPoint.Add(e.Location);
                        myObj.ListPoint.Add(e.Location);
                        Pen newPen = new Pen(colorDialogPen.Color, Convert.ToInt32(numDoDay.Value));
                        newPen.DashStyle = (DashStyle)cbbDashStyle.SelectedItem;
                        myObj.MyPen = newPen;
                        myObj.Filled = false;
                        this.myList.Add(myObj);
                    }
                    if (this.selected == "Arc")
                    {
                        clsDrawObjec myObj = new clsArc();
                        myObj.ListPoint = new List<Point>();
                        myObj.ListPoint.Add(e.Location);
                        myObj.ListPoint.Add(e.Location);
                        Pen newPen = new Pen(colorDialogPen.Color, Convert.ToInt32(numDoDay.Value));
                        newPen.DashStyle = (DashStyle)cbbDashStyle.SelectedItem;
                        myObj.MyPen = newPen;
                        myObj.StartAngle = Convert.ToInt32(txtStartAngle.Text);
                        myObj.SweepAngle = Convert.ToInt32(txtSweepAngle.Text);
                        this.myList.Add(myObj);
                    }
                    this.isStart = true;
                }
                else
                {
                    this.isStart = true;
                    if (this.selected == "Curve")
                    {
                        if (e.Location != myList[myList.Count - 1].ListPoint[myList[myList.Count - 1].ListPoint.Count - 1])
                        {
                            if (this.myList[myList.Count - 1].ListPoint.Count > 2)
                                this.myList[myList.Count - 1].ListPoint.Insert(2, e.Location);
                            else
                                this.myList[myList.Count - 1].ListPoint.Insert(1, e.Location);
                        }
                    }
                    else
                    {
                        this.myList[myList.Count - 1].ListPoint.Add(e.Location);
                        plMain.Invalidate();
                    }
                }
            }
        }

        private void plMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isStart == true)
            {
                if (this.selected == "Selecting")
                {
                    if (selectedIndex>-1)
                    {
                        this.myList[selectedIndex].Move(preLocation, e.Location);
                        preLocation = e.Location;
                        this.plMain.Refresh();
                    }
                    
                }
                else
                {
                    if (this.selected == "Curve")
                    {
                        if (this.myList[myList.Count - 1].ListPoint.Count > 3)
                            this.myList[myList.Count - 1].ListPoint[2] = e.Location;
                        else
                            this.myList[myList.Count - 1].ListPoint[1] = e.Location;
                        this.plMain.Invalidate();
                    }
                    else
                    {
                        this.myList[myList.Count - 1].ListPoint[myList[myList.Count - 1].ListPoint.Count - 1] = e.Location;
                        this.plMain.Refresh();
                    }
                }                
            }
            
        }

        private void plMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isStart==true)
            {
                if (this.selected!="Selecting")
                {
                    if (this.multiclicking == false)
                    {
                        this.plMain.Invalidate();
                    }
                    else
                    {
                        btnDone.Visible = true;
                        btnDone2.Visible = true;
                        Point newPos = new Point(e.Location.X - 60, e.Location.Y - 50);
                        btnDone.Location = newPos;

                        if (this.selected == "Curve")
                        {
                            if (this.myList[myList.Count - 1].ListPoint.Count > 3)
                            {
                                multiclicking = false;
                                btnDone.PerformClick();
                                btnDone2.PerformClick();
                                this.plMain.Invalidate();
                            }
                        }
                    }                  
                }
                this.isStart = false;
            }
        }

        private void plMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i < myList.Count; i++)
                myList[i].Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            this.selected = "Rectangle";
            btnDone.PerformClick();
            btnDone2.PerformClick();
            ArcMenu(false);
            SelectMenu(false);
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            this.selected = "Pen";
            ArcMenu(false);
            SelectMenu(false);
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            this.selected = "Curve";
            btnDone.PerformClick();
            btnDone2.PerformClick();
            ArcMenu(false);
            SelectMenu(false);
        }

        private void btnPolyGon_Click(object sender, EventArgs e)
        {
            this.selected = "Polygon";
            btnDone.PerformClick();
            btnDone2.PerformClick();
            ArcMenu(false);
            SelectMenu(false);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            multiclicking = false;
            myList[myList.Count - 1].Draw(gp);
            this.plMain.Invalidate();
            btnDone.Visible = false;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            this.selected = "Circle";
            btnDone.PerformClick();
            btnDone2.PerformClick();
            ArcMenu(false);
            SelectMenu(false);
        }

        private void btnArc_Click(object sender, EventArgs e)
        {
            this.selected = "Arc";
            btnDone.PerformClick();
            btnDone2.PerformClick();
            txtStartAngle.Text = "0";
            txtSweepAngle.Text = "180";
            ArcMenu(true);
            SelectMenu(false);
        }
        public void ArcMenu(bool state)
        {
            lbStartAngle.Visible = state;
            lbSweepAngle.Visible = state;
            txtStartAngle.Visible = state;
            txtSweepAngle.Visible = state;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.selected = "Selecting";
            btnDone.PerformClick();
            btnDone2.PerformClick();
            plMain.PreviewKeyDown += plMain_PreviewKeyDown;
            (plMain as Control).KeyUp += new KeyEventHandler(panelKeyPressEventHandler);
            plMain.Focus();
            SelectMenu(true);
        }
        public void plMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 17)
                this.multiselecting = true;
        }
        public void panelKeyPressEventHandler(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 17)
                this.multiselecting = false; 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            for (int i=0; i<myList.Count;i++)
            {
                if (myList[i].IsSelected == true)
                    myList.Remove(myList[i]);
            }
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].IsSelected == true)
                    myList.Remove(myList[i]);
            }
            plMain.Refresh();
            btnSelect.PerformClick();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            int count = 0;
            clsDrawObjec myObj = new clsObjects();
            for (int i = myList.Count - 1; i >= 0; i--)
                if (myList[i].IsSelected == true)
                    count++;
            if (count>1)
                for (int i = myList.Count - 1; i >= 0; i--)
                {
                    if (myList[i].IsSelected == true)
                    {
                        myObj.MyObjs.Add(myList[i]);
                        for (int j = 0; j < myList[i].ListPoint.Count; j++)
                            myObj.ListPoint.Add(myList[i].ListPoint[j]);
                        myList.RemoveAt(i);
                    }
                }
            if (myObj.MyObjs.Count>0)
                myList.Add(myObj);
            this.isStart = false;
            btnSelect.PerformClick();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {

        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            for (int i=0; i<myList.Count;i++)
                if (myList[i].IsSelected==true)
                {
                    myList[i].Zoom(1.5);
                    plMain.Invalidate();
                }
            btnSelect.PerformClick();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].IsSelected == true)
                {
                    myList[i].Zoom(0.5);
                    plMain.Invalidate();
                }
            btnSelect.PerformClick();
        }
        public void SelectMenu(bool state)
        {
            btnGroup.Enabled = state;
            btnUnGroup.Enabled = state;
            btnXoa.Enabled = state;
            btnZoomIn.Enabled = state;
            btnZoomOut.Enabled = state;
        }

        private void btnUnGroup_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].IsSelected == true)
                {
                    
                    if (myList[i].MyObjs!=null)
                    {
                        myList.Add(myList[i].MyObjs[myList[i].MyObjs.Count - 1]);
                        myList[i].MyObjs.RemoveAt(myList[i].MyObjs.Count - 1);
                        if (myList[i].MyObjs.Count==1)
                        {
                            myList.Add(myList[i].MyObjs[myList[i].MyObjs.Count - 1]);
                            myList[i].MyObjs.RemoveAt(myList[i].MyObjs.Count - 1);
                            myList.RemoveAt(i);
                        }
                        else
                        {
                            myList[i].ListPoint = new List<Point>();
                            for (int k = 0; k < myList[i].MyObjs.Count; k++)
                                for (int l = 0; l < myList[i].MyObjs[k].ListPoint.Count; l++)
                                    myList[i].ListPoint.Add(myList[i].MyObjs[k].ListPoint[l]);
                        }            
                    }
                }
            }
            this.isStart = false;
            btnSelect.PerformClick();
        }

        private void btnDone2_Click(object sender, EventArgs e)
        {
            multiclicking = false;
            myList[myList.Count - 1].Draw(gp);
            this.plMain.Invalidate();
            btnDone2.Visible = false;
        }
    }
}
 