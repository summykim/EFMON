using System;
using System.Net;
using System.IO;
using System.Text;
using EFM_MIRROR_APITESTER;
using Newtonsoft.Json.Linq;
using System.Security;
using System.Linq;
using System.Windows.Forms;

namespace EFMSIGN
{
    public class HttpServer 
    {
       

        private HttpListener _listener;

        public void Start()
        {
              String Port = formMain.form.httpPort.Text;
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

            String signType = "default";
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

                         reqJson = JObject.Parse(s);

                        //수신데이터표시
                        if (request.Url.AbsolutePath.Equals("/sign_request"))
                        {
                            formMain.form.req_param.Text = s;
                        }
                        else if (request.Url.AbsolutePath.Equals("/sign_cancel"))
                        {
                            formMain.form.cancel_param.Text = s;
                        }                       
                        else if (request.Url.AbsolutePath.Equals("/sign_result"))
                        {
                            formMain.form.result_param.Text = s;
                        }



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
                    signType = (String)reqJson["sign_type"];
                    if (request.Url.AbsolutePath.Equals("/sign_request"))
                    {
                        resultString = formMain.form.req_result.Text;
                        if ("default".Equals(signType))
                        {
                            initSignPad();//일반서명
                        }
                        else if ("5g".Equals(signType.ToLower()))
                        {
                            init5gSignPad();//5G서명
                        }
                        else
                        {
                            resultString = errorReturnJson(signType, "signType error"+ signType);
                        }

                    }
                    else if (request.Url.AbsolutePath.Equals("/sign_cancel"))
                    {
                        resultString = formMain.form.cancel_result.Text;
                    }
                    else if (request.Url.AbsolutePath.Equals("/sign_result"))
                    {

                        if ("default".Equals(signType))
                        {
                            resultString = formMain.form.result_result.Text;
                        }
                        else if ("5g".Equals(signType.ToLower()))
                        {
                            resultString = formMain.form.result_result_5G.Text;
                        }
                    }
                }
                catch (Exception ex)
                {
                    formMain.form.statusTxt.Text = ex.Message;
                    resultString = errorReturnJson(signType, ex.Message) ;

                }

                byte[] info = Encoding.UTF8.GetBytes(resultString);
                    response.AppendHeader("Access-Control-Allow-Origin", "*"); // allow request from all origin
                    response.AppendHeader("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
                    response.AppendHeader("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin, X-Requested-With, Content-Type, Accept, Authorization");
                    response.OutputStream.Write(info, 0, info.Length);
                    response.OutputStream.Close();
                }

        }

        // 일반 서명 리턴 값 초기화
        private void initSignPad()
        {
            JArray resultArray = new JArray();

            JObject returnJson = new JObject(
                  new JProperty("sign", "true"),
                  new JProperty("capture", "true"),
                  new JProperty("result", resultArray)
                );

            //결과 화면에 추가
            formMain.form.result_result.Text = returnJson.ToString();

        }

        // 5G 서명 리턴 값 초기화
        private void init5gSignPad()
        {
            JArray resultArray = new JArray();


            JObject returnJson = new JObject(
                    new JProperty("sign", "true"),
                    new JProperty("capture", "true"),
                    new JProperty("result", resultArray)
                );

            //결과 화면에 추가(초기화)
            formMain.form.result_result_5G.Text = returnJson.ToString();
        }

        // 에러리턴용  Json생성
        private string errorReturnJson(string signType,string errorMessage)
        {
            String csignImage = "";//5G



            JObject returnJson = new JObject(
                  new JProperty("resultCode", "error"),
                  new JProperty("resultMsg", errorMessage)
                );

            return returnJson.ToString();


        }
    }
}
