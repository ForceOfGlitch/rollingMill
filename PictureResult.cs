using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculationForms
{
    public partial class PictureResult : Form
    {
        public PictureResult()
        {
            InitializeComponent();
        }

        public PictureResult(List<double> argsDouble, List<string> argsStr)
        {
            InitializeComponent();

            label10.Text = argsStr[0];
            label9.Text = argsStr[1];

            label6.Text = argsStr[2];
            label7.Text = argsStr[3];

            label12.Text = argsStr[4];
            label11.Text = argsStr[5];

            label14.Text = argsStr[6];
            label13.Text = argsStr[7];

            label1.Text = argsStr[8];
            label2.Text = argsStr[9];

            pictureBox1.Load("4(1).jpg");

            if (argsDouble[0] < 5 || argsDouble[1] < 5)
            {
                pictureBox1.Load("1(1).jpg");
            }
            if (argsDouble[2] < 5 || argsDouble[3] < 5 || argsDouble[4] < 5)
            {
                pictureBox1.Load("2(1).jpg");
            }
            if ( (argsDouble[0] < 5 || argsDouble[1] < 5) && (argsDouble[2] < 5 || argsDouble[3] < 5 || argsDouble[4] < 5) )
            {
                pictureBox1.Load("3(1).jpg");
            }
            if ( argsDouble[0] >= 5 && argsDouble[1] >= 5 && argsDouble[2] >= 5 && argsDouble[3] >= 5 && argsDouble[4] >= 5)
            {
                pictureBox1.Load("4(1).jpg");
            }

            if (argsDouble[5] < 250)
            {
                pictureBox2.Load("250kN.jpg");
                pictureBox3.Load("250kNS.jpg");
            }
            if (argsDouble[5] < 200) 
            {
                pictureBox2.Load("200kN.jpg");
                pictureBox3.Load("200kNS.jpg");
            }
            if (argsDouble[5] < 100)
            {
                pictureBox2.Load("100kN.jpg");
                pictureBox3.Load("100kNS.jpg");
            }
            if (argsDouble[5] < 50)
            {
                pictureBox2.Load("50kN.jpg");
                pictureBox3.Load("50kNS.jpg");
            }
            if (argsDouble[5] >= 250)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                Size = new Size(867, 446);
            }
        }
    }
}
