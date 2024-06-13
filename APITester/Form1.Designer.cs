namespace APITester
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtContenType = new System.Windows.Forms.TextBox();
            this.txtTargetURL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtJsonData = new System.Windows.Forms.TextBox();
            this.cancel_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtContenType
            // 
            this.txtContenType.Location = new System.Drawing.Point(12, 27);
            this.txtContenType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContenType.Name = "txtContenType";
            this.txtContenType.Size = new System.Drawing.Size(644, 21);
            this.txtContenType.TabIndex = 15;
            this.txtContenType.Text = "application/x-www-form-urlencoded";
            // 
            // txtTargetURL
            // 
            this.txtTargetURL.Location = new System.Drawing.Point(12, 62);
            this.txtTargetURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTargetURL.Name = "txtTargetURL";
            this.txtTargetURL.Size = new System.Drawing.Size(644, 21);
            this.txtTargetURL.TabIndex = 14;
            this.txtTargetURL.Text = "https://e-form.sktelecom.com:8010/API/GetViewerDataByOpInput.ajax";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(674, 126);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "ＡＰＩ호출";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtJsonData
            // 
            this.txtJsonData.BackColor = System.Drawing.SystemColors.Info;
            this.txtJsonData.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtJsonData.Location = new System.Drawing.Point(12, 88);
            this.txtJsonData.Multiline = true;
            this.txtJsonData.Name = "txtJsonData";
            this.txtJsonData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJsonData.Size = new System.Drawing.Size(644, 132);
            this.txtJsonData.TabIndex = 12;
            this.txtJsonData.Text = resources.GetString("txtJsonData.Text");
            // 
            // cancel_result
            // 
            this.cancel_result.BackColor = System.Drawing.SystemColors.Info;
            this.cancel_result.Location = new System.Drawing.Point(12, 226);
            this.cancel_result.Multiline = true;
            this.cancel_result.Name = "cancel_result";
            this.cancel_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cancel_result.Size = new System.Drawing.Size(644, 159);
            this.cancel_result.TabIndex = 16;
            this.cancel_result.Text = "{\r\n \"resultCode\":\"success\",\r\n  \"resultMsg\":\"cancel ok\"\r\n}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 408);
            this.Controls.Add(this.cancel_result);
            this.Controls.Add(this.txtContenType);
            this.Controls.Add(this.txtTargetURL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtJsonData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContenType;
        private System.Windows.Forms.TextBox txtTargetURL;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtJsonData;
        public System.Windows.Forms.TextBox cancel_result;
    }
}

