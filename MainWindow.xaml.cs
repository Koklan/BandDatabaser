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

namespace BandDatabaser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// git test nazdar
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new LibraryPage();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SearchPage();
        }

        private void Library_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LibraryPage();
        }
    }
}
