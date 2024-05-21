using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace EFORMDLL
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EformControll : UserControl
    {
        public string  eformSignUrl;
        public string addScript;
        public string jsonData;
        public EformControll()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            webView.CoreWebView2InitializationCompleted += CoreWebView2InitializationCompleted;
            webView.EnsureCoreWebView2Async();
        }

        private void CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                webView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
                webView.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged;
                webView.CoreWebView2.ContentLoading += CoreWebView2_ContentLoading;
                webView.CoreWebView2.HistoryChanged += CoreWebView2_HistoryChanged;
                webView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
                webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

                Uri eformSignURI = new Uri(eformSignUrl);
                webView.Source = eformSignURI;

                //webView.CoreWebView2.Navigate(Session.curDomainName + Session.eformSignUrl);

     
                webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(addScript);

                webView.CoreWebView2.OpenDevToolsWindow();
            }
        }



        private async void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            Console.WriteLine(e.WebMessageAsJson);





        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {



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
        }

        private async void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);



        }

        private void ButTest_Click(object sender, RoutedEventArgs e)
        {
            eformPreView();
        }

        private async void eformPreView()
        {
            // string jsscript = "document.getElementById('jsonData').value";
            // string testJson = await SignPage.signPage1.webView.ExecuteScriptAsync(jsscript);

            jsonData = Regex.Replace(jsonData, @"/\/\*(.*?)\*\//g", "");
            Console.WriteLine(jsonData);
            Console.WriteLine(JObject.Parse(jsonData));

            JObject data = new JObject(
                  new JProperty("message", "start"),
                  new JProperty("data", JObject.Parse(jsonData))
                );
            JObject message = new JObject(
              new JProperty("data", data.ToString())
            );
            //webView.CoreWebView2.PostWebMessageAsJson(message.ToString());

            var jsFunction = @"receivePostMessage(" + message.ToString() + ")";
            var ret = await webView.CoreWebView2.ExecuteScriptAsync(jsFunction);
        }
    }
}
