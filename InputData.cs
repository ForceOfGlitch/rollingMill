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
    public partial class InputData : Form
    {
        public InputData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> args = new List<double>();
            bool isEmpty = false;

            if (textBox1.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox1.Text))); else isEmpty = true;
            if (textBox2.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox2.Text))); else isEmpty = true;
            if (textBox3.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox3.Text))); else isEmpty = true;
            if (textBox4.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox4.Text))); else isEmpty = true;
            if (textBox5.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox5.Text))); else isEmpty = true;
            if (textBox6.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox6.Text))); else isEmpty = true;
            if (textBox7.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox7.Text))); else isEmpty = true;
            if (textBox8.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox8.Text))); else isEmpty = true;
            if (textBox9.Text != "") args.Add(Convert.ToDouble(CharCorrect(textBox9.Text))); else isEmpty = true;
            if (textBox10.Text == "") isEmpty = true;
            if (comboBox1.Text == "") isEmpty = true;

            if (!isEmpty)
            {
                Calculate newForm = new Calculate(args);
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Введены не все параметры!");
            }
        }

        private string CharCorrect(string str)
        {
            string newStr = "";
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.')
                {
                    newStr += ",";
                }
                else
                {
                    newStr += str[i];
                }
            }

            return newStr;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
