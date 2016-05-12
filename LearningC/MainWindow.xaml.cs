using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public double a;
        public string aStr;
        public double b;
        public string bStr;
        public string op;
        public double result;
        public bool pointFlag = false;


        private void number_Click(object sender, RoutedEventArgs e)
        {
            NumberPress(sender);
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            PointPress();
        }

        private void op_Click(object sender, RoutedEventArgs e)
        {
            OpPress(sender);
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            if (aStr != null && op != null && bStr != null)
            {
                EqualsPress();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            ExitPress();
        }

        private void NumberPress(object sender)
        {
            Button b = (Button)sender;
            string buttonVal = b.Content.ToString();
            if (op == null)
            {
                aStr += buttonVal;
                txtA.Text = aStr;
            }
            else
            {
                bStr += buttonVal;
                txtB.Text = bStr;
            }
        }

        private void PointPress()
        {
            if(pointFlag == false && op == null)
            {
                aStr += ".";
                txtA.Text = aStr;
                pointFlag = true;
            }
            else if(pointFlag == false && op != null)
            {
                bStr += "+";
                txtB.Text = bStr;
                pointFlag = true;
            }
        }

        private void OpPress (object sender)
        {
            Button b = (Button)sender;
            string buttonVal = b.Content.ToString();
            if(aStr != null && bStr == null)
            {
                op = buttonVal;
                txtOp.Text = op;
                txtShow.Text += aStr + "  " + op + "  ";
                pointFlag = false;
            }
        }

        private void EqualsPress()
        {
            switch (op)
            {
                case "+":
                {
                    result = double.Parse(aStr) + double.Parse(bStr);
                    txtShow.Text += bStr + "\n = " + (result.ToString()) + "\n\n";
                    break;
                }
                case "-":
                {
                    result = double.Parse(aStr) - double.Parse(bStr);
                    txtShow.Text += bStr + "\n = " + (result.ToString()) + "\n\n";
                    break;
                }
                case "*":
                {
                    result = double.Parse(aStr) * double.Parse(bStr);
                    txtShow.Text += bStr + "\n = " + (result.ToString()) + "\n\n";
                    break;
               }
                case "/":
                {
                    b = double.Parse(bStr);
                    if (b != 0)
                    {
                        result = double.Parse(aStr) / b;
                        txtShow.Text += bStr + "\n = " + (result.ToString()) + "\n\n";
                        }
                        else
                    {
                        txtShow.Text += bStr + "\nERROR: divide by zero\n";
                    }
                    break;
                }
                case "^":
                {
                    result = Math.Pow(double.Parse(aStr) , double.Parse(bStr));
                        txtShow.Text += bStr + "\n" + (result.ToString()) + "\n\n";
                        break;
                }
            }
            aStr = null;
            op = null;
            bStr = null;
            txtA.Text = null;
            txtOp.Text = null;
            txtB.Text = null;
            result = 0;
        }

        private void ExitPress()
        {
            MessageBox.Show("Exit Clicked");
            txtA.Text = null;
            txtOp.Text =null;
            txtShow.Text = null;
        }

        private double Add (ref double a, ref double b, ref string flag)
        {
            return a + b;
        }

        private double Subtract(double a, double b, ref string flag)
        {
            return a - b;
        }

        private double Multiply(double a, double b, ref string flag)
        {
            return a * b;
        }

        private double Divide(double a, double b, ref string flag)
        {
            if (b != 0)
            {
                return (double)(a / b);
            }
            else
            {
                return 0;
                flag = "divide by zero";
            }
        }

        //private double Display(double result, ref string flag)
        //{
        //    return a * b;
        //}

    }
}
