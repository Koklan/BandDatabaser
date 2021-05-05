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
    public partial class MainWindow : Window
    {
        private Databaser databaser = new Databaser();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new LibraryPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            databaser.Button((sender as Button).Content.ToString());
            switch((sender as Button).Content.ToString())
            {
                case "Export to CSV":
                    MainFrame.Content = new BandAdittionPage();
                    break;

                case "Import from CSV":

                    break;

                case "Add band":
                    MainFrame.Content = new BandAdittionPage();
                    break;

                case "My library":
                    MainFrame.Content = new LibraryPage();
                    break;
            }
        }

    }
}
