using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using EFORMWIN.data;
using Microsoft.Win32;
using Winforms = System.Windows.Forms;

namespace EFORMWIN
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {

            Session.outDomainName = ConfigurationManager.AppSettings.Get("eformSignOutDomain");
            Session.inDomainName = ConfigurationManager.AppSettings.Get("eformSignInDomain");

            Session.eformSignUrl = ConfigurationManager.AppSettings.Get("eformSignUrl");
            Session.eformTestSignUrl = ConfigurationManager.AppSettings.Get("eformTestSignUrl");
            Session.eformLoginUrl = ConfigurationManager.AppSettings.Get("eformLoginUrl");
            Session.cookieName = ConfigurationManager.AppSettings.Get("cookieName");
            Session.isLoginSuccess = false;
            Session.isOutDomain = false;


            //프로그램  아규먼트 확인
            if (e.Args.Length > 0)
            {
                System.Windows.MessageBox.Show(e.Args[0]);

                if (e.Args[0].StartsWith("eformwin") )
                {
                    var arrArgs = e.Args[0].Split('/');

                    string cookiename = arrArgs[2];
                    string cookieVal= arrArgs[3];

                    if (cookiename.Equals(Session.cookieName))//cookieName(내부망
                    {
                        Session.curDomainName = Session.inDomainName;
                        Session.cookieName= ".sktelecom.com";
                    }
                    else //외부망
                    {
                        Session.cookieName = "JSESSIONID";
                        Session.curDomainName = Session.outDomainName;
                        Session.cookieDomain = "e-form.sktelecom.com";
                        Session.isOutDomain = true;
                    }
                    Session.cookieValue = cookieVal;
 
                }
                else
                {
                    if (e.Args[0].Equals(Session.cookieName))//cookieName(내부망
                    {
                        Session.curDomainName = Session.inDomainName;
                    }
                    else //외부망
                    {
                        Session.curDomainName = Session.outDomainName;
                        Session.isOutDomain = true;
                    }



                }


            }

            //도메인 설정
            if (Session.isOutDomain)//외부망
            {
                Session.curDomainName = Session.outDomainName;
            }
            else { //내부망
                Session.curDomainName = Session.inDomainName;
            }

            base.OnStartup(e);


        }






    }
}
