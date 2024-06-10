using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
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

namespace EFM_INK
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWin;
        public MainWindow()
        {
            InitializeComponent();
            mainWin = this;

            //서버 시작
            HttpServer hs = new HttpServer();
            hs.Start();
        }

        private void RightMouseUpHandler(object sender,
                                 System.Windows.Input.MouseButtonEventArgs e)
        {
            Matrix m = new Matrix();
            m.Scale(1.1d, 1.1d);
            ((InkCanvas)sender).Strokes.Transform(m, true);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String csignImage = "";
                if (resultEntity.sign_type.Equals(""))
                {
                    MessageBox.Show("서명요청이후  시도해주세요.");
                    erasePadAll();
                    return;
                }
                
                if (resultEntity.sign_type.Equals("5g")) csignImage = cInkCanvas.ExportBase64(1);

                String nsignImage = nInkCanvas.ExportBase64(1);
                String ssignImage = sInkCanvas.ExportBase64(1);





                 resultEntity.result = makeImageArr(csignImage, nsignImage, ssignImage);
                 resultEntity.sign = "false"; //서명완료처리
                erasePadAll();
                this.WindowState = System.Windows.WindowState.Minimized;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         
        //전체 패드 초기화
        public void erasePadAll()
        {
            cInkCanvas.Strokes.Erase(new Rect(0, 0, cInkCanvas.ActualWidth, cInkCanvas.ActualHeight));
            nInkCanvas.Strokes.Erase(new Rect(0, 0, nInkCanvas.ActualWidth, nInkCanvas.ActualHeight));
            sInkCanvas.Strokes.Erase(new Rect(0, 0, sInkCanvas.ActualWidth, sInkCanvas.ActualHeight));

        }

        private JArray makeImageArr(String csignImage, String nsignImage, String ssignImage)
        {
  
            JObject nsignJson = new JObject(
               new JProperty("signPadId", "nsignSignPad"),
               new JProperty("base64Img", nsignImage)
            );
            JObject ssignJson = new JObject(
                    new JProperty("signPadId", "ssignSignPad"),
                    new JProperty("base64Img", ssignImage)
                 );
            JObject csignJson = new JObject(
               new JProperty("signPadId", "csignSignPad"),
               new JProperty("base64Img", csignImage)
            );


            JArray resultArray = new JArray();
            resultArray.Add(nsignJson);
            resultArray.Add(ssignJson);
            if (resultEntity.sign_type.Equals("5g"))
            {
                resultArray.Add(csignJson);
            }
            
            return  resultArray;
        }

    
    }
}
