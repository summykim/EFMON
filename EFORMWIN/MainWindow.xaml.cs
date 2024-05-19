using System;
using System.Collections.Generic;
using System.Configuration;
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
using EFORMWIN.data;
using EFORMWIN.view;

namespace EFORMWIN
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();





            Session.cookieValue = "GiRxfQslTpojTrOZw7m4viZDP5kXYl7ZfjPMEWWTjj8xioBGASqVYjFChai4DSc83XWgyAea1PyEq9DlmDicJM7DFkAkOW2kSPbdIzr3mXITsw0X1e29SVYTqcjozd4bmmmsbqJXMOpkbYfVKLcjwVXVRb0nkEbDkQfzLgL5AvXcQMfJMpwKpO3juhyz9I8dsogFFLx6rGlKqzThPKwZ8rvsK9qpwzq7vQYO2wrO6ifljGilYnYY/y2HGHjcPCrXfcr8JfctSI3uKQAGUUD1Ma7APhF8ZT7ZFF8UpIS+DyWhVIHpPzkYUMgyWyDTrBQcw9HTPB6qCAXKh/oe9soqySpqmAynED57hYwAlRriyFmB2RHYN/v/Qk1lf/Lm8Wc/QcmD5eQawzoHsAcZdt3azIHPxMaENGAD9ljhV0OaMY/2rtyAUCWbamDsbwfkaKJSAWkWn9OYyhYl0zM8+xUYGEtHNlYcwj4D04c9Kr5n+BwdRkHKceiuzhW/OnBISy7BViPnx1hoIhKshWFv4yU6domrfjWzaHMg6cP3b4+P0gPSq0guxqVDFhds4t5I5xWZoUv5gTI3kdpoQPO+V6zcYucjISjaS/JqwC/U0mTIstB/LFQRowQVkHFKOqX7G2LmQoFLHR5GXGEmwT9rRdFDL2P0L68kGV+xcV4dY42M/nsqfkPEK4hgcO7zgzhHIFlvvSkmRPDDGQFORmkuSvBkVhPKhjpD35PmB4lxy805eG5x5jK0r4mEkyEF0063J7H1ImbrdfXxqIo3y8IUP1HPnsQYtZVp02CAaIdlw1T6KxCptxZzQ1HrN/JlgyRtTZtsjr4bfb5caLD0Ui8jgJWvYZne1EBFmE/WOPUPYVO60gOw6vvqEXpknl5CsuhyMCH4p0DF5nnvS1MuqZLMgD8ZSuTmmVvl/40qaJmCifN0tUr6ibWBX5ePGibj0bLg2X6os+NoJjTZjVoNojjRZNqSAXaz8VoA7FxZxWRNuvGwa2SaOxnxd/Lyct+h2197c2K8";
            Session.curDomainName = Session.inDomainName;

        }

        //기본 초기화 및 외부호출 여부 확인
        private void InitializeApplication()
        {
            Session.isLoginSuccess = false;


        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            SignWin signWin = new SignWin();
            signWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            signWin.WindowState = WindowState.Maximized;
            if (signWin.ShowDialog() == true)
            {

            }
        }

        private void btnSignTest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
