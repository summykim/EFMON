﻿using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace WpfEfmon
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

        private void btnDevTest_Click(object sender, RoutedEventArgs e)
        {
            DevPage devPage = new DevPage();
            frame.NavigationService.Navigate(devPage);
        }

        private void btnPrdTest_Click(object sender, RoutedEventArgs e)
        {
            PrdPage prdPage = new PrdPage();
            frame.NavigationService.Navigate(prdPage);
        }
    }
}