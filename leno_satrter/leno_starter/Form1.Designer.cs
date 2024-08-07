
namespace leno_starter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnScan = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.cmbCOMPort = new System.Windows.Forms.ComboBox();
            this.ssidbox = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbxRxData = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.SSID = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.passbox = new System.Windows.Forms.TextBox();
            this.oya = new System.Windows.Forms.RadioButton();
            this.inta = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(21, 9);
            this.btnScan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(80, 31);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Re-Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(315, 9);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 31);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(405, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 31);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(405, 126);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 31);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cmbCOMPort
            // 
            this.cmbCOMPort.FormattingEnabled = true;
            this.cmbCOMPort.Location = new System.Drawing.Point(108, 16);
            this.cmbCOMPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCOMPort.Name = "cmbCOMPort";
            this.cmbCOMPort.Size = new System.Drawing.Size(93, 23);
            this.cmbCOMPort.TabIndex = 1;
            this.cmbCOMPort.Text = "- Select -";
            this.cmbCOMPort.SelectedIndexChanged += new System.EventHandler(this.cmbCOMPort_SelectedIndexChanged);
            // 
            // ssidbox
            // 
            this.ssidbox.Location = new System.Drawing.Point(108, 58);
            this.ssidbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ssidbox.Name = "ssidbox";
            this.ssidbox.Size = new System.Drawing.Size(278, 22);
            this.ssidbox.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(405, 161);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 31);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbxRxData
            // 
            this.tbxRxData.Location = new System.Drawing.Point(23, 196);
            this.tbxRxData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxRxData.Multiline = true;
            this.tbxRxData.Name = "tbxRxData";
            this.tbxRxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRxData.Size = new System.Drawing.Size(447, 77);
            this.tbxRxData.TabIndex = 3;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // cmbBaud
            // 
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaud.Location = new System.Drawing.Point(213, 16);
            this.cmbBaud.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(93, 23);
            this.cmbBaud.TabIndex = 1;
            this.cmbBaud.Text = "- Select -";
            // 
            // SSID
            // 
            this.SSID.AutoSize = true;
            this.SSID.Location = new System.Drawing.Point(51, 61);
            this.SSID.Name = "SSID";
            this.SSID.Size = new System.Drawing.Size(39, 15);
            this.SSID.TabIndex = 5;
            this.SSID.Text = "SSID";
            this.SSID.Click += new System.EventHandler(this.label1_Click);
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(47, 103);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(43, 15);
            this.pass.TabIndex = 6;
            this.pass.Text = "PASS";
            // 
            // passbox
            // 
            this.passbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.passbox.Location = new System.Drawing.Point(108, 96);
            this.passbox.Name = "passbox";
            this.passbox.Size = new System.Drawing.Size(278, 22);
            this.passbox.TabIndex = 7;
            // 
            // oya
            // 
            this.oya.AutoSize = true;
            this.oya.Checked = true;
            this.oya.Location = new System.Drawing.Point(130, 139);
            this.oya.Name = "oya";
            this.oya.Size = new System.Drawing.Size(73, 19);
            this.oya.TabIndex = 8;
            this.oya.TabStop = true;
            this.oya.Text = "親探知";
            this.oya.UseVisualStyleBackColor = true;
            // 
            // inta
            // 
            this.inta.AutoSize = true;
            this.inta.Location = new System.Drawing.Point(224, 138);
            this.inta.Name = "inta";
            this.inta.Size = new System.Drawing.Size(95, 19);
            this.inta.TabIndex = 9;
            this.inta.Text = "インターホン";
            this.inta.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 281);
            this.Controls.Add(this.inta);
            this.Controls.Add(this.oya);
            this.Controls.Add(this.passbox);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.SSID);
            this.Controls.Add(this.tbxRxData);
            this.Controls.Add(this.ssidbox);
            this.Controls.Add(this.cmbBaud);
            this.Controls.Add(this.cmbCOMPort);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnScan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "leno starter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cmbCOMPort;
        private System.Windows.Forms.TextBox ssidbox;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbxRxData;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.Label SSID;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.TextBox passbox;
        private System.Windows.Forms.RadioButton oya;
        private System.Windows.Forms.RadioButton inta;
    }
}

