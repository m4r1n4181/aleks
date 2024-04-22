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
using System.Windows.Shapes;
using BookingApp.View.ViewModel;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for HotelSearchView.xaml
    /// </summary>
    public partial class HotelSearchView : Window
    {
        public HotelSearchView()
        {
            InitializeComponent();
            this.DataContext = new HotelSearchViewModel();
        }
    }
}
