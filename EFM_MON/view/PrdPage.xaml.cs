using EFM_MON.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

namespace EFM_MON.view
{
    /// <summary>
    /// DevPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PrdPage : Page
    {
        public PrdPage()
        {
            InitializeComponent();

            string prdUrl = ConfigurationManager.AppSettings.Get("prdUrl");
            string ip = CommonUtil.getLocalIpAddress();
            Uri prdURI = new Uri(prdUrl + "?ipAddr=" + ip);
            webView.Source = prdURI;


        }
    }
}
