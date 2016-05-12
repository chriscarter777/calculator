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
using System.Windows.Resources;
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

        public string aStr;
        public string bStr;
        public string opStr;
        public string resultStr;
        public bool pointFlag = false;
        public bool opFlag = false;


        private void number_Click(object sender, RoutedEventArgs e)
        {
            NumberPress(sender);
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            PointPress();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            ClearPress(ref aStr, ref opStr, ref bStr);
        }

        private void op_Click(object sender, RoutedEventArgs e)
        {
            OpPress(sender);
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            if (aStr != null && opStr != null && bStr != null)
            {
                EqualsPress();
            }
        }

        private void clearAll_Click(object sender, RoutedEventArgs e)
        {
            ClearAllPress();
        }

        private void bg_Click(object sender, RoutedEventArgs e)
        {
            BgPress(sender);
        }

        private void NumberPress(object sender)
        {
            Button b = (Button)sender;
            string buttonVal = b.Content.ToString();
            if (opStr == null)
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
            if(pointFlag == false && opStr == null)
            {
                aStr += ".";
                txtA.Text = aStr;
                pointFlag = true;
            }
            else if(pointFlag == false && opStr != null)
            {
                bStr += ".";
                txtB.Text = bStr;
                pointFlag = true;
            }
        }

        private void ClearPress(ref string aStr, ref string opStr, ref string bStr)
        {
            if(opStr == null && bStr == null)
            {
                aStr = null;
                txtA.Text = null;
                pointFlag = false;
            }
            else if(opStr != null && bStr == null)
            {
                opStr = null;
                txtOp.Text = null;
                opFlag = false;
            }
            else if(bStr != null)
            {
                bStr = null;
                txtB.Text = null;
                pointFlag = false;
            }

        }

        private void OpPress (object sender)
        {
            Button b = (Button)sender;
            string buttonVal = b.Content.ToString();
            if(aStr != null && bStr == null && opFlag == false)
            {
                opStr = buttonVal;
                txtOp.Text = opStr;
                txtShow.Text += aStr + "  " + opStr + "  ";
                pointFlag = false;
                opFlag = true;
            }
        }

        private void EqualsPress()
        {
            switch (opStr)
            {
                case "+":
                {
                    resultStr = Add (aStr, bStr);
                    txtShow.Text += bStr + "\n = " + resultStr + "\n\n";
                    break;
                }
                case "-":
                {
                    resultStr = Subtract(aStr, bStr);
                    txtShow.Text += bStr + "\n = " + resultStr + "\n\n";
                    break;
                }
                case "*":
                {
                    resultStr = Multiply(aStr, bStr);
                    txtShow.Text += bStr + "\n = " + resultStr + "\n\n";
                    break;
               }
                case "/":
                {
                    resultStr = Divide(aStr, bStr);
                    txtShow.Text += bStr + "\n" + resultStr + "\n\n";
                    break;
                    }
                case "^":
                {
                    resultStr = Exponent(aStr, bStr);
                    txtShow.Text += bStr + "\n" + resultStr + "\n\n";
                    break;
                }
            }
            aStr = null;
            opStr = null;
            bStr = null;
            txtA.Text = null;
            txtOp.Text = null;
            txtB.Text = null;
            pointFlag = false;
            opFlag = false;
            resultStr = null;
        }

        private void ClearAllPress()
        {
            aStr = null;
            opStr = null;
            bStr = null;
            txtA.Text = null;
            txtOp.Text = null;
            txtB.Text = null;
            txtShow.Text = null;
            pointFlag = false;
            opFlag = false;
            resultStr = null;
        }

        private void BgPress(object sender)
        {
            Button b = (Button)sender;
            string bName = b.Name;
            switch (bName)
            {
                case "bg1":
                {
                Uri resource = new Uri("PinkMist.jpg", UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resource);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                calcFace.Background = brush;
                break;
                }
                case "bg2":
                {
                    Uri resource = new Uri("redness.jpg", UriKind.Relative);
                    StreamResourceInfo streamInfo = Application.GetResourceStream(resource);
                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                    var brush = new ImageBrush();
                    brush.ImageSource = temp;
                    calcFace.Background = brush;
                    break;
                    }
                case "bg3":
                {
                    Uri resource = new Uri("colorful.jpg", UriKind.Relative);
                    StreamResourceInfo streamInfo = Application.GetResourceStream(resource);
                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                    var brush = new ImageBrush();
                    brush.ImageSource = temp;
                    calcFace.Background = brush;
                    break;
                    }
                case "bg4":
                {
                    Uri resource = new Uri("lion.jpg", UriKind.Relative);
                    StreamResourceInfo streamInfo = Application.GetResourceStream(resource);
                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                    var brush = new ImageBrush();
                    brush.ImageSource = temp;
                    calcFace.Background = brush;
                    break;
                    }
            }
        }

        private string Add ( string a,  string b)
        {
            return (double.Parse(aStr) + double.Parse(bStr)).ToString();
        }

        private string Subtract(string a, string b)
        {
            return (double.Parse(aStr) - double.Parse(bStr)).ToString();
        }

        private string Multiply(string a, string b)
        {
            return (double.Parse(aStr) * double.Parse(bStr)).ToString();
        }

        private string Divide(string a, string b)
        {
            double dblB = double.Parse(bStr);
            if (dblB != 0)
            {
                return (double.Parse(aStr) / dblB).ToString();
            }
            else
            {
                return "ERROR: divide by zero";
            }
        }

        private string Exponent(string a, string b)
        {
            return (Math.Pow(double.Parse(aStr) , double.Parse(bStr))).ToString();
        }
    }
}
