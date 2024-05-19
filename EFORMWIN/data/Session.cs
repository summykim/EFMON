using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFORMWIN.data
{
    static class Session
    {  
        public static bool isLoginSuccess { get; set; }
        public static string curDomainName { get;set; }
        public static string outDomainName { get;set;}
        public static string inDomainName { get;set;}
        public static string eformSignUrl {  get;set; }
        public static string eformTestSignUrl { get; set; }
        public static string eformLoginUrl { get; set; }

        public static string cookieName { get;set; }        
        public static string cookieValue { get;set;}
        public static string cookieDomain { get;set;}

    }
}
