using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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

        Mutex mutex = null;
        public App()
        {
            // 어플리케이션 이름 확인
            string applicationName = Process.GetCurrentProcess().ProcessName;
            Duplicate_execution(applicationName);

        }
        /// <summary>
        /// 중복실행방지
        /// </summary>
        /// <param name="mutexName"></param>
        private void Duplicate_execution(string mutexName)
        {
            try
            {
                mutex = new Mutex(false, mutexName); // 뮤텍스 설정
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Current.Shutdown(); // 프로그램 종료
            }

            if (!mutex.WaitOne(0, false)) // 프로그램 실행 중
            {
                MessageBox.Show("Application Already Started");
                Application.Current.Shutdown();  // 프로그램 종료
            }
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
            if (e.Args.Length > 0)
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
                
                if (e.Args.Length > 1)
                {
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
