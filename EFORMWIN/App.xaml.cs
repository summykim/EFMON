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
            Session.outDomainName = ConfigurationManager.AppSettings.Get("eformSignOutDomain");
            Session.inDomainName = ConfigurationManager.AppSettings.Get("eformSignInDomain");

            Session.eformSignUrl = ConfigurationManager.AppSettings.Get("eformSignUrl");
            Session.eformTestSignUrl = ConfigurationManager.AppSettings.Get("eformTestSignUrl");
            Session.eformLoginUrl = ConfigurationManager.AppSettings.Get("eformLoginUrl");
            Session.cookieName = ConfigurationManager.AppSettings.Get("cookieName");
            Session.isLoginSuccess = false;
            if (e.Args.Length > 0)
            {
                if (e.Args[0].Equals(Session.cookieName))//cookieName(내부망
                {
                    Session.cookieValue = "GiRxfQslTpojTrOZw7m4viZDP5kXYl7ZfjPMEWWTjj8xioBGASqVYjFChai4DSc83XWgyAea1PyEq9DlmDicJM7DFkAkOW2kSPbdIzr3mXITsw0X1e29SVYTqcjozd4bmmmsbqJXMOpkbYfVKLcjwVXVRb0nkEbDkQfzLgL5AvXcQMfJMpwKpO3juhyz9I8dsogFFLx6rGlKqzThPKwZ8rvsK9qpwzq7vQYO2wrO6ifljGilYnYY/y2HGHjcPCrXfcr8JfctSI3uKQAGUUD1Ma7APhF8ZT7ZFF8UpIS+DyWhVIHpPzkYUMgyWyDTrBQcw9HTPB6qCAXKh/oe9soqySpqmAynED57hYwAlRriyFmB2RHYN/v/Qk1lf/Lm8Wc/QcmD5eQawzoHsAcZdt3azIHPxMaENGAD9ljhV0OaMY/2rtyAUCWbamDsbwfkaKJSAWkWn9OYyhYl0zM8+xUYGEtHNlYcwj4D04c9Kr5n+BwdRkHKceiuzhW/OnBISy7BViPnx1hoIhKshWFv4yU6domrfjWzaHMg6cP3b4+P0gPSq0guxqVDFhds4t5I5xWZoUv5gTI3kdpoQPO+V6zcYucjISjaS/JqwC/U0mTIstB/LFQRowQVkHFKOqX7G2LmQoFLHR5GXGEmwT9rRdFDL2P0L68kGV+xcV4dY42M/nsqfkPEK4hgcO7zgzhHIFlvvSkmRPDDGQFORmkuSvBkVhPKhjpD35PmB4lxy805eG5x5jK0r4mEkyEF0063J7H1ImbrdfXxqIo3y8IUP1HPnsQYtZVp02CAaIdlw1T6KxCptxZzQ1HrN/JlgyRtTZtsjr4bfb5caLD0Ui8jgJWvYZne1EBFmE/WOPUPYVO60gOw6vvqEXpknl5CsuhyMCH4p0DF5nnvS1MuqZLMgD8ZSuTmmVvl/40qaJmCifN0tUr6ibWBX5ePGibj0bLg2X6os+NoJjTZjVoNojjRZNqSAXaz8VoA7FxZxWRNuvGwa2SaOxnxd/Lyct+h2197c2K8";
                    Session.curDomainName = Session.inDomainName;
                }
            }


            Session.cookieValue = "GiRxfQslTpojTrOZw7m4viZDP5kXYl7ZfjPMEWWTjj8xioBGASqVYjFChai4DSc83XWgyAea1PyEq9DlmDicJM7DFkAkOW2kSPbdIzr3mXITsw0X1e29SVYTqcjozd4bmmmsbqJXMOpkbYfVKLcjwVXVRb0nkEbDkQfzLgL5AvXcQMfJMpwKpO3juhyz9I8dsogFFLx6rGlKqzThPKwZ8rvsK9qpwzq7vQYO2wrO6ifljGilYnYY/y2HGHjcPCrXfcr8JfctSI3uKQAGUUD1Ma7APhF8ZT7ZFF8UpIS+DyWhVIHpPzkYUMgyWyDTrBQcw9HTPB6qCAXKh/oe9soqySpqmAynED57hYwAlRriyFmB2RHYN/v/Qk1lf/Lm8Wc/QcmD5eQawzoHsAcZdt3azIHPxMaENGAD9ljhV0OaMY/2rtyAUCWbamDsbwfkaKJSAWkWn9OYyhYl0zM8+xUYGEtHNlYcwj4D04c9Kr5n+BwdRkHKceiuzhW/OnBISy7BViPnx1hoIhKshWFv4yU6domrfjWzaHMg6cP3b4+P0gPSq0guxqVDFhds4t5I5xWZoUv5gTI3kdpoQPO+V6zcYucjISjaS/JqwC/U0mTIstB/LFQRowQVkHFKOqX7G2LmQoFLHR5GXGEmwT9rRdFDL2P0L68kGV+xcV4dY42M/nsqfkPEK4hgcO7zgzhHIFlvvSkmRPDDGQFORmkuSvBkVhPKhjpD35PmB4lxy805eG5x5jK0r4mEkyEF0063J7H1ImbrdfXxqIo3y8IUP1HPnsQYtZVp02CAaIdlw1T6KxCptxZzQ1HrN/JlgyRtTZtsjr4bfb5caLD0Ui8jgJWvYZne1EBFmE/WOPUPYVO60gOw6vvqEXpknl5CsuhyMCH4p0DF5nnvS1MuqZLMgD8ZSuTmmVvl/40qaJmCifN0tUr6ibWBX5ePGibj0bLg2X6os+NoJjTZjVoNojjRZNqSAXaz8VoA7FxZxWRNuvGwa2SaOxnxd/Lyct+h2197c2K8";
            Session.curDomainName = Session.inDomainName;

            base.OnStartup(e);
        }
    }
}
