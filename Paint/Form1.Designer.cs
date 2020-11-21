namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnUnGroup = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cbbDashStyle = new Paint.MyComboBox();
            this.txtSweepAngle = new System.Windows.Forms.TextBox();
            this.txtStartAngle = new System.Windows.Forms.TextBox();
            this.lbStartAngle = new System.Windows.Forms.Label();
            this.lbSweepAngle = new System.Windows.Forms.Label();
            this.btnArc = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnPolyGon = new System.Windows.Forms.Button();
            this.btnCurve = new System.Windows.Forms.Button();
            this.numDoDay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rdBtnPen = new System.Windows.Forms.RadioButton();
            this.rdBtnBrush = new System.Windows.Forms.RadioButton();
            this.btnEclipse = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnColors = new System.Windows.Forms.Button();
            this.colorDialogPen = new System.Windows.Forms.ColorDialog();
            this.plMain = new Paint.DoubleBufferedPanel();
            this.btnDone2 = new System.Windows.Forms.Button();
            this.plButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoDay)).BeginInit();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // plButtons
            // 
            this.plButtons.BackColor = System.Drawing.Color.MistyRose;
            this.plButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plButtons.Controls.Add(this.btnDone2);
            this.plButtons.Controls.Add(this.btnUnGroup);
            this.plButtons.Controls.Add(this.pictureBox2);
            this.plButtons.Controls.Add(this.pictureBox1);
            this.plButtons.Controls.Add(this.btnZoomOut);
            this.plButtons.Controls.Add(this.btnZoomIn);
            this.plButtons.Controls.Add(this.btnGroup);
            this.plButtons.Controls.Add(this.btnXoa);
            this.plButtons.Controls.Add(this.btnSelect);
            this.plButtons.Controls.Add(this.cbbDashStyle);
            this.plButtons.Controls.Add(this.txtSweepAngle);
            this.plButtons.Controls.Add(this.txtStartAngle);
            this.plButtons.Controls.Add(this.lbStartAngle);
            this.plButtons.Controls.Add(this.lbSweepAngle);
            this.plButtons.Controls.Add(this.btnArc);
            this.plButtons.Controls.Add(this.btnCircle);
            this.plButtons.Controls.Add(this.btnPolyGon);
            this.plButtons.Controls.Add(this.btnCurve);
            this.plButtons.Controls.Add(this.numDoDay);
            this.plButtons.Controls.Add(this.label1);
            this.plButtons.Controls.Add(this.rdBtnPen);
            this.plButtons.Controls.Add(this.rdBtnBrush);
            this.plButtons.Controls.Add(this.btnEclipse);
            this.plButtons.Controls.Add(this.btnLine);
            this.plButtons.Controls.Add(this.btnRectangle);
            this.plButtons.Controls.Add(this.btnColors);
            this.plButtons.Location = new System.Drawing.Point(1, 3);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(135, 662);
            this.plButtons.TabIndex = 0;
            // 
            // btnUnGroup
            // 
            this.btnUnGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnUnGroup.Image")));
            this.btnUnGroup.Location = new System.Drawing.Point(67, 218);
            this.btnUnGroup.Name = "btnUnGroup";
            this.btnUnGroup.Size = new System.Drawing.Size(69, 47);
            this.btnUnGroup.TabIndex = 1;
            this.btnUnGroup.Text = "UnGroup";
            this.btnUnGroup.UseVisualStyleBackColor = true;
            this.btnUnGroup.Click += new System.EventHandler(this.btnUnGroup_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(91, 524);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 50);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 524);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 50);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.Location = new System.Drawing.Point(70, 427);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(66, 47);
            this.btnZoomOut.TabIndex = 25;
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.Location = new System.Drawing.Point(-3, 427);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(66, 47);
            this.btnZoomIn.TabIndex = 24;
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnGroup.Image")));
            this.btnGroup.Location = new System.Drawing.Point(0, 218);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(65, 47);
            this.btnGroup.TabIndex = 22;
            this.btnGroup.Text = "Group";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(30, 271);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(67, 53);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Delete";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(71, 165);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(64, 47);
            this.btnSelect.TabIndex = 19;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cbbDashStyle
            // 
            this.cbbDashStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbDashStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDashStyle.FormattingEnabled = true;
            this.cbbDashStyle.Location = new System.Drawing.Point(10, 480);
            this.cbbDashStyle.Name = "cbbDashStyle";
            this.cbbDashStyle.Size = new System.Drawing.Size(121, 23);
            this.cbbDashStyle.TabIndex = 18;
            // 
            // txtSweepAngle
            // 
            this.txtSweepAngle.Location = new System.Drawing.Point(92, 384);
            this.txtSweepAngle.Name = "txtSweepAngle";
            this.txtSweepAngle.Size = new System.Drawing.Size(44, 22);
            this.txtSweepAngle.TabIndex = 17;
            // 
            // txtStartAngle
            // 
            this.txtStartAngle.Location = new System.Drawing.Point(92, 361);
            this.txtStartAngle.Name = "txtStartAngle";
            this.txtStartAngle.Size = new System.Drawing.Size(44, 22);
            this.txtStartAngle.TabIndex = 16;
            // 
            // lbStartAngle
            // 
            this.lbStartAngle.AutoSize = true;
            this.lbStartAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStartAngle.Location = new System.Drawing.Point(0, 364);
            this.lbStartAngle.Name = "lbStartAngle";
            this.lbStartAngle.Size = new System.Drawing.Size(76, 15);
            this.lbStartAngle.TabIndex = 15;
            this.lbStartAngle.Text = "Góc bắt đầu:";
            // 
            // lbSweepAngle
            // 
            this.lbSweepAngle.AutoSize = true;
            this.lbSweepAngle.Location = new System.Drawing.Point(1, 384);
            this.lbSweepAngle.Name = "lbSweepAngle";
            this.lbSweepAngle.Size = new System.Drawing.Size(73, 17);
            this.lbSweepAngle.TabIndex = 14;
            this.lbSweepAngle.Text = "Góc cong:";
            // 
            // btnArc
            // 
            this.btnArc.Image = ((System.Drawing.Image)(resources.GetObject("btnArc.Image")));
            this.btnArc.Location = new System.Drawing.Point(71, 112);
            this.btnArc.Name = "btnArc";
            this.btnArc.Size = new System.Drawing.Size(66, 47);
            this.btnArc.TabIndex = 11;
            this.btnArc.UseVisualStyleBackColor = true;
            this.btnArc.Click += new System.EventHandler(this.btnArc_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnCircle.Image")));
            this.btnCircle.Location = new System.Drawing.Point(0, 112);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(64, 47);
            this.btnCircle.TabIndex = 1;
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(3, 11);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(62, 23);
            this.btnDone.TabIndex = 10;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnPolyGon
            // 
            this.btnPolyGon.Image = ((System.Drawing.Image)(resources.GetObject("btnPolyGon.Image")));
            this.btnPolyGon.Location = new System.Drawing.Point(68, -1);
            this.btnPolyGon.Name = "btnPolyGon";
            this.btnPolyGon.Size = new System.Drawing.Size(66, 47);
            this.btnPolyGon.TabIndex = 9;
            this.btnPolyGon.UseVisualStyleBackColor = true;
            this.btnPolyGon.Click += new System.EventHandler(this.btnPolyGon_Click);
            // 
            // btnCurve
            // 
            this.btnCurve.Image = ((System.Drawing.Image)(resources.GetObject("btnCurve.Image")));
            this.btnCurve.Location = new System.Drawing.Point(-1, 165);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(66, 47);
            this.btnCurve.TabIndex = 8;
            this.btnCurve.UseVisualStyleBackColor = true;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // numDoDay
            // 
            this.numDoDay.Location = new System.Drawing.Point(71, 577);
            this.numDoDay.Name = "numDoDay";
            this.numDoDay.Size = new System.Drawing.Size(47, 22);
            this.numDoDay.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 577);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Độ dày:";
            // 
            // rdBtnPen
            // 
            this.rdBtnPen.AutoSize = true;
            this.rdBtnPen.Location = new System.Drawing.Point(4, 538);
            this.rdBtnPen.Name = "rdBtnPen";
            this.rdBtnPen.Size = new System.Drawing.Size(17, 16);
            this.rdBtnPen.TabIndex = 0;
            this.rdBtnPen.TabStop = true;
            this.rdBtnPen.UseVisualStyleBackColor = true;
            // 
            // rdBtnBrush
            // 
            this.rdBtnBrush.AutoSize = true;
            this.rdBtnBrush.Location = new System.Drawing.Point(70, 538);
            this.rdBtnBrush.Name = "rdBtnBrush";
            this.rdBtnBrush.Size = new System.Drawing.Size(17, 16);
            this.rdBtnBrush.TabIndex = 1;
            this.rdBtnBrush.TabStop = true;
            this.rdBtnBrush.UseVisualStyleBackColor = true;
            // 
            // btnEclipse
            // 
            this.btnEclipse.Image = global::Paint.Properties.Resources.Eclipse;
            this.btnEclipse.Location = new System.Drawing.Point(71, 52);
            this.btnEclipse.Name = "btnEclipse";
            this.btnEclipse.Size = new System.Drawing.Size(65, 47);
            this.btnEclipse.TabIndex = 3;
            this.btnEclipse.UseVisualStyleBackColor = true;
            this.btnEclipse.Click += new System.EventHandler(this.btnEclipse_Click);
            // 
            // btnLine
            // 
            this.btnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLine.Image = global::Paint.Properties.Resources.Line1;
            this.btnLine.Location = new System.Drawing.Point(-1, -1);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(66, 47);
            this.btnLine.TabIndex = 2;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Image = global::Paint.Properties.Resources.Rectangle;
            this.btnRectangle.Location = new System.Drawing.Point(-1, 52);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(66, 47);
            this.btnRectangle.TabIndex = 1;
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnColors
            // 
            this.btnColors.Location = new System.Drawing.Point(10, 608);
            this.btnColors.Name = "btnColors";
            this.btnColors.Size = new System.Drawing.Size(107, 38);
            this.btnColors.TabIndex = 0;
            this.btnColors.UseVisualStyleBackColor = true;
            this.btnColors.Click += new System.EventHandler(this.btnColors_Click);
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.plMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plMain.Controls.Add(this.btnDone);
            this.plMain.Location = new System.Drawing.Point(142, 3);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1444, 662);
            this.plMain.TabIndex = 0;
            this.plMain.Paint += new System.Windows.Forms.PaintEventHandler(this.plMain_Paint);
            this.plMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseDown);
            this.plMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseMove);
            this.plMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseUp);
            // 
            // btnDone2
            // 
            this.btnDone2.Location = new System.Drawing.Point(67, 330);
            this.btnDone2.Name = "btnDone2";
            this.btnDone2.Size = new System.Drawing.Size(62, 23);
            this.btnDone2.TabIndex = 28;
            this.btnDone2.Text = "Done";
            this.btnDone2.UseVisualStyleBackColor = true;
            this.btnDone2.Click += new System.EventHandler(this.btnDone2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 662);
            this.Controls.Add(this.plButtons);
            this.Controls.Add(this.plMain);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Paint_LapTrinhWinDows";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.plButtons.ResumeLayout(false);
            this.plButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoDay)).EndInit();
            this.plMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //  private System.Windows.Forms.Panel plMain;
        private DoubleBufferedPanel plMain;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnEclipse;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnColors;
        private System.Windows.Forms.ColorDialog colorDialogPen;
        private System.Windows.Forms.RadioButton rdBtnPen;
        private System.Windows.Forms.RadioButton rdBtnBrush;
        private System.Windows.Forms.NumericUpDown numDoDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnPolyGon;
        private System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnArc;
        private System.Windows.Forms.Label lbStartAngle;
        private System.Windows.Forms.Label lbSweepAngle;
        private System.Windows.Forms.TextBox txtSweepAngle;
        private System.Windows.Forms.TextBox txtStartAngle;
        private MyComboBox cbbDashStyle;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUnGroup;
        private System.Windows.Forms.Button btnDone2;
    }
}

