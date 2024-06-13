namespace EFM_MIRROR_APITESTER
{
    partial class formMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusBar = new System.Windows.Forms.Label();
            this.apiTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.req_result = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.req_param = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnn5GsignOk = new System.Windows.Forms.Button();
            this.btnnsignOk = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.csignPad = new System.Windows.Forms.Panel();
            this.nsignPad = new System.Windows.Forms.Panel();
            this.ssignPad = new System.Windows.Forms.Panel();
            this.result_result_5G = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.result_result = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.result_param = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtTargetURL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtJsonData = new System.Windows.Forms.TextBox();
            this.cancel_result = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancel_param = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverStartBtn = new System.Windows.Forms.Button();
            this.serverStopBtn = new System.Windows.Forms.Button();
            this.serverStatusLabel = new System.Windows.Forms.Label();
            this.httpPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statusTxt = new System.Windows.Forms.TextBox();
            this.txtContenType = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.apiTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusBar);
            this.panel1.Controls.Add(this.apiTabs);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 512);
            this.panel1.TabIndex = 0;
            // 
            // statusBar
            // 
            this.statusBar.AutoSize = true;
            this.statusBar.Location = new System.Drawing.Point(26, 511);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(0, 12);
            this.statusBar.TabIndex = 1;
            // 
            // apiTabs
            // 
            this.apiTabs.Controls.Add(this.tabPage1);
            this.apiTabs.Controls.Add(this.tabPage4);
            this.apiTabs.Controls.Add(this.tabPage2);
            this.apiTabs.Location = new System.Drawing.Point(28, 26);
            this.apiTabs.Name = "apiTabs";
            this.apiTabs.SelectedIndex = 0;
            this.apiTabs.Size = new System.Drawing.Size(1066, 481);
            this.apiTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.req_result);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.req_param);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(1058, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "서명요청";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // req_result
            // 
            this.req_result.BackColor = System.Drawing.SystemColors.Info;
            this.req_result.Location = new System.Drawing.Point(137, 189);
            this.req_result.Multiline = true;
            this.req_result.Name = "req_result";
            this.req_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.req_result.Size = new System.Drawing.Size(637, 97);
            this.req_result.TabIndex = 3;
            this.req_result.Text = "{\r\n \"sign\":\"true\",\r\n  \"capture\":\"true\"\r\n}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "리턴결과:";
            // 
            // req_param
            // 
            this.req_param.BackColor = System.Drawing.SystemColors.Info;
            this.req_param.Location = new System.Drawing.Point(137, 35);
            this.req_param.Multiline = true;
            this.req_param.Name = "req_param";
            this.req_param.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.req_param.Size = new System.Drawing.Size(637, 113);
            this.req_param.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "요청파라미터:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnn5GsignOk);
            this.tabPage4.Controls.Add(this.btnnsignOk);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.csignPad);
            this.tabPage4.Controls.Add(this.nsignPad);
            this.tabPage4.Controls.Add(this.ssignPad);
            this.tabPage4.Controls.Add(this.result_result_5G);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.result_result);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.result_param);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1058, 455);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "서명결과조회";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnn5GsignOk
            // 
            this.btnn5GsignOk.BackColor = System.Drawing.Color.Silver;
            this.btnn5GsignOk.Location = new System.Drawing.Point(771, 384);
            this.btnn5GsignOk.Name = "btnn5GsignOk";
            this.btnn5GsignOk.Size = new System.Drawing.Size(170, 27);
            this.btnn5GsignOk.TabIndex = 21;
            this.btnn5GsignOk.Text = "5g서명완료";
            this.btnn5GsignOk.UseVisualStyleBackColor = false;
            this.btnn5GsignOk.Click += new System.EventHandler(this.btnn5GsignOk_Click);
            // 
            // btnnsignOk
            // 
            this.btnnsignOk.BackColor = System.Drawing.Color.Silver;
            this.btnnsignOk.Location = new System.Drawing.Point(767, 40);
            this.btnnsignOk.Name = "btnnsignOk";
            this.btnnsignOk.Size = new System.Drawing.Size(169, 27);
            this.btnnsignOk.TabIndex = 20;
            this.btnnsignOk.Text = "일반서명완료";
            this.btnnsignOk.UseVisualStyleBackColor = false;
            this.btnnsignOk.Click += new System.EventHandler(this.btnnsignOk_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(624, 317);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 19);
            this.label13.TabIndex = 19;
            this.label13.Text = "5G안내:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(633, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 19);
            this.label12.TabIndex = 18;
            this.label12.Text = "이름:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(641, 229);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 19);
            this.label11.TabIndex = 17;
            this.label11.Text = "서명:";
            // 
            // csignPad
            // 
            this.csignPad.BackColor = System.Drawing.Color.White;
            this.csignPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.csignPad.Location = new System.Drawing.Point(711, 284);
            this.csignPad.Name = "csignPad";
            this.csignPad.Size = new System.Drawing.Size(310, 83);
            this.csignPad.TabIndex = 16;
            this.csignPad.Paint += new System.Windows.Forms.PaintEventHandler(this.csignPad_Paint);
            this.csignPad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.csignPad_MouseDown);
            this.csignPad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.csignPad_MouseMove);
            this.csignPad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.csignPad_MouseUp);
            // 
            // nsignPad
            // 
            this.nsignPad.BackColor = System.Drawing.Color.White;
            this.nsignPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nsignPad.Location = new System.Drawing.Point(708, 93);
            this.nsignPad.Name = "nsignPad";
            this.nsignPad.Size = new System.Drawing.Size(310, 83);
            this.nsignPad.TabIndex = 15;
            this.nsignPad.Paint += new System.Windows.Forms.PaintEventHandler(this.nsignPad_Paint);
            this.nsignPad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nsignPad_MouseDown);
            this.nsignPad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.nsignPad_MouseMove);
            this.nsignPad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.nsignPad_MouseUp);
            // 
            // ssignPad
            // 
            this.ssignPad.BackColor = System.Drawing.Color.White;
            this.ssignPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ssignPad.Location = new System.Drawing.Point(708, 188);
            this.ssignPad.Name = "ssignPad";
            this.ssignPad.Size = new System.Drawing.Size(310, 83);
            this.ssignPad.TabIndex = 14;
            this.ssignPad.Paint += new System.Windows.Forms.PaintEventHandler(this.ssignPad_Paint);
            this.ssignPad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ssignPad_MouseDown);
            this.ssignPad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ssignPad_MouseMove);
            this.ssignPad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.signPad_MouseUp);
            // 
            // result_result_5G
            // 
            this.result_result_5G.BackColor = System.Drawing.SystemColors.Info;
            this.result_result_5G.Location = new System.Drawing.Point(148, 297);
            this.result_result_5G.Multiline = true;
            this.result_result_5G.Name = "result_result_5G";
            this.result_result_5G.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.result_result_5G.Size = new System.Drawing.Size(420, 128);
            this.result_result_5G.TabIndex = 13;
            this.result_result_5G.Text = resources.GetString("result_result_5G.Text");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(60, 369);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "리턴결과(5G):";
            // 
            // result_result
            // 
            this.result_result.BackColor = System.Drawing.SystemColors.Info;
            this.result_result.Location = new System.Drawing.Point(148, 141);
            this.result_result.Multiline = true;
            this.result_result.Name = "result_result";
            this.result_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.result_result.Size = new System.Drawing.Size(420, 150);
            this.result_result.TabIndex = 11;
            this.result_result.Text = "{\r\n \"sign\":\"false\",\r\n    \"result\"[\r\n        {\"signPadId\":\"nsignSignPad\",\"base64Im" +
    "g\":\"\"},\r\n         {\"signPadId\":\"ssignSignPad\",\"base64Img\":\"\"   ]\r\n}\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "리턴결과(S):";
            // 
            // result_param
            // 
            this.result_param.BackColor = System.Drawing.SystemColors.Info;
            this.result_param.Location = new System.Drawing.Point(148, 15);
            this.result_param.Multiline = true;
            this.result_param.Name = "result_param";
            this.result_param.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.result_param.Size = new System.Drawing.Size(420, 97);
            this.result_param.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "요청파라미터:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtContenType);
            this.tabPage2.Controls.Add(this.txtTargetURL);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.txtJsonData);
            this.tabPage2.Controls.Add(this.cancel_result);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cancel_param);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1058, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "서명취소";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtTargetURL
            // 
            this.txtTargetURL.Location = new System.Drawing.Point(136, 276);
            this.txtTargetURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTargetURL.Name = "txtTargetURL";
            this.txtTargetURL.Size = new System.Drawing.Size(644, 21);
            this.txtTargetURL.TabIndex = 10;
            this.txtTargetURL.Text = "https://e-form.sktelecom.com:8010/API/GetViewerDataByOpInput.ajax";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(804, 330);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "ＡＰＩ호출";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtJsonData
            // 
            this.txtJsonData.BackColor = System.Drawing.SystemColors.Info;
            this.txtJsonData.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtJsonData.Location = new System.Drawing.Point(136, 302);
            this.txtJsonData.Multiline = true;
            this.txtJsonData.Name = "txtJsonData";
            this.txtJsonData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJsonData.Size = new System.Drawing.Size(644, 132);
            this.txtJsonData.TabIndex = 8;
            this.txtJsonData.Text = resources.GetString("txtJsonData.Text");
            // 
            // cancel_result
            // 
            this.cancel_result.BackColor = System.Drawing.SystemColors.Info;
            this.cancel_result.Location = new System.Drawing.Point(136, 79);
            this.cancel_result.Multiline = true;
            this.cancel_result.Name = "cancel_result";
            this.cancel_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cancel_result.Size = new System.Drawing.Size(628, 104);
            this.cancel_result.TabIndex = 7;
            this.cancel_result.Text = "{\r\n \"resultCode\":\"success\",\r\n  \"resultMsg\":\"cancel ok\"\r\n}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "리턴결과:";
            // 
            // cancel_param
            // 
            this.cancel_param.BackColor = System.Drawing.SystemColors.Info;
            this.cancel_param.Location = new System.Drawing.Point(136, 17);
            this.cancel_param.Multiline = true;
            this.cancel_param.Name = "cancel_param";
            this.cancel_param.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cancel_param.Size = new System.Drawing.Size(628, 56);
            this.cancel_param.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "요청파라미터:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // serverStartBtn
            // 
            this.serverStartBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.serverStartBtn.Location = new System.Drawing.Point(12, 25);
            this.serverStartBtn.Name = "serverStartBtn";
            this.serverStartBtn.Size = new System.Drawing.Size(126, 18);
            this.serverStartBtn.TabIndex = 1;
            this.serverStartBtn.Text = "서버시작";
            this.serverStartBtn.UseVisualStyleBackColor = false;
            this.serverStartBtn.Click += new System.EventHandler(this.serverStartBtn_Click);
            // 
            // serverStopBtn
            // 
            this.serverStopBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.serverStopBtn.Location = new System.Drawing.Point(144, 25);
            this.serverStopBtn.Name = "serverStopBtn";
            this.serverStopBtn.Size = new System.Drawing.Size(126, 18);
            this.serverStopBtn.TabIndex = 2;
            this.serverStopBtn.Text = "서버중지";
            this.serverStopBtn.UseVisualStyleBackColor = false;
            this.serverStopBtn.Click += new System.EventHandler(this.serverStopBtn_Click);
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.Location = new System.Drawing.Point(295, 28);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(0, 12);
            this.serverStatusLabel.TabIndex = 3;
            // 
            // httpPort
            // 
            this.httpPort.Location = new System.Drawing.Point(521, 25);
            this.httpPort.Name = "httpPort";
            this.httpPort.Size = new System.Drawing.Size(54, 21);
            this.httpPort.TabIndex = 4;
            this.httpPort.Text = "18082";
            this.httpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(446, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "http포트==>";
            // 
            // statusTxt
            // 
            this.statusTxt.Location = new System.Drawing.Point(12, 567);
            this.statusTxt.Name = "statusTxt";
            this.statusTxt.Size = new System.Drawing.Size(1090, 21);
            this.statusTxt.TabIndex = 6;
            // 
            // txtContenType
            // 
            this.txtContenType.Location = new System.Drawing.Point(136, 251);
            this.txtContenType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContenType.Name = "txtContenType";
            this.txtContenType.Size = new System.Drawing.Size(644, 21);
            this.txtContenType.TabIndex = 11;
            this.txtContenType.Text = "application/x-www-form-urlencoded";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 589);
            this.Controls.Add(this.statusTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.httpPort);
            this.Controls.Add(this.serverStatusLabel);
            this.Controls.Add(this.serverStopBtn);
            this.Controls.Add(this.serverStartBtn);
            this.Controls.Add(this.panel1);
            this.Name = "formMain";
            this.Text = "ㄱ";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.apiTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button serverStartBtn;
        private System.Windows.Forms.Button serverStopBtn;
        private System.Windows.Forms.Label serverStatusLabel;
        public System.Windows.Forms.TextBox req_param;
        public System.Windows.Forms.TextBox req_result;
        public System.Windows.Forms.TabControl apiTabs;
        public System.Windows.Forms.TextBox cancel_result;
        public System.Windows.Forms.TextBox cancel_param;
        public System.Windows.Forms.TextBox result_result;
        public System.Windows.Forms.TextBox result_param;
        public System.Windows.Forms.TextBox httpPort;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox result_result_5G;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel ssignPad;
        private System.Windows.Forms.Panel csignPad;
        private System.Windows.Forms.Panel nsignPad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnnsignOk;
        private System.Windows.Forms.Button btnn5GsignOk;
        public System.Windows.Forms.Label statusBar;
        public System.Windows.Forms.TextBox statusTxt;
        public System.Windows.Forms.TextBox txtJsonData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTargetURL;
        private System.Windows.Forms.TextBox txtContenType;
    }
}

