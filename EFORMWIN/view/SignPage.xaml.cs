using EFORMWIN.classes;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace EFORMWIN.view
{
    /// <summary>
    /// SignPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignPage : Page
    {
        public SignPage()
        {
            InitializeComponent();

            webView.NavigationStarting += EnsureHttps;
            webView.NavigationCompleted += WebView_NavigationCompleted;

            initializeAsync();

            goEForm();

        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {

        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                args.Cancel = true;
            }
        }

  

        private async void initializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);

            string eformSignUrl = ConfigurationManager.AppSettings.Get("eformSignUrl");
            string rsaPubKey = ConfigurationManager.AppSettings.Get("rsaPubKey");
            string authKey = CommonUtil.makeAuthData(rsaPubKey);
            string param = "token=" + authKey + "&useHstDataId=20240517165256352933";
            string url = eformSignUrl + "?" + param;
            Console.WriteLine(url);
            Uri eformSignURI = new Uri(url);
            
            webView.Source=eformSignURI;

        }

        private void goEForm()
        {
            string eformSignUrl = ConfigurationManager.AppSettings.Get("eformSignUrl");
            string rsaPubKey = ConfigurationManager.AppSettings.Get("rsaPubKey");
            string authKey = CommonUtil.makeAuthData(rsaPubKey);
            string param = "token=" + authKey + "&useHstDataId=20240517165256352933";
            navigateWebview(eformSignUrl, param);
        }

              private void navigateWebview(string url, string postDataString)
        {

            UTF8Encoding utfEncoding = new UTF8Encoding();
            byte[] postData = utfEncoding.GetBytes(
                postDataString);
            MemoryStream postDataStream = new MemoryStream(postDataString.Length);
            postDataStream.Write(postData, 0, postData.Length);
            postDataStream.Seek(0, SeekOrigin.Begin);
            CoreWebView2WebResourceRequest webResourceRequest =
              webView.CoreWebView2.Environment.CreateWebResourceRequest(
                url,
                "POST",
                postDataStream,
                "Content-Type: application/x-www-form-urlencoded\r\n");
            webView.CoreWebView2.NavigateWithWebResourceRequest(webResourceRequest);
        }
        private void BtnSign_Click(object sender, EventArgs e)
        {
            goEForm();
        }
    }
}
