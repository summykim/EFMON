using EFM_MON.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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
using EFM_MON.classes;

namespace EFM_MON
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ip="";
        public MainWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            ip =CommonUtil.getLocalIpAddress();
            this.Title = "통합서식지 운영자 모니터링[서식지(운영기)][" + ip + "]";


        }

        private void btnDevTest_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            this.Title = "통합서식지 운영자 모니터링[" + button.Content + "][" + ip + "]";
            DevPage devPage = new DevPage();
            frame.NavigationService.Navigate(devPage);
        }

        private void btnPrdTest_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            this.Title = "통합서식지 운영자 모니터링[" + button.Content + "][" + ip + "]";
            PrdPage prdPage = new PrdPage();
            frame.NavigationService.Navigate(prdPage);
        }
    }
}
