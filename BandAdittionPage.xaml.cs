﻿using System;
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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class BandAdittionPage : Page
    {
        Database.DatabaseOperations datOp = new Database.DatabaseOperations();
        public BandAdittionPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if((BandNameBox.Text != null) && (0 < Int32.Parse(FoundationYearBox.Text)) && (Int32.Parse(FoundationYearBox.Text) < 5000))
            {
                datOp.AddBand(BandNameBox.Text, Int32.Parse(FoundationYearBox.Text));
                MessageBox.Show("Added to library!");
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }
    }
}
