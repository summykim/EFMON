﻿using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Security;
using System.Linq;
using System.Configuration;
using System.Windows.Threading;

namespace EFM_INK
{
    public class HttpServer 
    {
        public delegate void ThisDelegate();   //클래스의 맴버 변수로 delegate  선언만 해둔다..

        private HttpListener _listener;

        public void Start()
        {
              String Port  = ConfigurationManager.AppSettings.Get("serverPort");
             _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + Port.ToString() + "/");
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
                        req2Entity(reqJson);
                        if ("default".Equals(requestEntity.sign_type) || "5g".Equals(requestEntity.sign_type))
                        {
                            initSignPad(requestEntity.sign_type);//일반서명,5G서명  초기화
                            resultString = makeResultEntity();

                            App.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action((ThisDelegate)delegate
                            {
                                if (!"5g".Equals(requestEntity.sign_type))
                                {
                                    MainWindow.mainWin.cInkCanvas.Visibility = System.Windows.Visibility.Hidden;
                                    MainWindow.mainWin.cDockCanvas.Visibility = System.Windows.Visibility.Hidden;
                                    MainWindow.mainWin.cInkCanvas.Visibility=   System.Windows.Visibility.Hidden;
                                }
                                else
                                {
                                    MainWindow.mainWin.cCanvas.Visibility = System.Windows.Visibility.Visible;
                                    MainWindow.mainWin.cDockCanvas.Visibility = System.Windows.Visibility.Visible;
                                    MainWindow.mainWin.cInkCanvas.Visibility = System.Windows.Visibility.Visible;
                                }
                                   
                                MainWindow.mainWin.WindowState = System.Windows.WindowState.Maximized;
                                MainWindow.mainWin.Activate();
                            }));
                        }
                        else
                        {
                            resultString = errorReturnJson(requestEntity.sign_type, "signType error"+ requestEntity.sign_type);
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
                           resultString = makeResultEntity();

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
            if (resultEntity.sign.Equals("false"))//서명완료
            {
                JArray resultArray = new JArray();
                resultEntity.sign_type = "";
                resultEntity.sign = "";
                resultEntity.capture = "";
                resultEntity.result = resultArray;

                requestEntity.sign_type = "";
            }

        }

        // 일반 서명 리턴 값 초기화
        private void initSignPad(string sign_type)
        {
            JArray resultArray = new JArray();
            resultEntity.sign_type = sign_type; 
            resultEntity.sign = "true";
            resultEntity.capture = "true";
            resultEntity.result = resultArray;

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
            requestEntity.sign_type = (String)reqJson["sign_type"];
        }

        //결과 생성
        private string  makeResultEntity()
        {
            JObject returnJson = new JObject(
              new JProperty("sign", resultEntity.sign),
              new JProperty("capture", resultEntity.capture),
              new JProperty("result", resultEntity.result)
             );
            return returnJson.ToString();
        }
    }
}
