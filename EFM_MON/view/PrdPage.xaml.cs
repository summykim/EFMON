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
    public partial class PrdPage : Page
    {
        public PrdPage()
        {
            InitializeComponent();

            // get notified when page has loaded
            webView.NavigationCompleted += WebView_NavigationCompleted;

            // force to async initialization
            InitializeAsync();

        }
        async void InitializeAsync()
        {

            string prdUrl = ConfigurationManager.AppSettings.Get("prdUrl");
            string ip = CommonUtil.getLocalIpAddress();
            Uri prdURI = new Uri(prdUrl + "?ipAddr=" + ip);
            webView.Source = prdURI;
            // You can then navigate the file from disk with the domain
            webView.Source = prdURI;

      
        }
        private async void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // Now it's safe to interact with the DOM
            var id = "UK189";
            var pwd = "ops04988!@";
            await webView.ExecuteScriptAsync($"document.getElementById('loginIdIn').value = '{id}';");
            await webView.ExecuteScriptAsync($"document.getElementById('pwdIn').value = '{pwd}';");
        }
    }
}
