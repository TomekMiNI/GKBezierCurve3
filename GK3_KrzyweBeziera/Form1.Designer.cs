using System;
using System.Windows.Forms;

namespace GK3_KrzyweBeziera
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel _mainPanel;
        private PictureBox _mainCanvas;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this._mainCanvas = new System.Windows.Forms.PictureBox();
            this._animationBox = new System.Windows.Forms.GroupBox();
            this._movingRB = new System.Windows.Forms.RadioButton();
            this._rotationRB = new System.Windows.Forms.RadioButton();
            this._rotatingBox = new System.Windows.Forms.GroupBox();
            this._filterRB = new System.Windows.Forms.RadioButton();
            this._naiveRB = new System.Windows.Forms.RadioButton();
            this._imageBox = new System.Windows.Forms.GroupBox();
            this._imgLabel = new System.Windows.Forms.Label();
            this._chImgBtn = new System.Windows.Forms.Button();
            this._startBtn = new System.Windows.Forms.Button();
            this._stopBtn = new System.Windows.Forms.Button();
            this._negativeBtn = new System.Windows.Forms.Button();
            this._mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainCanvas)).BeginInit();
            this._animationBox.SuspendLayout();
            this._rotatingBox.SuspendLayout();
            this._imageBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainPanel
            // 
            this._mainPanel.ColumnCount = 3;
            this._mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._mainPanel.Controls.Add(this._mainCanvas, 2, 0);
            this._mainPanel.Controls.Add(this._animationBox, 0, 3);
            this._mainPanel.Controls.Add(this._rotatingBox, 0, 2);
            this._mainPanel.Controls.Add(this._imageBox, 0, 1);
            this._mainPanel.Controls.Add(this._startBtn, 0, 4);
            this._mainPanel.Controls.Add(this._stopBtn, 1, 4);
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(0, 0);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.RowCount = 5;
            this._mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mainPanel.Size = new System.Drawing.Size(606, 361);
            this._mainPanel.TabIndex = 0;
            // 
            // _mainCanvas
            // 
            this._mainCanvas.BackColor = System.Drawing.Color.White;
            this._mainCanvas.Location = new System.Drawing.Point(183, 3);
            this._mainCanvas.Name = "_mainCanvas";
            this._mainPanel.SetRowSpan(this._mainCanvas, 5);
            this._mainCanvas.Size = new System.Drawing.Size(420, 355);
            this._mainCanvas.TabIndex = 0;
            this._mainCanvas.TabStop = false;
            this._mainCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.refresh);
            this._mainCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clickVerticle);
            this._mainCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.swapVerticle);
            this._mainCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.freeVerticle);
            // 
            // _animationBox
            // 
            this._mainPanel.SetColumnSpan(this._animationBox, 2);
            this._animationBox.Controls.Add(this._movingRB);
            this._animationBox.Controls.Add(this._rotationRB);
            this._animationBox.Location = new System.Drawing.Point(3, 219);
            this._animationBox.Name = "_animationBox";
            this._animationBox.Size = new System.Drawing.Size(174, 66);
            this._animationBox.TabIndex = 1;
            this._animationBox.TabStop = false;
            this._animationBox.Text = "Animation";
            // 
            // _movingRB
            // 
            this._movingRB.AutoSize = true;
            this._movingRB.Location = new System.Drawing.Point(6, 20);
            this._movingRB.Name = "_movingRB";
            this._movingRB.Size = new System.Drawing.Size(60, 17);
            this._movingRB.TabIndex = 1;
            this._movingRB.TabStop = true;
            this._movingRB.Text = "Moving";
            this._movingRB.UseVisualStyleBackColor = true;
            // 
            // _rotationRB
            // 
            this._rotationRB.AutoSize = true;
            this._rotationRB.Location = new System.Drawing.Point(6, 43);
            this._rotationRB.Name = "_rotationRB";
            this._rotationRB.Size = new System.Drawing.Size(65, 17);
            this._rotationRB.TabIndex = 0;
            this._rotationRB.TabStop = true;
            this._rotationRB.Text = "Rotation";
            this._rotationRB.UseVisualStyleBackColor = true;
            // 
            // _rotatingBox
            // 
            this._mainPanel.SetColumnSpan(this._rotatingBox, 2);
            this._rotatingBox.Controls.Add(this._filterRB);
            this._rotatingBox.Controls.Add(this._naiveRB);
            this._rotatingBox.Location = new System.Drawing.Point(3, 147);
            this._rotatingBox.Name = "_rotatingBox";
            this._rotatingBox.Size = new System.Drawing.Size(174, 66);
            this._rotatingBox.TabIndex = 2;
            this._rotatingBox.TabStop = false;
            this._rotatingBox.Text = "Rotating";
            // 
            // _filterRB
            // 
            this._filterRB.AutoSize = true;
            this._filterRB.Location = new System.Drawing.Point(6, 43);
            this._filterRB.Name = "_filterRB";
            this._filterRB.Size = new System.Drawing.Size(83, 17);
            this._filterRB.TabIndex = 1;
            this._filterRB.TabStop = true;
            this._filterRB.Text = "With filtering";
            this._filterRB.UseVisualStyleBackColor = true;
            // 
            // _naiveRB
            // 
            this._naiveRB.AutoSize = true;
            this._naiveRB.Checked = true;
            this._naiveRB.Location = new System.Drawing.Point(6, 20);
            this._naiveRB.Name = "_naiveRB";
            this._naiveRB.Size = new System.Drawing.Size(53, 17);
            this._naiveRB.TabIndex = 0;
            this._naiveRB.TabStop = true;
            this._naiveRB.Text = "Naive";
            this._naiveRB.UseVisualStyleBackColor = true;
            // 
            // _imageBox
            // 
            this._mainPanel.SetColumnSpan(this._imageBox, 2);
            this._imageBox.Controls.Add(this._negativeBtn);
            this._imageBox.Controls.Add(this._imgLabel);
            this._imageBox.Controls.Add(this._chImgBtn);
            this._imageBox.Location = new System.Drawing.Point(3, 75);
            this._imageBox.Name = "_imageBox";
            this._imageBox.Size = new System.Drawing.Size(174, 66);
            this._imageBox.TabIndex = 3;
            this._imageBox.TabStop = false;
            this._imageBox.Text = "Image";
            // 
            // _imgLabel
            // 
            this._imgLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._imgLabel.Location = new System.Drawing.Point(108, 13);
            this._imgLabel.Name = "_imgLabel";
            this._imgLabel.Size = new System.Drawing.Size(50, 50);
            this._imgLabel.TabIndex = 1;
            // 
            // _chImgBtn
            // 
            this._chImgBtn.Location = new System.Drawing.Point(9, 19);
            this._chImgBtn.Name = "_chImgBtn";
            this._chImgBtn.Size = new System.Drawing.Size(77, 23);
            this._chImgBtn.TabIndex = 0;
            this._chImgBtn.Text = "Change img";
            this._chImgBtn.UseVisualStyleBackColor = true;
            this._chImgBtn.Click += new System.EventHandler(this._chImgBtn_Click);
            // 
            // _startBtn
            // 
            this._startBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._startBtn.Location = new System.Drawing.Point(7, 313);
            this._startBtn.Name = "_startBtn";
            this._startBtn.Size = new System.Drawing.Size(75, 23);
            this._startBtn.TabIndex = 4;
            this._startBtn.Text = "Start";
            this._startBtn.UseVisualStyleBackColor = true;
            this._startBtn.Click += new System.EventHandler(this.startClick);
            // 
            // _stopBtn
            // 
            this._stopBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._stopBtn.Location = new System.Drawing.Point(97, 313);
            this._stopBtn.Name = "_stopBtn";
            this._stopBtn.Size = new System.Drawing.Size(75, 23);
            this._stopBtn.TabIndex = 5;
            this._stopBtn.Text = "Stop";
            this._stopBtn.UseVisualStyleBackColor = true;
            this._stopBtn.Click += new System.EventHandler(this._stopBtn_Click);
            // 
            // _negativeBtn
            // 
            this._negativeBtn.Location = new System.Drawing.Point(9, 43);
            this._negativeBtn.Name = "_negativeBtn";
            this._negativeBtn.Size = new System.Drawing.Size(77, 23);
            this._negativeBtn.TabIndex = 2;
            this._negativeBtn.Text = "Negative";
            this._negativeBtn.UseVisualStyleBackColor = true;
            this._negativeBtn.Click += new System.EventHandler(this._negativeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 361);
            this.Controls.Add(this._mainPanel);
            this.Name = "Form1";
            this.Text = "Bezier\'s curve";
            this._mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainCanvas)).EndInit();
            this._animationBox.ResumeLayout(false);
            this._animationBox.PerformLayout();
            this._rotatingBox.ResumeLayout(false);
            this._rotatingBox.PerformLayout();
            this._imageBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox _animationBox;
        private GroupBox _rotatingBox;
        private GroupBox _imageBox;
        private Button _startBtn;
        private Button _stopBtn;
        private RadioButton _movingRB;
        private RadioButton _rotationRB;
        private Label _imgLabel;
        private Button _chImgBtn;
        private RadioButton _filterRB;
        private RadioButton _naiveRB;
        private Button _negativeBtn;
    }
}

