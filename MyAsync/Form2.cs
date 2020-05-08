using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using MyAsync.Properties;

namespace MyAsync
{


    public partial class Form2 : Form
    {

        public int FormHeight = 90;
        public int HideFormHight = 30;

       

        public Form2()
        {
            InitializeComponent();
            ControlExtension.Draggable(this, true);
            //this.TransparencyKey = Color.Gray;
            //this.Opacity = 0.8;
        }

        private void ButtonMouseEnterShowTriangle(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Image = Resources.icons8_triangle_arrow_15px;
        }

        private void ButtonMouseLeaveHideTriangle(object sender, EventArgs e)
        {
            if (this.Height != 90)
            {
                Button btn = (Button)sender;
                btn.Image = null;
            }
        }

        private void btn_Func_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //点击的是线 矩形和椭圆 
            if (btn.Name.IndexOf("Pen") > -1)
            {
                if (Cursor.Position.X >= btn.Location.X + 35 && Cursor.Position.Y >= btn.Location.Y + 35)
                {
               
                }
            }
            this.Height = 90;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.btn_Func_PenLine.Focus();

        }
    }
}
