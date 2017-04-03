using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bat_Hour
{
    public partial class Initial : Form
    {

        public PerformanceCounter myCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
        Timer Timer99 = new Timer();
        Timer timerPort = new Timer();
        public Int32 j = 0;
        public Int32 Setpoint = 0;
        public bool Enabled = false;
        public string RxString = "";
        public string lastCommand = "";

        public Initial()
        {
            InitializeComponent();

            Timer99.Tick += Timer99_Tick; // don't freeze the ui
            Timer99.Interval = 1024;
            
            timerPort.Tick += TimerPortOnTick;
            timerPort.Interval = 500;
            timerPort.Enabled = true;
        }

        private void TimerPortOnTick(object sender, EventArgs eventArgs)
        {
            atualizaListaCOMs();
        }

        private void Timer99_Tick(object sender, EventArgs eventArgs)
        {
            j = Convert.ToInt32(myCounter.NextValue());
            tbxDiskUsage.Text = $"Usage: {j} %";
            if (Enabled && j >= Setpoint)
            {
                if (lastCommand != "ON")
                {
                    serialPort.Write("ON");
                    lastCommand = "ON";
                }
                listBox.Items.Add($"{DateTime.Now:hh:mm:ss} - Usage {j} %");
            }
            else
            {
                if (lastCommand != "OFF")
                {
                    serialPort.Write("OFF");
                    lastCommand = "OFF";
                }
            }

        }

        private void EnableTimer()
        {
            Enabled = true;
            Timer99.Enabled = true;
            //tbxSetpoint.Text = "Enabled";
            btnOnOff.Text = "Turn Off";
        }

        private void DisableTimer()
        {
            Enabled = false;
            Timer99.Enabled = false;
            //tbxSetpoint.Text = "Disabled";
            btnOnOff.Text = "Turn On";
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            #region [Validação]
            int setPoint = 0;
            if (!int.TryParse(Regex.Match(tbxSetpoint.Text, @"\d+").Value, out setPoint))
            {
                MessageBox.Show(this, "Informe o valor do Setpoint.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (!(setPoint >= 0 && setPoint <= 100))
            {
                MessageBox.Show(this, "Valor do Setpoint deve ser entre 1 e 100", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (!serialPort.IsOpen)
            {
                MessageBox.Show(this, "Não foi possível detectar o arduino conectado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            #endregion

            if (Enabled)
            {
                DisableTimer();
            }
            else
            {
                EnableTimer();
            }
        }

        private void tbxSetpoint_TextChanged(object sender, EventArgs e)
        {
            string defaultText = "Setpoint: ";
            int setPoint = 0;
            if (!int.TryParse(Regex.Match(tbxSetpoint.Text, @"\d+").Value, out setPoint) || !(setPoint >= 0))
            {
                tbxSetpoint.Text = defaultText;
                SetpointCursorEndPosition();
                btnOnOff.Enabled = false;
                return;
            }

            Setpoint = setPoint;
            tbxSetpoint.Text = $"{defaultText}{setPoint}";
            SetpointCursorEndPosition();
            btnOnOff.Enabled = true;
        }

        private void SetpointCursorEndPosition()
        {
            tbxSetpoint.SelectionStart = tbxSetpoint.Text.Length;
            tbxSetpoint.SelectionLength = 0;
        }

        private void atualizaListaCOMs()
        {
            int i;
            bool quantDiferente;    //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

            //se a quantidade de portas mudou
            if (cbxPort.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (cbxPort.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            //Se não foi detectado diferença
            if (quantDiferente == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            cbxPort.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                cbxPort.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            cbxPort.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == false)
            {
                try
                {
                    serialPort.PortName = cbxPort.Items[cbxPort.SelectedIndex].ToString();
                    serialPort.Open();

                }
                catch
                {
                    return;

                }
                if (serialPort.IsOpen)
                {
                    btnConnect.Text = "Desconectar";
                    cbxPort.Enabled = false;

                }
            }
            else
            {

                try
                {
                    serialPort.Close();
                    cbxPort.Enabled = true;
                    btnConnect.Text = "Conectar";
                }
                catch
                {
                    return;
                }

            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //RxString = serialPort.ReadLine();             //le o dado disponível na serial
            //this.Invoke(new EventHandler(trataDadoRecebido));   //chama outra thread para escrever o dado no text box
        }

        //private void trataDadoRecebido(object sender, EventArgs e)
        //{
        //    Boolean ligado = 
        //    Double tensao = Convert.ToDouble(RxString) * 5 / 1023;
        //    lbValor.Text = "Tensão: " + Convert.ToString(Math.Round(tensao, 1)) + " V";
        //}
    }
}
