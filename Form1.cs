using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace APP_MINF_Ver_GL
{
    public partial class ControlGen_V1 : Form
    {
        String[] tabFormes = { "Sinus", "Carre", "Triangle", "DentScie" };
        protected String[] tabUserValues = new String[4];
        protected String messageTx = "!S=TF=2000A=10000O=+5000W=0#";

        public ControlGen_V1()
        {
            InitializeComponent();
            String[] tabPortCom = SerialPort.GetPortNames();
            cboxPortCOM.Items.AddRange(tabPortCom);
            cboxPortCOM.SelectedIndex = 0;
            gpBoxRX.Enabled = false;
            gpBoxTX.Enabled = false;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen == false)
            {
                // Configuration du port
                serialPort1.PortName = (string)cboxPortCOM.SelectedItem;
                serialPort1.BaudRate = 57600;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.RequestToSend;

                // Set the read/write timeouts
                serialPort1.ReadTimeout = 100;
                serialPort1.WriteTimeout = 100;

                try
                {
                    serialPort1.Open();

                    btnOpenPort.Text = "Close port";
                    gpBoxRX.Enabled = true;
                    gpBoxTX.Enabled = true;
                    cboxPortCOM.Enabled = false;
                    cboxForme.Enabled = true;
                    cboxForme.Items.AddRange(tabFormes);
                    cboxForme.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    if (!serialPort1.IsOpen)
                        MessageBox.Show(ex.ToString(), "Erreur à l'ouverture du port !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                serialPort1.Close();

                btnOpenPort.Text = "Open Port";
                gpBoxRX.Enabled = false;
                gpBoxTX.Enabled = false;
                cboxPortCOM.Enabled = true;
            }
        }

        private void btnSend_1fois_Click(object sender, EventArgs e)
        {
            composeMSG();
        }

        private void composeMSG()
        {
            int indexSignal = messageTx.IndexOf("S");
            int indexFreq = messageTx.IndexOf("F");
            int indexAmpl = messageTx.IndexOf("A");
            int indexOffSet = messageTx.IndexOf("O");
            String tempString;

            tabUserValues[0] = numAmplitude.Value.ToString();
            tabUserValues[1] = numFrequence.Value.ToString();
            tabUserValues[2] = numOffset.Value.ToString();

            tempString = messageTx.Substring((indexSignal + 2), 1);

            messageTx.Replace("2000", tabUserValues[1]);
            listBoxTX.Items.Add(messageTx);
        }

        private String ConvFormeToMSG()
        {
            String[] msgs = new String[listBoxTX.Items.Count];
        }
    }
}
