using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
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
using System.Xml.Linq;
using EFORMWIN.data;
using EFORMWIN.view;

namespace EFORMWIN
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitializeApplication();
 
            //서버 시작
            HttpServer hs = new HttpServer();
            hs.Start();
        }

        //기본 초기화 및 외부호출 여부 확인
        private void InitializeApplication()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.WindowState = WindowState.Maximized;

            //외부망인경우
            if (Session.isOutDomain)
            {
                btnLogin.Visibility = Visibility.Visible;
            }
            else
            {
                btnLogin.Visibility = Visibility.Hidden;
            }


        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            showSignWin();
        }

        public  void showSignWin()
        {
            SignWin  signWin = new SignWin();
            signWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            signWin.WindowState = WindowState.Maximized;
            signWin.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWin lw = new LoginWin();
            lw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            lw.WindowState = WindowState.Maximized;

            if (lw.ShowDialog()==true)
            {
                Console.WriteLine("true");
            }
            else
            {
                SignPage.signPage1.webView.CoreWebView2.Reload();
            }

        }

    }
}
