using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EFM_MON.view
{
    /// <summary>
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Window
    {
        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;
        public Login()
        {
            InitializeComponent();

            _driverService = ChromeDriverService.CreateDefaultService();
            _driverService.HideCommandPromptWindow = true;

            _options = new ChromeOptions();
            _options.AddArgument("disable-gpu");
        }

        private void login_bt_Click(object sender, RoutedEventArgs e)
        {

            // IWebDriver driver = new ChromeDriver();
            string url = "https://e-form.sktelecom.com:8010/login/AdminLogin.do";

            string id = Id_box.Text;
            string pw = password_box.Password;

             _options.AddArgument("headless"); // 창을 숨기는 옵션입니다.

            _driver = new ChromeDriver(_driverService, _options);

            _driver.Navigate().GoToUrl(url); // 웹 사이트에 접속합니다.

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            
            // 아이디
            var idEle = _driver.FindElement(By.XPath("//*[@id=\"loginIdIn\"]"));
            idEle.SendKeys(id);
            // 비밀번호
            var pwdEle = _driver.FindElement(By.XPath("//*[@id=\"pwdIn\"]"));
            pwdEle.SendKeys(pw);

            // 로\그인버튼
            var loginBtnElement = _driver.FindElement(By.XPath("//*[@id=\"login\"]"));
            loginBtnElement.Click();

            Thread.Sleep(1000);

            //패스워드오류 여부 체크
            
            var pwdErrCheckPop = _driver.FindElement(By.XPath("//*[@id=\"layer3\"]/div/p"));
            if (pwdErrCheckPop != null && pwdErrCheckPop.Text.Length>0)
            {
                loginMessage.Content = pwdErrCheckPop.Text;
            }
            else
            {
                //인증번호 체크
                var otpInEle = _driver.FindElement(By.XPath("//*[@id=\"otpIn\"]"));
                Thread.Sleep(1000);
                if (otpInEle != null)
                {
                    loginMessage.Content = "로그인성공";
                    loginBtnElement = _driver.FindElement(By.XPath("//*[@id=\"login\"]"));
                    // 로그인버튼
                    loginBtnElement.Click();
                     this.Close();

                }
                else
                {
                    loginMessage.Content = "로그인실패";

                }

            }
            _driver.Close();
            _driver.Quit();



        }
    }
}
