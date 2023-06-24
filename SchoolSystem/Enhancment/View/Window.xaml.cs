using Project_Teacher.ViewModel;
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
using System.Windows.Shapes;

namespace Project_Teacher.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = new WindowViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sv.Visibility= Visibility.Visible;
            Uphoto.Visibility= Visibility.Visible;
            please.Visibility = Visibility.Visible;
            Pp.Visibility = Visibility.Hidden;
        }

        private void Sv_Click(object sender, RoutedEventArgs e)
        {
            Sv.Visibility= Visibility.Hidden;
            Uphoto.Visibility= Visibility.Hidden;
            please.Visibility = Visibility.Hidden;
            Pp.Visibility = Visibility.Visible;
        }

    }
}
