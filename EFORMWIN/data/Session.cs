using EFORMWIN.view;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EFORMWIN.data
{
    static class Session
    {  
        public static bool isLoginSuccess { get; set; }
        public static bool isOutDomain { get; set; }
        public static string curDomainName { get;set; }
        public static string outDomainName { get;set;}
        public static string inDomainName { get;set;}
        public static string eformSignUrl {  get;set; }
        public static string eformTestSignUrl { get; set; }
        public static string eformLoginUrl { get; set; }

        public static string cookieName { get;set; }        
        public static string cookieValue { get;set;}
        public static string cookieDomain { get;set;}

        public static async void LoginCheckAsync(Microsoft.Web.WebView2.Wpf.WebView2  webView)
        {
            isLoginSuccess = Session.isLoginSuccess;
            if(!isLoginSuccess) { 
                // SSO  체크 
                var cookies = await webView.CoreWebView2
                .CookieManager
                .GetCookiesAsync("https://sktelecom.com");

                foreach (CoreWebView2Cookie cookie in cookies)
                {
                    if (cookie.Name.Equals(Session.cookieName) )
                    {//세션이 존재하면 
                        isLoginSuccess = true;
                        break;
                    }
                }
            }
            if (!isLoginSuccess)
            {
                // 비상로그인 체크 
                var cookies = await webView.CoreWebView2
            .CookieManager
            .GetCookiesAsync("https://e-form.sktelecom.com");

                foreach (CoreWebView2Cookie cookie in cookies)
                {
                    if (cookie.Name.Equals("JSESSIONID") )
                    {
                        isLoginSuccess = true;
                        break;
                    }
                }
            }

            Session.isLoginSuccess = isLoginSuccess;
        }

        public static async 
        Task
showSingWin()
        {
            SignWin signWin = new SignWin();
            signWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            signWin.WindowState = WindowState.Maximized;
            signWin.Show();
        }

    }
}
