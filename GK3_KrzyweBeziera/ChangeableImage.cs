using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3_KrzyweBeziera
{
    class ChangeableImage
    {
        private Image _img;
        private List<Point> _curvePoints;
        private List<Point> _factors;
        private int _currInd = 0;
        private int _maxWidth, _maxHeight;
        private Point _center = new Point(50, 50);
        private double angle = 0;
        public ChangeableImage(List<Point> _curvePoints, int _maxWidth, int _maxHeight, List<Point> _factors)
        {
            this._factors = _factors;
            this._maxHeight = _maxHeight;
            this._maxWidth = _maxWidth;
            this._curvePoints = _curvePoints;
            this._img = new Bitmap(Image.FromFile(@"bulbasaur.png", true),100,100);
        }    
        public void zeroAngle()
        {
            angle = 0;
        }
        public void negative()
        {
            for (int i = 0; i < _img.Width; i++)
                for (int j = 0; j < _img.Height; j++)
                    ((Bitmap)_img).SetPixel(i, j, Color.FromArgb(255 - ((Bitmap)_img).GetPixel(i, j).R, 255 - ((Bitmap)_img).GetPixel(i, j).G, 255 - ((Bitmap)_img).GetPixel(i, j).B));
        }
        public Image set_getImg
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
            }
        }
        public void update(List<Point> _curveP, List<Point> _factors)
        {
            this._factors = new List<Point>(_factors);
            _curvePoints = new List<Point>(_curveP);
        }
        public void drawWithFiltering(Bitmap _bmToUpdate)
        {
            //angle = Math.PI / 4;
            double shear = -Math.Tan(angle / 2);
            shearX(_bmToUpdate, shear);
            shearY(_bmToUpdate, shear);
            shearX(_bmToUpdate, shear);
        }
        private void shearX(Bitmap _bmToUpdate, double shear)
        {
            Bitmap src = new Bitmap(_maxWidth, _maxHeight);
            using (Graphics g = Graphics.FromImage(src))
            {
                g.DrawImage(_img, _curvePoints[_currInd].X - 50, _curvePoints[_currInd].Y - 50);
            }
            for (int y = 0; y < _maxHeight; y++)
            {
                double sth = shear * (double)(y + 0.5);
                int ii = (int)Math.Floor(sth);
                float ff = (float)(sth - Math.Truncate(sth));
                if (sth < 0)
                    ff = (float)(Math.Truncate(sth) - sth);
                Color prev_left = Color.Black;
                for (int x = 0; x < _maxWidth - 1; x++)
                {
                    int sx = _maxWidth - 1 - x;
                    int sy = y;
                    //if (sx >= 0 && sx < _maxWidth && sx >= _center.X - 50 && sx < _center.X + 50 && sy >= 0 && sy < _maxHeight && sy >= _center.Y - 50 && sy < _center.Y + 50)
                    //{
                    Color pixel = src.GetPixel(sx, sy);
                    //Color pixel = ((Bitmap)_img).GetPixel(sx - (_center.X - 50), sy - (_center.Y - 50));
                    Color left = optimizeColor((int)(ff * (float)pixel.R), (int)(ff * (float)pixel.G), (int)(ff * (float)pixel.B));
                    pixel = optimizeColor(pixel.R - left.R + prev_left.R, pixel.G - left.G + prev_left.G, pixel.B - left.B + prev_left.B);
                    prev_left = left;
                    _bmToUpdate.SetPixel(sx, sy, pixel);

                }
                if (ii >= 0 && ii < _maxWidth)
                    _bmToUpdate.SetPixel(ii, y, prev_left);
            }
        }
        private void shearY(Bitmap _bmToUpdate, double shear)
        {
            Bitmap src = new Bitmap(_maxHeight, _maxWidth);
            using (Graphics g = Graphics.FromImage(src))
            {
                g.DrawImage(_img, _curvePoints[_currInd].Y - 50, _curvePoints[_currInd].X - 50);
            }
            for (int y = 0; y < _maxWidth; y++)
            {
                double sth = shear * (double)(y + 0.5);
                int ii = (int)Math.Floor(sth);
                float ff = (float)(sth - Math.Truncate(sth));
                if (sth < 0)
                    ff = (float)(Math.Truncate(sth) - sth);
                Color prev_left = Color.Black;
                for (int x = 0; x < _maxHeight - 1; x++)
                {
                    int sx = _maxHeight - 1 - x;
                    int sy = y;
                    //if (sx >= 0 && sx < _maxWidth && sx >= _center.X - 50 && sx < _center.X + 50 && sy >= 0 && sy < _maxHeight && sy >= _center.Y - 50 && sy < _center.Y + 50)
                    //{
                    Color pixel = src.GetPixel(sx, sy);
                    //Color pixel = ((Bitmap)_img).GetPixel(sx - (_center.X - 50), sy - (_center.Y - 50));
                    Color left = optimizeColor((int)(ff * (float)pixel.R), (int)(ff * (float)pixel.G), (int)(ff * (float)pixel.B));
                    pixel = optimizeColor(pixel.R - left.R + prev_left.R, pixel.G - left.G + prev_left.G, pixel.B - left.B + prev_left.B);
                    prev_left = left;
                    _bmToUpdate.SetPixel(sy, sx, pixel);

                }
                if (ii >= 0 && ii < _maxHeight)
                    _bmToUpdate.SetPixel(y, ii, prev_left);
            }
        }
        private Color optimizeColor(int red, int green, int blue)
        {
            if (red < 0)
                red = 0;
            else if (red > 255)
                red = 255;
            if (green < 0)
                green = 0;
            else if (green > 255)
                green = 255;
            if (blue < 0)
                blue = 0;
            else if (blue > 255)
                blue = 255;
            return Color.FromArgb(red, green, blue);
        }
        public void drawNaiveImage(Bitmap _bmToUpdate)
        {
            
            for (int i = 0; i < _maxWidth; i++)
                    for (int j = 0; j < _maxHeight; j++)
                    {
                        double c = Math.Cos(angle);
                        double s = Math.Sin(angle);
                        int sx = _center.X+(int)(c * (double)(i-_center.X) + s * (double)(j-_center.Y));
                        int sy = _center.Y+(int)(-s * (double)(i - _center.X) + c * (double)(j - _center.Y));
                    if (sx >= 0 && sx < _maxWidth && sy >= 0 && sy < _maxHeight) //czy sie miesci w canvasie
                        if (sx >= _center.X - 50 && sx < _center.X + 50)
                            if (sy >= _center.Y - 50 && sy < _center.Y + 50)
                                _bmToUpdate.SetPixel(i, j, ((Bitmap)_img).GetPixel(sx - (_center.X - 50), sy - (_center.Y - 50)));

                }
        }
        public void pushImage()
        {
            _currInd++;
            if (_currInd == _curvePoints.Count - 1)
                _currInd = 0;
            _center = _curvePoints[_currInd];
            angle = Math.Atan2(_factors[_currInd].X, _factors[_currInd].Y);
            angle -= Math.PI / 2;
        }
        public void rotate()
        {
            _center = new Point(_maxWidth / 2, _maxHeight / 2);
            angle += Math.PI/18;
            if (angle == 2*Math.PI)
                angle = 0;
        }
    }
}
