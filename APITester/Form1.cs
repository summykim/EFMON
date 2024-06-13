using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace APITester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetURL = this.txtTargetURL.Text;

            string responseStr = callHttpRequest(targetURL, this.txtJsonData.Text, this.txtContenType.Text);

            Console.Write(responseStr);

            cancel_result.Text = responseStr;
        }

        public static string callWebClient(String targetURL)
        {
            string result = string.Empty;
            try
            {
                WebClient client = new WebClient();

                //특정 요청 헤더값을 추가해준다. 
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                using (Stream data = client.OpenRead(targetURL))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string s = reader.ReadToEnd();
                        result = s;

                        reader.Close();
                        data.Close();
                    }
                }

            }
            catch (Exception e)
            {
                //통신 실패시 처리로직
                Console.WriteLine(e.ToString());
            }
            return result;
        }


        public static string callWebRequest(String targetURL, String data, string contentType)
        {
            string responseFromServer = string.Empty;

            try
            {




                targetURL = targetURL + "?data=" + data;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetURL);
                request.Method = "POST";
                request.ContentType = contentType;

                Uri target = new Uri("https://e-form.sktelecom.com:8010");
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(new Cookie("JSESSIONID", "ACD2B4FAA89C32C5DE441779C28FCDBA.node21") { Domain = target.Host });


                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    responseFromServer = reader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return responseFromServer;
        }

        public static string callHttpRequest(String targetURL, String json, string contentType)
        {
            JObject jsonObject = JObject.Parse(json);

            var request = (HttpWebRequest)WebRequest.Create(targetURL);
            Uri target = new Uri("https://e-form.sktelecom.com:8010");
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("JSESSIONID", "ACD2B4FAA89C32C5DE441779C28FCDBA.node21") { Domain = target.Host });

            var postData = "data=" + Uri.EscapeDataString(jsonObject.ToString());
            var data = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
