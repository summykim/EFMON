using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Security;
using System.Linq;
using EFORMWIN.view;
using System.Windows;
using System.Windows.Threading;
using System.Collections.Generic;
namespace EFORMWIN
{
    public  class HttpServer 
    {

        private  HttpListener _listener;

        public delegate void ThisDelegate();   //클래스의 맴버 변수로 delegate  선언만 해둔다..
  
        public static string resultString;//전송 결과  json

        public  void Start()
        {
              String Port = "18182";
             _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + Port.ToString() + "/");
            _listener.Start();
            Receive();
        }

        public  void Stop()
        {
            _listener.Stop();
        }

        private  void Receive()
        {
            _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        }

        private  void ListenerCallback(IAsyncResult result)
        {

                if (_listener.IsListening)
                {
                    var context = _listener.EndGetContext(result);
                    var request = context.Request;
                    // 결과  리턴
                    string resultString = "";

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
                        string jsonString = reader.ReadToEnd();
                        Console.WriteLine(jsonString);
                        Console.WriteLine("End of data:");

                         //reqJson = JObject.Parse(jsonString);

                        //수신데이터표시
                        if (request.Url.AbsolutePath.Equals("/sign_request"))
                        {
                            App.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action((ThisDelegate)delegate
                            {
                                SignPage.signPage1.Visibility = Visibility.Visible; 
                                SignPage.signPage1.eformPreView(jsonString);
                            }));
                       
                        
                        }                      
                        else if (request.Url.AbsolutePath.Equals("/sign_result"))
                        {
                            if(HttpServer.resultString != null && HttpServer.resultString.Length > 0)
                            {
                                 resultString=HttpServer.resultString;
                            }                          
                        }
                        reader.Close();
                        body.Close();
                    }
                    Receive();


                    var response = context.Response;
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.ContentType = "application/json";
    

                byte[] info = Encoding.UTF8.GetBytes(resultString);
                    response.AppendHeader("Access-Control-Allow-Origin", "*"); // allow request from all origin
                    response.AppendHeader("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
                    response.AppendHeader("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin, X-Requested-With, Content-Type, Accept, Authorization");
                    response.OutputStream.Write(info, 0, info.Length);
                    response.OutputStream.Close();
                }

        }
        private void eformPreView(string  jsonString)
        {
            SignPage.signPage1.eformPreView(jsonString);
        }


    }
}
