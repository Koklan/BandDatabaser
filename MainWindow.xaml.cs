using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
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
        Database.DatabaseOperations datOp = new Database.DatabaseOperations();
        private string selectedBand;

        public string SelectedBand
        {
            get { return selectedBand; }
            set { selectedBand = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new LibraryPage();
        }

        public void Band(string band)
        {
            selectedBand = band;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            databaser.Button((sender as Button).Content.ToString());
            switch ((sender as Button).Content.ToString())
            {
                case "Export to CSV":
                    OpenFileDialog openFileDialogExport = new OpenFileDialog();
                    openFileDialogExport.ShowDialog();
                    datOp.SaveToCSV(openFileDialogExport.FileName);
                    break;

                case "Import from CSV":
                    OpenFileDialog openFileDialogImport = new OpenFileDialog();
                    openFileDialogImport.ShowDialog();
                    datOp.LoadFromCSV(openFileDialogImport.FileName);
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
