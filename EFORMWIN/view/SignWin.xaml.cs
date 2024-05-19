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
using System.Windows.Shapes;
using EFORMWIN.data;

namespace EFORMWIN.view
{
    /// <summary>
    /// SignWin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignWin : Window
    {
        public SignWin()
        {
            InitializeComponent();
            Uri eformSignURI = new Uri(Session.curDomainName + Session.eformSignUrl);
            webView.Source = eformSignURI;
        }
    }
}
