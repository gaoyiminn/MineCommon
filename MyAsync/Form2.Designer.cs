namespace MyAsync
{
    partial class Form2
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
            this.btn_Func_Save = new System.Windows.Forms.Button();
            this.btn_Func_Clear = new System.Windows.Forms.Button();
            this.btn_Func_PenEllip = new System.Windows.Forms.Button();
            this.btn_Func_PenRect = new System.Windows.Forms.Button();
            this.btn_Func_PenLine = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Pen_Bold = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Pen_Nomal = new System.Windows.Forms.Button();
            this.btn_Pen_ = new System.Windows.Forms.Label();
            this.btn_Pen_Thick = new System.Windows.Forms.Button();
            this.btn_Pen_Red = new System.Windows.Forms.Button();
            this.btn_Pen_Yellow = new System.Windows.Forms.Button();
            this.btn_Pen_Black = new System.Windows.Forms.Button();
            this.userControl11 = new MyAsync.UserControl1();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Func_Save
            // 
            this.btn_Func_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Func_Save.BackgroundImage = global::MyAsync.Properties.Resources.icons8_save_50px;
            this.btn_Func_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Func_Save.Location = new System.Drawing.Point(236, 12);
            this.btn_Func_Save.Name = "btn_Func_Save";
            this.btn_Func_Save.Size = new System.Drawing.Size(50, 50);
            this.btn_Func_Save.TabIndex = 4;
            this.btn_Func_Save.UseVisualStyleBackColor = false;
            // 
            // btn_Func_Clear
            // 
            this.btn_Func_Clear.BackColor = System.Drawing.Color.Transparent;
            this.btn_Func_Clear.BackgroundImage = global::MyAsync.Properties.Resources.icons8_erase_50px;
            this.btn_Func_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Func_Clear.Location = new System.Drawing.Point(180, 12);
            this.btn_Func_Clear.Name = "btn_Func_Clear";
            this.btn_Func_Clear.Size = new System.Drawing.Size(50, 50);
            this.btn_Func_Clear.TabIndex = 3;
            this.btn_Func_Clear.UseVisualStyleBackColor = false;
            // 
            // btn_Func_PenEllip
            // 
            this.btn_Func_PenEllip.BackColor = System.Drawing.Color.Transparent;
            this.btn_Func_PenEllip.BackgroundImage = global::MyAsync.Properties.Resources.icons8_oval_50px;
            this.btn_Func_PenEllip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Func_PenEllip.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btn_Func_PenEllip.Location = new System.Drawing.Point(124, 12);
            this.btn_Func_PenEllip.Name = "btn_Func_PenEllip";
            this.btn_Func_PenEllip.Size = new System.Drawing.Size(50, 50);
            this.btn_Func_PenEllip.TabIndex = 2;
            this.btn_Func_PenEllip.UseVisualStyleBackColor = false;
            this.btn_Func_PenEllip.MouseEnter += new System.EventHandler(this.ButtonMouseEnterShowTriangle);
            this.btn_Func_PenEllip.MouseLeave += new System.EventHandler(this.ButtonMouseLeaveHideTriangle);
            // 
            // btn_Func_PenRect
            // 
            this.btn_Func_PenRect.BackColor = System.Drawing.Color.Transparent;
            this.btn_Func_PenRect.BackgroundImage = global::MyAsync.Properties.Resources.icons8_rectangular_50px;
            this.btn_Func_PenRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Func_PenRect.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btn_Func_PenRect.Location = new System.Drawing.Point(68, 12);
            this.btn_Func_PenRect.Name = "btn_Func_PenRect";
            this.btn_Func_PenRect.Size = new System.Drawing.Size(50, 50);
            this.btn_Func_PenRect.TabIndex = 1;
            this.btn_Func_PenRect.UseVisualStyleBackColor = false;
            this.btn_Func_PenRect.MouseEnter += new System.EventHandler(this.ButtonMouseEnterShowTriangle);
            this.btn_Func_PenRect.MouseLeave += new System.EventHandler(this.ButtonMouseLeaveHideTriangle);
            // 
            // btn_Func_PenLine
            // 
            this.btn_Func_PenLine.BackColor = System.Drawing.Color.Transparent;
            this.btn_Func_PenLine.BackgroundImage = global::MyAsync.Properties.Resources.icons8_pencil_50px_1;
            this.btn_Func_PenLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Func_PenLine.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btn_Func_PenLine.Location = new System.Drawing.Point(12, 12);
            this.btn_Func_PenLine.Name = "btn_Func_PenLine";
            this.btn_Func_PenLine.Size = new System.Drawing.Size(50, 50);
            this.btn_Func_PenLine.TabIndex = 0;
            this.btn_Func_PenLine.UseVisualStyleBackColor = false;
            this.btn_Func_PenLine.Click += new System.EventHandler(this.btn_Func_Click);
            this.btn_Func_PenLine.MouseEnter += new System.EventHandler(this.ButtonMouseEnterShowTriangle);
            this.btn_Func_PenLine.MouseLeave += new System.EventHandler(this.ButtonMouseLeaveHideTriangle);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_Pen_Bold);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_Pen_Nomal);
            this.panel1.Controls.Add(this.btn_Pen_);
            this.panel1.Controls.Add(this.btn_Pen_Thick);
            this.panel1.Controls.Add(this.btn_Pen_Red);
            this.panel1.Controls.Add(this.btn_Pen_Yellow);
            this.panel1.Controls.Add(this.btn_Pen_Black);
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 31);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(167, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 8);
            this.label3.TabIndex = 9;
            // 
            // btn_Pen_Bold
            // 
            this.btn_Pen_Bold.BackColor = System.Drawing.Color.Gray;
            this.btn_Pen_Bold.Location = new System.Drawing.Point(162, 0);
            this.btn_Pen_Bold.Name = "btn_Pen_Bold";
            this.btn_Pen_Bold.Size = new System.Drawing.Size(30, 30);
            this.btn_Pen_Bold.TabIndex = 8;
            this.btn_Pen_Bold.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(136, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 5);
            this.label2.TabIndex = 7;
            // 
            // btn_Pen_Nomal
            // 
            this.btn_Pen_Nomal.BackColor = System.Drawing.Color.Gray;
            this.btn_Pen_Nomal.Location = new System.Drawing.Point(131, 0);
            this.btn_Pen_Nomal.Name = "btn_Pen_Nomal";
            this.btn_Pen_Nomal.Size = new System.Drawing.Size(30, 30);
            this.btn_Pen_Nomal.TabIndex = 6;
            this.btn_Pen_Nomal.UseVisualStyleBackColor = false;
            // 
            // btn_Pen_
            // 
            this.btn_Pen_.BackColor = System.Drawing.Color.Black;
            this.btn_Pen_.Location = new System.Drawing.Point(105, 15);
            this.btn_Pen_.Name = "btn_Pen_";
            this.btn_Pen_.Size = new System.Drawing.Size(20, 2);
            this.btn_Pen_.TabIndex = 5;
            // 
            // btn_Pen_Thick
            // 
            this.btn_Pen_Thick.BackColor = System.Drawing.Color.Gray;
            this.btn_Pen_Thick.Location = new System.Drawing.Point(100, 0);
            this.btn_Pen_Thick.Name = "btn_Pen_Thick";
            this.btn_Pen_Thick.Size = new System.Drawing.Size(30, 30);
            this.btn_Pen_Thick.TabIndex = 3;
            this.btn_Pen_Thick.UseVisualStyleBackColor = false;
            // 
            // btn_Pen_Red
            // 
            this.btn_Pen_Red.BackColor = System.Drawing.Color.Red;
            this.btn_Pen_Red.Location = new System.Drawing.Point(64, 0);
            this.btn_Pen_Red.Name = "btn_Pen_Red";
            this.btn_Pen_Red.Size = new System.Drawing.Size(30, 30);
            this.btn_Pen_Red.TabIndex = 2;
            this.btn_Pen_Red.UseVisualStyleBackColor = false;
            // 
            // btn_Pen_Yellow
            // 
            this.btn_Pen_Yellow.BackColor = System.Drawing.Color.Yellow;
            this.btn_Pen_Yellow.Location = new System.Drawing.Point(32, 0);
            this.btn_Pen_Yellow.Name = "btn_Pen_Yellow";
            this.btn_Pen_Yellow.Size = new System.Drawing.Size(30, 30);
            this.btn_Pen_Yellow.TabIndex = 1;
            this.btn_Pen_Yellow.UseVisualStyleBackColor = false;
            // 
            // btn_Pen_Black
            // 
            this.btn_Pen_Black.BackColor = System.Drawing.Color.Black;
            this.btn_Pen_Black.Location = new System.Drawing.Point(0, 0);
            this.btn_Pen_Black.Name = "btn_Pen_Black";
            this.btn_Pen_Black.Size = new System.Drawing.Size(30, 30);
            this.btn_Pen_Black.TabIndex = 0;
            this.btn_Pen_Black.UseVisualStyleBackColor = false;
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.Color.Transparent;
            this.userControl11.Location = new System.Drawing.Point(430, 187);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(373, 103);
            this.userControl11.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(914, 576);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Func_Save);
            this.Controls.Add(this.btn_Func_Clear);
            this.Controls.Add(this.btn_Func_PenEllip);
            this.Controls.Add(this.btn_Func_PenRect);
            this.Controls.Add(this.btn_Func_PenLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Func_PenLine;
        private System.Windows.Forms.Button btn_Func_PenRect;
        private System.Windows.Forms.Button btn_Func_PenEllip;
        private System.Windows.Forms.Button btn_Func_Clear;
        private System.Windows.Forms.Button btn_Func_Save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Pen_Black;
        private System.Windows.Forms.Button btn_Pen_Red;
        private System.Windows.Forms.Button btn_Pen_Yellow;
        private System.Windows.Forms.Button btn_Pen_Thick;
        private System.Windows.Forms.Label btn_Pen_;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Pen_Bold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Pen_Nomal;
        private UserControl1 userControl11;
    }
}