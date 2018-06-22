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
using Challenge2.WPF;
using MahApps.Metro.Controls;

namespace WpfApplication
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            frmMain.Content = new TourEvents();
        }

        private void btnTourEvents_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Content = new TourEvents();
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Content = new Clients();
        }
    }
}
