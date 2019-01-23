using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK3_KrzyweBeziera
{
    public partial class Form1 : Form
    {
        private BeziersCurve _beziersCurve;
        private bool _start = true;
        private ChangeableImage _chImage;
        private Timer _imgTimer = new Timer();
        private Bitmap _currentBitmap;
        private bool _timeToSwap = false;
        public Form1()
        {
            InitializeComponent();
            _currentBitmap = new Bitmap(_mainCanvas.Width, _mainCanvas.Height);
            _beziersCurve = new BeziersCurve(_mainCanvas.Width, _mainCanvas.Height);
            _chImage = new ChangeableImage(_beziersCurve._curvePoints, _mainCanvas.Width, _mainCanvas.Height, _beziersCurve._factors);
            _imgLabel.Image = new Bitmap(_chImage.set_getImg,50,50);
            _imgTimer.Tick += new EventHandler(modifyImg);
            _imgTimer.Interval = 200;
            _mainCanvas.Invalidate();
        }

        private void modifyImg(object sender, EventArgs e)
        {
            if (_movingRB.Checked)
                _chImage.pushImage();
            else
                _chImage.rotate();
            _mainCanvas.Invalidate();
            _start = false;
        }

        private void refresh(object sender, PaintEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(_currentBitmap))
            {
                g.Clear(Color.White);
                if (_start || _timeToSwap)
                {
                    _beziersCurve.drawCurve(g, true);
                    
                }
                else
                    _beziersCurve.drawCurve(g);
                if(_naiveRB.Checked)
                    _chImage.drawNaiveImage(_currentBitmap);
                else
                    _chImage.drawWithFiltering(_currentBitmap);
            }
            e.Graphics.DrawImage(_currentBitmap, 0, 0);
        }

        private void startClick(object sender, EventArgs e)
        {
            _chImage.zeroAngle();
            _imgTimer.Start();
        }

        private void _chImgBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "image file (*.png)|*.png|(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _chImage.set_getImg = new Bitmap(Image.FromStream(ofd.OpenFile()), 100, 100);
                _imgLabel.Image = new Bitmap(_chImage.set_getImg,50,50);
                _mainCanvas.Invalidate();
            }
            ofd.Dispose();
        }

        private void swapVerticle(object sender, MouseEventArgs e)
        {
            if (_timeToSwap)
            {
                _beziersCurve.swap(e.Location);
                _mainCanvas.Invalidate();
            }
        }

        private void freeVerticle(object sender, MouseEventArgs e)
        {
            _timeToSwap = false;
        }

        private void clickVerticle(object sender, MouseEventArgs e)
        {
            if (_beziersCurve.clickVerticle(e))
                _timeToSwap = true;
        }

        private void _stopBtn_Click(object sender, EventArgs e)
        {
            _imgTimer.Stop();
        }

        private void _negativeBtn_Click(object sender, EventArgs e)
        {
            _chImage.negative();
            _mainCanvas.Invalidate();
        }
    }
}
