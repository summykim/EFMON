using EFORMWIN.data;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
using System.Xml.Linq;

namespace EFORMWIN.view
{
    /// <summary>
    /// SignPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignPage : Page
    {
        public static EFORMWIN.view.SignPage signPage1;

        public SignPage()
        {
            InitializeComponent();

            webView.NavigationStarting += EnsureHttps;
            webView.NavigationCompleted += WebView_NavigationCompleted;

            initializeAsync();
            init();

            signPage1 = this;

        }


        private async void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!Session.isLoginSuccess)
            {
                var cookies = await webView.CoreWebView2
                .CookieManager
                .GetCookiesAsync("https://sktelecom.com");

                foreach (CoreWebView2Cookie cookie in cookies)
                {
                    if (cookie.Name.Equals(Session.cookieName) && cookie.Expires >= DateTime.Now)
                    {//세션이 존재하면 
                        Session.isLoginSuccess = true;
                        break;
                    }
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

  

        //서명하기  화면 열기
        private async void initializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            //JSESSIONID  28EF725A4B37ED642CF387CB0571DC2B.node22 e-form.sktelecom.com /
            //GiRxfQslTpojTrOZw7m4viZDP5kXYl7ZfjPMEWWTjj8xioBGASqVYjFChai4DSc83XWgyAea1PyEq9DlmDicJM7DFkAkOW2kSPbdIzr3mXITsw0X1e29SVYTqcjozd4bmmmsbqJXMOpkbYfVKLcjwVXVRb0nkEbDkQfzLgL5AvXcQMfJMpwKpO3juhyz9I8dsogFFLx6rGlKqzThPKwZ8rvsK9qpwzq7vQYO2wrO6ifljGilYnYY/y2HGHjcPCrXfcr8JfctSI3uKQAGUUD1Ma7APhF8ZT7ZFF8UpIS+DyWhVIHpPzkYUMgyWyDTrBQcw9HTPB6qCAXKh/oe9soqySpqmAynED57hYwAlRriyFmB2RHYN/v/Qk1lf/Lm8Wc/QcmD5eQawzoHsAcZdt3azIHPxMaENGAD9ljhV0OaMY/2rtyAUCWbamDsbwfkaKJSAWkWn9OYyhYl0zM8+xUYGEtHNlYcwj4D04c9Kr5n+BwdRkHKceiuzhW/OnBISy7BViPnx1hoIhKshWFv4yU6domrfjWzaHMg6cP3b4+P0gPSq0guxqVDFhds4t5I5xWZoUv5gTI3kdpoQPO+V6zcYucjISjaS/JqwC/U0mTIstB/LFQRowQVkHFKOqX7G2LmQoFLHR5GXGEmwT9rRdFDL2P0L68kGV+xcV4dY42M/nsqfkPEK4hgcO7zgzhHIFlvvSkmRPDDGQFORmkuSvBkVhPKhjpD35PmB4lxy805eG5x5jK0r4mEkyEF0063J7H1ImbrdfXxqIo3y8IUP1HPnsQYtZVp02CAaIdlw1T6KxCptxZzQ1HrN/JlgyRtTZtsjr4bfb5caLD0Ui8jgJWvYZne1EBFmE/WOPUPYVO60gOw6vvqEXpknl5CsuhyMCH4p0DF5nnvS1MuqZLMgD8ZSuTmmVvl/40qaJmCifN0tUr6ibWBX5ePGibj0bLg2X6os+NoJjTZjVoNojjRZNqSAXaz8VoA7FxZxWRNuvGwa2SaOxnxd/Lyct+h2197c2K8
            //쿠키 설정
            if(Session.cookieValue!=null && Session.cookieValue.Length > 0)
            {
                var cookie = webView.CoreWebView2
                .CookieManager
                .CreateCookie("SSOSESSION", Session.cookieValue, ".sktelecom.com", "/");
                cookie.IsHttpOnly = true;
                cookie.IsSecure = true;
                webView.CoreWebView2.CookieManager.AddOrUpdateCookie(cookie);
            }


            string eformSignUrl = Session.curDomainName + Session.eformSignUrl;
            Console.WriteLine(eformSignUrl);
            Uri eformSignURI = new Uri(eformSignUrl);
            
            webView.Source=eformSignURI;

        }



        //POST 방식 요청시
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



        private void init()
        {
            webView.CoreWebView2InitializationCompleted += CoreWebView2InitializationCompleted;
            webView.EnsureCoreWebView2Async();
        }

        private void CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (e.IsSuccess)
            {
                webView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
                webView.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged;
                webView.CoreWebView2.ContentLoading += CoreWebView2_ContentLoading;
                webView.CoreWebView2.HistoryChanged += CoreWebView2_HistoryChanged;
                webView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
                webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

                Uri eformSignURI = new Uri(Session.curDomainName + Session.eformSignUrl);
                webView.Source = eformSignURI;

                //webView.CoreWebView2.Navigate(Session.curDomainName + Session.eformSignUrl);

 
            }
        }

        public async void eformPreView(string testJson)
        {
            // string jsscript = "document.getElementById('jsonData').value";
            // string testJson = await SignPage.signPage1.webView.ExecuteScriptAsync(jsscript);

            testJson = Regex.Replace(testJson, @"/\/\*(.*?)\*\//g", "");
            Console.WriteLine(testJson);
            Console.WriteLine(JObject.Parse(testJson));

            JObject data = new JObject(
                  new JProperty("message", "start"),
                  new JProperty("data", JObject.Parse(testJson))
                );
            JObject message = new JObject(
              new JProperty("data", data.ToString())
            );
            //webView.CoreWebView2.PostWebMessageAsJson(message.ToString());



            var jsFunction = @"receivePostMessage(" + message.ToString() + ")";
            var ret = await webView.CoreWebView2.ExecuteScriptAsync(jsFunction);
        }


        private async void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            Console.WriteLine(e.WebMessageAsJson);
            HttpServer.resultString= e.WebMessageAsJson;    
        }
        private void CoreWebView2_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_ContentLoading(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_HistoryChanged(object sender, object e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void CoreWebView2_DOMContentLoaded(object sender, Microsoft.Web.WebView2.Core.CoreWebView2DOMContentLoadedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            string script = Properties.Settings.Default.AddFunc;
            webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(script);

            var jsscript = "document.getElementById('btnCancel').setAttribute('onClick','cancelSign2()');";// 취소버튼

            //완료버튼
            jsscript +=  "document.evaluate('//*[@id=\"signCompletePopup\"]/div[2]/div[2]/a', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.setAttribute('onClick','clickSignCompletePopup2()')";
            webView.CoreWebView2.ExecuteScriptAsync(jsscript);

            webView.CoreWebView2.OpenDevToolsWindow();
        }

        private async void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

        }


    }
}
