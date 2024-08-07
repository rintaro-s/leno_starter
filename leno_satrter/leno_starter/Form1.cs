using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;          // serialPort関連の名前空間を追加

namespace leno_starter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            scanCOMPorts();             // 接続されているCOMポート名をリスト
            cmbBaud.SelectedIndex = 3;  // 9600baud(index 3)を選ぶ
        }

        // -------------------------------------------------------------
        // COM Port List を 更新
        // PCに接続されているポート名を取得しcmbCOMPortに登録する
        // -------------------------------------------------------------
        private void scanCOMPorts()
        {
            cmbCOMPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                cmbCOMPort.Items.Add(p);
            }
        }

        // -------------------------------------------------------------
        // [Scan]クリック、COM Port List を 更新
        // -------------------------------------------------------------
        private void btnScan_Click(object sender, EventArgs e)
        {
            scanCOMPorts();
        }

        // -------------------------------------------------------------
        // [Open]クリック、COMポートを接続
        // 必要なコントロールの有効・無効も変更
        // -------------------------------------------------------------
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            // COMポートの接続を試みます。
            // COMポートの接続は、try/catchステートメントを使用することが
            // 重要です。COMポートが削除され、PCソフトウェアがその削除
            // を検出する前にCOMポートを操作すると、例外がスローされます。
            // try/catchステートメント外で例外がスローされると、
            // アプリケーションがクラッシュする可能性があります。
            {
                serialPort1.PortName = cmbCOMPort.Text; // COM名設定
                // ボーレートを設定
                serialPort1.BaudRate = int.Parse(cmbBaud.Text);
                serialPort1.Open();                     // ポート接続
                btnOpen.Enabled = false;                // 接続　Off
                btnClose.Enabled = true;                // 切断　On
                btnScan.Enabled = false;                // 更新　Off
                cmbCOMPort.Enabled = false;             // COMリスト　Off
                cmbBaud.Enabled = false;                // Baudリスト　Off
                btnSend.Enabled = true;                 // 送信　On
                tbxRxData.Clear();                      // 画面クリア
                tbxRxData.AppendText("Connected\r\n");  // 接続と表示
            }
            catch
            {
                // 例外が発生した場合は、[Close}ボタンを押して、
                // COMポートを切断します
                btnClose_Click(this, null);             // 切断ボタンを押す
            }
        }

        // -------------------------------------------------------------
        // [Close]クリック、COMポートを切断します
        // さらに、必要なコントロールの有効・無効を変更します
        // -------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;             // 接続　On
            btnClose.Enabled = false;           // 切断　Off
            btnScan.Enabled = true;             // 更新　On
            cmbCOMPort.Enabled = true;          // COMリスト　On
            cmbBaud.Enabled = true;             // Baudリスト　On
            btnSend.Enabled = false;            // 送信　Off
            try
            {
                serialPort1.DiscardInBuffer();  // 入力バッファを破棄
                serialPort1.DiscardOutBuffer(); // 出力バッファを破棄
                serialPort1.Close();             // COMポートを閉じる
            }
            // 例外が発生した場合、既にポートは使用でないため
            // 処置できることはなにもありません
            catch { };
        }

        // -------------------------------------------------------------
        // この関数は、[btnSend]がクリックされたときに呼び出されます。
        // tbxTxDataの内容をCOMポート経由で送信します。失敗した場合、
        // btnClose_Click（）を呼び出してCOMポートを切断します。
        // -------------------------------------------------------------
        private void btnSend_Click(object sender, EventArgs e)
        {
            // COMポートへの書き込みを試みます。
            // COMポートに書き込むときは、try/catchステートメントを使用します。
            // USB仮想COMポートが削除され、PCソフトウェアがその削除を検出する
            // 前にCOMポートに書き込もうとすると、例外がスローされます。
            // 例外がtry/catchステートメント外で発生すると、アプリケーションが
            // クラッシュする可能性があります。
            try
            {
                // tbxTxDataのデータを開いているシリアルポートに書き込みます
                string config = "config";
                serialPort1.Write(config);
                Thread.Sleep(500);
                serialPort1.Write(ssidbox.Text);
                Thread.Sleep(500);
                serialPort1.Write(passbox.Text);
                Thread.Sleep(500);
                if (oya.Checked) serialPort1.Write("oya");
                if (inta.Checked) serialPort1.Write("inta");
            }
            catch
            {
                // 例外が発生した場合は、[Close}ボタンを押して、
                // COMポートを切断します
                btnClose_Click(this, null);
            }
        }

        // -------------------------------------------------------------
        // 受信データ画面をクリアします
        // -------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxRxData.Clear();
        }

        // -------------------------------------------------------------
        // 文字列を、tbxRxDataテキストボックスに書き込むため
        // tbxRxDataのあるUIスレッドへのデリゲート関数を作成します。
        // -------------------------------------------------------------
        delegate void SetTextCallback(string text);

        // -------------------------------------------------------------
        // この関数は、COMポートでデータを受信したときに呼び出されます。
        // この関数は、そのデータをtbxRxDataテキストボックスに書き込むために
        // SetText にデータを送ります。例外が発生すると、btnClose_Click関数が
        // 呼び出され例外の原因となったCOMポートを閉じます。
        // -------------------------------------------------------------
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                // ReadExisting関数は、COMポートバッファで現在利用可能なすべての
                // データを読み取ります。この例では、使用可能なすべてのCOMポート
                // データを SetText関数に送信しています。
                //
                // 注意：この SerialPort1 _DataReceived関数は、アプリケーションの
                // 主要部分であるUIスレッドとは異なる別のスレッドで起動されます。
                // UIスレッド内の管理対象オブジェクトである tbxRxDataに受信データ
                // を書き込むには、デリゲート関数が必要です。デリゲート関数と
                // その使用方法詳細は、SetText（）関数を参照してください。

                SetText(serialPort1.ReadExisting());
            }
            catch
            {
                // 例外の場合は、[Close}ボタンを押して、COMポートを切断します
                btnClose_Click(this, null);
            }
        }

        // -------------------------------------------------------------
        // この関数は、入力テキストをtbxRxDataテキストボックスに出力します。
        // tbxRxData を所有する UIスレッドとは異なるスレッドからこの関数が
        // 呼び出された場合は、デリゲートインスタンスが作成され、 
        // すぐに、今度は、UIスレッドからの呼び出しで関数が再度実行されます。
        // 呼び出し元のスレッドがUIスレッドと同じなら、単にAppendText で
        // テキストをtbxRxDataに書き込みます。
        // -------------------------------------------------------------
        private void SetText(string text)
        {
            // InvokeRequired は、呼び出し元のスレッドのスレッドIDを
            // 作業中のスレッドのスレッドIDと比較し、これらが異なる場合、
            // TRUE を返します。この属性を使用して、テキストをtbxRxData
            // に直接追加できるか、あるいは、デリゲート関数を起動して
            // 書き込む必要があるかを判断できます。

            if (tbxRxData.InvokeRequired)
            {
                // InvokeRequiredが TRUE を返しました。これは、現在の
                // スレッドと異なるスレッドから呼び出されたことを
                // 意味します。デリゲート機能を起動する必要があります。
                // SetTextCallbackデリゲートのインスタンスを作成し、
                // デリゲート関数をこの関数に割り当てます。これにより、
                // この同じSetText関数がデータ受信スレッドからではなく
                // UIスレッド内で呼び出されるようになります。

                SetTextCallback d = new SetTextCallback(SetText);

                // 他のスレッドからこの関数に渡されたデリゲートに同じ
                // テキストを送信する新しいデリゲートを呼び出します。

                Invoke(d, new object[] { text });
            }
            else
            {
                // この関数が tbxRxDataを保持する同じスレッドから
                // 呼び出されたので、単にテキストを追加するだけです。

                tbxRxData.AppendText(text);
            }
        }

        private void cmbCOMPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rbLF_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
