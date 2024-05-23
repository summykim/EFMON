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
        public static MainWindow mainWin;
        public MainWindow()
        {
            InitializeComponent();
            InitializeApplication();

            mainWin = this;
 
            //서버 시작
            HttpServer hs = new HttpServer();
            hs.Start();
        }

        //기본 초기화 및 외부호출 여부 확인
        private void InitializeApplication()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.WindowState = WindowState.Maximized;

      }


    }
}
