using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK3_KrzyweBeziera
{
    class BeziersCurve
    {
        private List<Point> _points;
        public List<Point> _curvePoints;
        public List<Point> _factors;
        private int _width;
        private int _height;
        private int _clickedVerticle = -1;
        public BeziersCurve(int width, int height, List<Point> _points = null)
        {
            _curvePoints = new List<Point>();
            _factors = new List<Point>();
            _width = width;
            _height = height;
            if (_points == null)
                generateRandomPoints();
            else
                this._points = new List<Point>(_points);
        }
        private void generateRandomPoints()
        {
            _points = new List<Point>();
            Random r = new Random();
            for (double i = 0; i < 10; i++)
            {
                _points.Add(new Point(r.Next((int)(i/10*(double)_width), (int)((i+1)/10*(double)_width)), r.Next(_height)));
                //_points.Add(new Point(r.Next((int)((double)_width)), r.Next(_height)));
                //_points.OrderBy(p => p.X).ThenBy(p => p.Y);
            }
        }
        public void drawCurve(Graphics g, bool _needToCalculate = false)
        {
            if (_needToCalculate)
            {
                _curvePoints.Clear();
                calculateCurve();
            }
            for (int i = 0; i < _points.Count - 1; i++)
            {
                g.FillEllipse(Brushes.Red, new Rectangle(_points[i].X - 3, _points[i].Y - 3, 7, 7));
                g.DrawLine(new Pen(Brushes.Gray), _points[i], _points[i + 1]);
            }
            g.FillEllipse(Brushes.Red, new Rectangle(_points.Last().X - 3, _points.Last().Y - 3, 7, 7));
            for (int i = 0; i < _curvePoints.Count - 1; i++)
            {
                g.DrawLine(new Pen(Brushes.Black), _curvePoints[i], _curvePoints[i + 1]);
            }
        }
        private double factorial(int x)
        {
            if (x == 0) return 1;
            return x * factorial(x - 1);
        }
        private double calculateB(int i, int n, double u)
        {
            //n po i
            double _n_po_i = factorial(n) / (factorial(i) * factorial(n - i));
            for (int ind = 0; ind < i; ind++)
                _n_po_i *= u;
            for (int ind = 0; ind < n - i; ind++)
                _n_po_i *= (1 - u);
            return _n_po_i;
        }
        private void calculateCurve()
        {
            _factors.Clear();
            _curvePoints.Clear();
            for (double u = 0; u <= 1; u += 0.01)
            {
                double Px = 0, Py = 0, Cx = 0, Cy = 0;
                for (int i = 0; i < _points.Count; i++)
                {
                    double b = calculateB(i, _points.Count - 1, u);
                    Px += (double)_points[i].X * b;
                    Py += (double)_points[i].Y * b;

                    if (i < _points.Count - 1)
                    {
                        b = calculateB(i, _points.Count - 2, u);
                        Cx += b * (_points.Count-1) * (_points[i + 1].X - _points[i].X);
                        Cy += b * (_points.Count-1) * (_points[i + 1].Y - _points[i].Y);
                    }
                }
                _factors.Add(new Point((int)Cx, (int)Cy));
                _curvePoints.Add(new Point((int)Px, (int)Py));
            }
        }
        public void swap(Point p)
        {
            _points[_clickedVerticle] = p;
        }
        public bool clickVerticle(MouseEventArgs e)
        {
            for(int i=0;i<_points.Count;i++)
            {
                if (Math.Abs(e.Location.X-_points[i].X)<=3 && Math.Abs(e.Location.Y - _points[i].Y) <= 3)
                {
                    _clickedVerticle = i;
                    return true;
                }
            }
            return false;
        }

    }

}
