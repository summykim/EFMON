using EFM_MON.classes;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace EFM_MON.view
{
    /// <summary>
    /// DevPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DevPage : Page
    {
        public DevPage()
        {
            InitializeComponent();

            webView.NavigationCompleted += WebView_NavigationCompleted;

            string devUrl = ConfigurationManager.AppSettings.Get("devUrl");
            string ip = CommonUtil.getLocalIpAddress();
            Uri devURI = new Uri(devUrl + "?ipAddr="+ip);
            Console.WriteLine(devURI.ToString());

            webView.Source = devURI;

        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {

            Console.WriteLine(e.HttpStatusCode);

        }
    }
}
