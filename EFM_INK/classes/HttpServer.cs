using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Security;
using System.Linq;
using System.Configuration;
using System.Windows.Threading;
using System.Windows;

namespace EFM_INK
{
    public class HttpServer 
    {
        public delegate void ThisDelegate();   //클래스의 맴버 변수로 delegate  선언만 해둔다..

        private HttpListener _listener;

        public void Start()
        {
              String Port  = ConfigurationManager.AppSettings.Get("serverPort");
              String HttpsPort = ConfigurationManager.AppSettings.Get("httpServerPort");
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + Port.ToString() + "/");
            _listener.Prefixes.Add("https://*:" + HttpsPort.ToString() + "/");
            _listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            _listener.Start();
            Receive();
        }

        public void Stop()
        {
            _listener.Stop();
        }

        private void Receive()
        {
            _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        }

        private void ListenerCallback(IAsyncResult result)
        {


                if (_listener.IsListening)
                {
                    var context = _listener.EndGetContext(result);
                    var request = context.Request;


                    // do something with the request
                    Console.WriteLine($"{request.HttpMethod} {request.Url}");
                    JObject reqJson =null;
                    if (request.HasEntityBody)
                    {
                        var body = request.InputStream;
                        var encoding = request.ContentEncoding;
                        var reader = new StreamReader(body, encoding);
                        if (request.ContentType != null)
                        {
                            Console.WriteLine("Client data content type {0}", request.ContentType);
                        }
                        Console.WriteLine("Client data content length {0}", request.ContentLength64);

                        Console.WriteLine("Start of data:");
                        string s = reader.ReadToEnd();
                        Console.WriteLine(s);
                        Console.WriteLine("End of data:");

                        //수신데이터 변환
                         reqJson = JObject.Parse(s);

                        reader.Close();
                        body.Close();
                    }
                    Receive();


                    var response = context.Response;
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.ContentType = "application/json";

                    // 결과  리턴
                    string resultString ="";
                try
                {
                    
                    if (request.Url.AbsolutePath.Equals("/sign_request"))
                    {
                        try
                        {
                            req2Entity(reqJson);
                            if ("default".Equals(requestEntity.sign_type) || "5g".Equals(requestEntity.sign_type))
                            {
                                App.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action((ThisDelegate)delegate
                                {
                                    initSignPad(requestEntity.sign_type);//일반서명,5G서명  초기화
                                    resultString = makeResultEntity("request");

                                    MainWindow.mainWin.WindowState = System.Windows.WindowState.Maximized;
                                    MainWindow.mainWin.Activate();
                                }));
                            }
                            else
                            {
                                resultString = errorReturnJson(requestEntity.sign_type, "signType error" + requestEntity.sign_type);
                            }
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
 

                    }
                    else if (request.Url.AbsolutePath.Equals("/sign_cancel"))
                    {
                        resultEntity.sign = "false";
                        App.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action((ThisDelegate)delegate
                        {
                            MainWindow.mainWin.erasePadAll();
                            MainWindow.mainWin.WindowState = System.Windows.WindowState.Minimized;

                        }));
                        resultString = "";
                    }
                    else if (request.Url.AbsolutePath.Equals("/sign_result"))
                    {
                           
                        App.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action((ThisDelegate)delegate
                        {
                            resultString = makeResultEntity("response");
                        }));
                    }
                }
                catch (Exception ex)
                {
                    resultString = errorReturnJson(requestEntity.sign_type, ex.Message) ;

                }

                byte[] info = Encoding.UTF8.GetBytes(resultString);
                    response.AppendHeader("Access-Control-Allow-Origin", "*"); // allow request from all origin
                    response.AppendHeader("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
                    response.AppendHeader("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin, X-Requested-With, Content-Type, Accept, Authorization");
                    response.OutputStream.Write(info, 0, info.Length);
                    response.OutputStream.Close();
                }

            //초기화 
            if (resultEntity.sign!=null && resultEntity.sign.Equals("false"))//서명완료
            {
                JArray resultArray = new JArray();
                resultEntity.sign_type = "";
                resultEntity.result = resultArray;
                requestEntity.sign_type = "";
            }

        }

        // 일반 서명 리턴 값 초기화
        private void initSignPad(string sign_type)
        {
            JArray resultArray = new JArray();
            resultEntity.sign_type = sign_type; 
            resultEntity.sign = getBool2String(MainWindow.mainWin.sign_enable.IsChecked);
            resultEntity.capture = getBool2String(MainWindow.mainWin.capture_enable.IsChecked);
        }

        private string getBool2String(bool? isValue)
        {
            string returnVal = "false";
            if ((bool)isValue) returnVal = "true";
            return returnVal;
        }

        // 에러리턴용  Json생성
        private string errorReturnJson(string signType,string errorMessage)
        {
   
            JObject returnJson = new JObject(
                  new JProperty("resultCode", "error"),
                  new JProperty("resultMsg", errorMessage)
                );

            return returnJson.ToString();


        }

        private void req2Entity(JObject reqJson)
        {
            if(reqJson!=null)
                requestEntity.sign_type = (String)reqJson["sign_type"];
        }

        //결과 생성
        private string  makeResultEntity(string curType)
        {
            if(!resultEntity.sign.Equals(""))
                resultEntity.capture = getBool2String(MainWindow.mainWin.capture_enable.IsChecked);
            JObject returnJson = new JObject();
           
            if (curType.Equals("response"))
            {
                returnJson.Add(new JProperty("sign", resultEntity.sign));
                returnJson.Add(new JProperty("capture", resultEntity.capture));
                returnJson.Add(new JProperty("result", resultEntity.result));
            }
            else
            {
                returnJson.Add(new JProperty("sign", resultEntity.sign));
                returnJson.Add(new JProperty("capture", resultEntity.capture));
            }

            return returnJson.ToString();
        }
    }
}
