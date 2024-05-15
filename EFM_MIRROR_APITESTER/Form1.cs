using EFMSIGN;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFM_MIRROR_APITESTER
{
    public partial class formMain : Form
    {
        HttpServer server;
        public static formMain form;

        Pen cursorPen = SystemPens.ControlText;
        List<Point> points = new List<Point>();
        bool cursorMoving = false;

        Pen ncursorPen = SystemPens.ControlText;
        List<Point> npoints = new List<Point>();
        bool ncursorMoving = false;

        Pen ccursorPen = SystemPens.ControlText;
        List<Point> cpoints = new List<Point>();
        bool ccursorMoving = false;

        public formMain()
        {
            form = this;
            InitializeComponent();
           this.Text = "미러링API 테스트 ["+Application.ProductVersion+"]";

            CheckForIllegalCrossThreadCalls = false;

            serverStartBtn.Enabled = true;
            serverStopBtn.Enabled = false;
            serverStatusLabel.Text = "서버중지";


            cursorPen = new Pen(Color.Red, 2);
            cursorPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            cursorPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            ncursorPen = new Pen(Color.Black, 2);
            ncursorPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            ncursorPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            ccursorPen = new Pen(Color.Blue, 2);
            ccursorPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            ccursorPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }


        private void formMain_Load(object sender, EventArgs e)
        {

        }

        private void serverStartBtn_Click(object sender, EventArgs e)
        {
            //서버시작
            server = new HttpServer();
            server.Start();
            serverStartBtn.Enabled = false;
            serverStopBtn.Enabled = true;
            serverStatusLabel.Text = "서버기동중..";

        }

        private void serverStopBtn_Click(object sender, EventArgs e)
        {
            //서버중지
            server.Stop();
            serverStartBtn.Enabled = true;
            serverStopBtn.Enabled = false;
            serverStatusLabel.Text = "서버중지";

        }

        // 이름 서명 패드
        private void ssignPad_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 1; i < points.Count; ++i)
                g.DrawLine(cursorPen, points[i - 1], points[i]);
        }

        private void ssignPad_MouseDown(object sender, MouseEventArgs e)
        {
            if (!cursorMoving)
            {
                cursorMoving = true;
                points.Clear();
                points.Add(e.Location);
                ssignPad.Invalidate();
            }
        }

        private void ssignPad_MouseMove(object sender, MouseEventArgs e)
        {
            if (cursorMoving && points.Count > 0)
            {
                var p = e.Location;
                var q = points[points.Count - 1];
                var r = Rectangle.FromLTRB(Math.Min(p.X, q.X), Math.Min(p.Y, q.Y), Math.Max(p.X, q.X), Math.Max(p.Y, q.Y));
                r = Rectangle.Inflate(r, (int)cursorPen.Width, (int)cursorPen.Width);

                points.Add(p);
                ssignPad.Invalidate(r);
            }
        }
        private void signPad_MouseUp(object sender, MouseEventArgs e)
        {
            cursorMoving = false;
        }


        // 이름 패드
        private void nsignPad_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 1; i < npoints.Count; ++i)
                g.DrawLine(ncursorPen, npoints[i - 1], npoints[i]);
        }

        private void nsignPad_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ncursorMoving)
            {
                ncursorMoving = true;
                npoints.Clear();
                npoints.Add(e.Location);
                nsignPad.Invalidate();
            }
        }

        private void nsignPad_MouseMove(object sender, MouseEventArgs e)
        {
            if (ncursorMoving && npoints.Count > 0)
            {
                var p = e.Location;
                var q = npoints[npoints.Count - 1];
                var r = Rectangle.FromLTRB(Math.Min(p.X, q.X), Math.Min(p.Y, q.Y), Math.Max(p.X, q.X), Math.Max(p.Y, q.Y));
                r = Rectangle.Inflate(r, (int)ncursorPen.Width, (int)ncursorPen.Width);

                npoints.Add(p);
                nsignPad.Invalidate(r);
            }
        }
        private void nsignPad_MouseUp(object sender, MouseEventArgs e)
        {
            ncursorMoving = false;
        }

        //  5G 서명 패드
        private void csignPad_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 1; i < cpoints.Count; ++i)
                g.DrawLine(ccursorPen, cpoints[i - 1], cpoints[i]);
        }

        private void csignPad_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ccursorMoving)
            {
                ccursorMoving = true;
                cpoints.Clear();
                cpoints.Add(e.Location);
                csignPad.Invalidate();
            }
        }

        private void csignPad_MouseMove(object sender, MouseEventArgs e)
        {
            if (ccursorMoving && cpoints.Count > 0)
            {
                var p = e.Location;
                var q = cpoints[cpoints.Count - 1];
                var r = Rectangle.FromLTRB(Math.Min(p.X, q.X), Math.Min(p.Y, q.Y), Math.Max(p.X, q.X), Math.Max(p.Y, q.Y));
                r = Rectangle.Inflate(r, (int)ccursorPen.Width, (int)ccursorPen.Width);

                cpoints.Add(p);
                csignPad.Invalidate(r);
            }
        }

        private void csignPad_MouseUp(object sender, MouseEventArgs e)
        {
            ccursorMoving = false;
        }

        private String PanelToBase64(Control pnl)
        {
            var bmp = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            var SigBase64 = "";
            using (var ms = new MemoryStream())
            {
                using (var bitmap = new Bitmap(bmp))
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    SigBase64 = Convert.ToBase64String(ms.GetBuffer()); //Get Base64
                }
            }
            Console.WriteLine("SigBase64");
            SigBase64 = "data:image/jpg;base64," + SigBase64;
            Console.WriteLine(SigBase64);
            return SigBase64;

        }

        private void btnnsignOk_Click(object sender, EventArgs e)
        {
            String nsignImage = PanelToBase64(nsignPad);//이름
            String ssignImage = PanelToBase64(ssignPad);//서명

            /*
            {
                "resultCode":"success",
                "resultMsg":"",
                 "result"[
                       { "signPadId":"nsignSignPad","base64Img":""},
                       { "signPadId":"ssignSignPad","base64Img":""}
                 ] 
             }
             */

            JObject nsignJson = new JObject(
               new JProperty("signPadId", "nsignSignPad"),
               new JProperty("base64Img", nsignImage)
            );
            JObject ssignJson = new JObject(
                    new JProperty("signPadId", "ssignSignPad"),
                    new JProperty("base64Img", ssignImage)
                 );

            JArray resultArray = new JArray();
            resultArray.Add(nsignJson);
            resultArray.Add(ssignJson);

            JObject returnJson = new JObject(
                  new JProperty("resultCode", "success"),
                  new JProperty("resultMsg", "성공"),
                  new JProperty("result", resultArray)
                );

            //결과 화면에 추가
            result_result.Text= returnJson.ToString();

        }

        //5G 서명 생성
        private void btnn5GsignOk_Click(object sender, EventArgs e)
        {
            String csignImage = PanelToBase64(csignPad);//5G

            JObject csignJson = new JObject(
               new JProperty("signPadId", "csignSignPad"),
               new JProperty("base64Img", csignImage)
            );


            JArray resultArray = new JArray();
            resultArray.Add(csignJson);


            JObject returnJson = new JObject(
                  new JProperty("resultCode", "success"),
                  new JProperty("resultMsg", "성공"),
                  new JProperty("result", resultArray)
                );

            //결과 화면에 추가
            result_result_5G.Text = returnJson.ToString();
        }
    }

        
}
