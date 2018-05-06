using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class ScCalc : Form
    {
        Double value;
        string operation = "";
        bool operator_pressed = false;
      
        public ScCalc()
        {
            InitializeComponent();
        }

        private void ScCalc_Load(object sender, EventArgs e)
        {
      
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (display.Text == "0" || operator_pressed)
            {
                display.Clear();
            }
            operator_pressed = false;
            Button button = sender as Button;
            if (button.Text == ".")
            {
                if (!display.Text.Contains("."))
                {
                    display.Text = display.Text + button.Text;
                }
            }
            else
            {
                display.Text = display.Text + button.Text;
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (value != 0)
            {
                if (button.Text == "√")
                {
                    equation.Text = "sqrt" + "( " + display.Text + " )";
                    display.Text = Math.Sqrt(Double.Parse(display.Text)).ToString();
                }
                equalButton.PerformClick();
                operator_pressed = true;
                operation = button.Text;
               
            }
            else if (button.Text == "√")
            {
                equation.Text = "sqrt" + "( " + display.Text + " )";
                display.Text = Math.Sqrt(Double.Parse(display.Text)).ToString();
                value = Math.Sqrt(Double.Parse(display.Text));

            }
            else
            {
                operation = button.Text;
                value = Double.Parse(display.Text);
                operator_pressed = true;
                if (button.Text != "x^y")
                    equation.Text = value + " " + operation;
                if (button.Text == "x^y")
                    equation.Text = value + " ^ ";
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            equation.Text = "";

            switch (operation)
            { 
                case "+":
                    display.Text = (value + Double.Parse(display.Text)).ToString();
                    break;
                case "-":
                    display.Text = (value - Double.Parse(display.Text)).ToString();
                    break;
                case "*":
                    display.Text = (value * Double.Parse(display.Text)).ToString();
                    break;
                case "/":
                    equation.Text = value + " " + operation;
                    display.Text = (value / Double.Parse(display.Text)).ToString();
                    break;
                case "x^y":
                    equation.Text = value + " ^ ";
                    display.Text = Math.Pow(value, Double.Parse(display.Text)).ToString();
                    break;
                default:
                    break;

            }
            value = Double.Parse(display.Text);
            operation = "";
        }

        private void sinButton_Click(object sender, EventArgs e)
        {
            equation.Text = "sin( " + display.Text + " )";
            display.Text = Math.Sin(Double.Parse(display.Text) * Math.PI / 180).ToString();
            value = Double.Parse(display.Text);
        }

        private void cosButton_Click(object sender, EventArgs e)
        {
            equation.Text = "cos( " + display.Text + " )";
            display.Text = Math.Cos(Double.Parse(display.Text) * Math.PI / 180).ToString();
            value = Double.Parse(display.Text);

        }

        private void tanButton_Click(object sender, EventArgs e)
        {
            equation.Text = "tan( " + display.Text + " )";
            if (display.Text != "90")
            {
                display.Text = Math.Tan(Double.Parse(display.Text)*Math.PI/180).ToString();
                value = Double.Parse(display.Text);
            }
            else
            {
                display.Text = "Invalid Input";
                value = 0;
            }
        }

        private void inverseSinButton_Click(object sender, EventArgs e)
        {
            equation.Text = "Asin( " + display.Text + " )";
            display.Text = Math.Asin(Double.Parse(display.Text) * Math.PI / 180).ToString();
            value = Double.Parse(display.Text);
        }

        private void inverseCosButton_Click(object sender, EventArgs e)
        {
            equation.Text = "Acos( " + display.Text + " )";
            display.Text = Math.Acos(Double.Parse(display.Text) * Math.PI / 180).ToString();
            value = Double.Parse(display.Text);
        }

        private void inverseTanButton_Click(object sender, EventArgs e)
        {
            equation.Text = "Atan( " + display.Text + " )";
            display.Text = Math.Atan(Double.Parse(display.Text) * Math.PI / 180).ToString();
            value = Double.Parse(display.Text);
        }

        private void hyperSinButton_Click(object sender, EventArgs e)
        {
            equation.Text = "sinh( " + display.Text + " )";
            display.Text = Math.Sinh(Double.Parse(display.Text) * Math.PI / 180).ToString();
            value = Double.Parse(display.Text);
        }

        private void hyperCosButton_Click(object sender, EventArgs e)
        {
            equation.Text = "cosh( " + display.Text + " )";
            display.Text = Math.Cosh(Double.Parse(display.Text) * Math.PI / 180).ToString();
            value = Double.Parse(display.Text);
        }

        private void hyperTanButton_Click(object sender, EventArgs e)
        {
            equation.Text = "tanh( " + display.Text + " )";
            display.Text = Math.Tanh(Double.Parse(display.Text) * Math.PI / 180).ToString();
            value = Double.Parse(display.Text);
        }

        private void factorialButton_Click(object sender, EventArgs e)
        {
            equation.Text = "fact( " + display.Text + " )";
            int result = 1;
            int number;
            bool check = Int32.TryParse(display.Text, out number);
            if (check)
            {
                while(number != 0)
                {
                    result = result * number;
                    number--;
                }
                display.Text = result.ToString();
                value = Double.Parse(display.Text);
            }
            else
            {
                display.Text = "Invalid Input";
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            equation.Text = "Log10( " + display.Text + " )";
            display.Text = Math.Log10(Double.Parse(display.Text)).ToString();
            value = Double.Parse(display.Text);
        }

        private void lnButton_Click(object sender, EventArgs e)
        {
            equation.Text = "Loge( " + display.Text + " )";
            display.Text = Math.Log(Double.Parse(display.Text)).ToString();
            value = Double.Parse(display.Text);
        }

        private void exponentButton_Click(object sender, EventArgs e)
        {
            equation.Text = "Expo( " + display.Text + " )";
            display.Text = Math.Exp(Double.Parse(display.Text)).ToString();
            value = Double.Parse(display.Text);
        }

        private void tenpowerXButton_Click(object sender, EventArgs e)
        {
            equation.Text = "Power( 10, " + display.Text + " )";
            display.Text = Math.Pow(10, Double.Parse(display.Text)).ToString();
            value = Double.Parse(display.Text);
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            try
            {
                display.Text = display.Text.Remove(display.Text.Length - 1, 1);
            }
            catch (Exception)
            {
                display.Text = "0";
            }
        }

        private void clearEnabledButton_Click(object sender, EventArgs e)
        {
            display.Text = "0";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            display.Text = "0";
            value = 0;
        }

        private void plusminusButton_Click(object sender, EventArgs e)
        {
            display.Text = (-Double.Parse(display.Text)).ToString();
            value = Double.Parse(display.Text);
        }

        private void inverseButton_Click(object sender, EventArgs e)
        {
            equation.Text = "reciproc( " + display.Text + " )";
            display.Text = (1 / Double.Parse(display.Text)).ToString();
            value = Double.Parse(display.Text);
        }


        private void modButton_Click(object sender, EventArgs e)
        {
            display.Text = (value * Double.Parse(display.Text) / 100).ToString();
            equation.Text += display.Text;
            //value = Double.Parse(display.Text);
        }
    }
}
