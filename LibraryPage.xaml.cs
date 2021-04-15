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
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        public LibraryPage()
        {
            InitializeComponent();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Thickness margin = SearchBtn.Margin;
            margin.Left = 174 + BandText.ActualWidth;
            SearchBtn.Margin = margin;
        }
    }
}
