using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using EFORMWIN.classes;
using EFORMWIN.data;
using EFORMWIN.view;
using Microsoft.Win32;
using ContextMenu = System.Windows.Forms.ContextMenu;
using MenuItem = System.Windows.Forms.MenuItem;

namespace EFORMWIN
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWin;
        private static bool isRegist;
        RegistryKey runRegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        RegistryKey uriSchemeRegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\EFORMWIN", true);
       public MainWindow()
        {
            InitializeComponent();



            InitializeApplication();

            mainWin = this;
 
            //서버 시작
            HttpServer hs = new HttpServer();
            hs.Start();
        }
        private void registProgram()
        {
            runRegKey.SetValue("EFORMWIN", Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName);

        }
        //기본 초기화 및 외부호출 여부 확인
        private void InitializeApplication()
        {
             //this.WindowState = WindowState.Minimized;
             //this.Hide();

            // 시작프로그램 등록 여부 확인 후 등록
            if (uriSchemeRegKey == null)
            {
                Utils.RegisterUriScheme();
            }

            //SetNotification();

        }


        // tray 설정 start
        private void SetNotification()
        {
            NotifyIcon ni = new NotifyIcon();

            ni.Icon = Properties.Resources.Icon;
            ni.Visible = true;
            ni.Text = "EFORM_WIN";

            // NotifyIcon에 더블 클릭 이벤트 추가
            ni.DoubleClick += delegate (object sender, EventArgs eventArgs)
            {
                // 화면을 최소화 상태에서 다시 보여줍니다.
                this.Show();
                // 화면 상태를 Normal로 설정합니다.
                this.WindowState = WindowState.Maximized;
            };

            ni.ContextMenu=SetContextMenu(ni);
        }

        private ContextMenu SetContextMenu(NotifyIcon ni)
        {
            // ContextMenu 생성합니다.
            ContextMenu menu = new ContextMenu();

            // 첫번째 메뉴 "열기" MenuItem을 생성합니다.
            MenuItem item1 = new MenuItem();

            // 메뉴의 Text는 "열기"로 지정합니다.
            item1.Text = "열기";

            // "열기" 메뉴의 클릭이벤트를 설정합니다.
            item1.Click += delegate (object click, EventArgs eventArgs)
            {
                this.Show();
                this.WindowState = WindowState.Maximized;
            };

            // "열기" 메뉴를 ContextMenu에 추가합니다.
            menu.MenuItems.Add(item1);

             return menu;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
 

    }
}
