using EFORMWIN.data;
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
using System.Windows.Shapes;

namespace EFORMWIN.view
{
    /// <summary>
    /// TestSignWin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWin : Window
    {
        public LoginWin()
        {
            InitializeComponent();

            webView.NavigationStarting += EnsureHttps;
            webView.NavigationCompleted += WebView_NavigationCompleted;

            string eformSignOutDomain = ConfigurationManager.AppSettings.Get("eformSignOutDomain");
            string eformLoginUrl = ConfigurationManager.AppSettings.Get("eformLoginUrl");
            Uri eformLoginUrI = new Uri(eformSignOutDomain + eformLoginUrl);
            webView.Source = eformLoginUrI;
        }

        private async void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // 로그인 화면
            if (!webView.Source.ToString().Contains("AdminLogin"))
            {
                //로그인 여부 체크
                if (e.HttpStatusCode == 401)
                {
                    Session.isLoginSuccess = false;

                }
                else
                {
                    Session.isLoginSuccess = true;
                }

                if (Session.isLoginSuccess)//로그인되면 윈도우 닫기
                {
                    this.Close();
                    SignPage.signPage1.webView.Reload();    
                }
            }



        }
        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                args.Cancel = true;
            }

        }
    }
}
