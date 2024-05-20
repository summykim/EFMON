using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EFORMWIN.data;

namespace EFORMWIN
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {

 
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
            if (e.Args.Length > 0)
            {
                if (e.Args[0].Equals(Session.cookieName))//cookieName(내부망
                {
                    Session.curDomainName = Session.inDomainName;
                    Session.cookieValue = e.Args[1];
                }
                if (e.Args[0].Equals(Session.cookieName))//cookieName(내부망
                {
                    Session.curDomainName = Session.outDomainName;
                    Session.isOutDomain = true;
                    Session.cookieValue = e.Args[1];
                }
            }

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
