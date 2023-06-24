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

namespace Calculator
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

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "0";
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + ".";
        }

        private void Char_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = "";
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "3";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "6";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "7";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "8";
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "9";
        }

        private void lPar_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "(";
        }

        private void rPar_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + ")";
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "+";
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "-";
        }

        private void Mult_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "*";
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = Screen.Text + "/";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != "")
            {
                Type scriptType = Type.GetTypeFromCLSID(Guid.Parse("0E59F1D5-1FBE-11D0-8FF2-00A0D10038BC"));

                dynamic obj = Activator.CreateInstance(scriptType, false);
                obj.Language = "javascript";
                string str = null;
                try
                {
                    var res = obj.Eval(Screen.Text);
                    str = Convert.ToString(res);
                    Screen.Text = Screen.Text + "=" + str;
                }
                catch (SystemException)
                {
                    //Screen.Text = "Syntax Error";
                    var res = obj.Eval(Screen.Text);
                    str = Convert.ToString(res);
                    Screen.Text = Screen.Text + "=" + str;
                }
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != "")
                Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);
        }
    }
}
