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
        public delegate void ReceiverD();
        public ReceiverD myDelegate;

        String[] tabFormes = { "Sinus", "Carre", "Triangle", "DentScie" };
        private bool dataIsSending = false;

        public ControlGen_V1()
        {
            InitializeComponent();
            String[] tabPortCom = SerialPort.GetPortNames();
            cboxPortCOM.Items.AddRange(tabPortCom);
            cboxPortCOM.SelectedIndex = 0;
            gpBoxRX.Enabled = false;
            gpBoxTX.Enabled = false;
        }

        private String composeMSG()
        {
            //String messageTx = "!S=TF=20A=10000O=+5000W=0#";
            StringBuilder messageTx = new StringBuilder("!S=");

            messageTx.Append(ConvFormeToMSG(cboxForme.SelectedIndex));
            messageTx.Append("F=");
            messageTx.Append(numFrequence.Value.ToString());
            messageTx.Append("A=");
            messageTx.Append(numAmplitude.Value.ToString());
            messageTx.Append("O=");
            messageTx.Append(numOffset.Value.ToString());
            messageTx.Append("W=");

            if(chBoxSuavegarde.Checked == true)
            {
                messageTx.Append("1");
            }
            else
            {
                messageTx.Append("0");
            }

            return messageTx.ToString();
        }

        private String ConvFormeToMSG(int valInt)
        {
            String formeSelect = "E";

            switch (valInt)
            {
                case 0:
                    {
                        formeSelect = "S";
                        break;
                    }
                case 1:
                    {
                        formeSelect = "C";
                        break;
                    }
                case 2:
                    {
                        formeSelect = "T";
                        break;
                    }
                case 3:
                    {
                        formeSelect = "D";
                        break;
                    }
            }

            return formeSelect;
        }

        private String ConvertStringToForme( String indiceForme)
        {
            String forme = "Error";

            switch (indiceForme)
            {
                case "T":
                    {
                        forme = "Sinus";
                        break;
                    }
                case "C":
                    {
                        forme = "Carre";
                        break;
                    }
                case "S":
                    {
                        forme = "Triangle";
                        break;
                    }
                case "D":
                    {
                        forme = "Dent de Scie";
                        break;
                    }
            }
            return forme;
        }

        private void DecodeMessageRX(String messageRecu)
        {
            String[] tabValuesDecode = new String[4];

            int indexSignal, indexFreq, indexAmpl, indexOffSet, indexW;
            String tempString;

            indexSignal = messageRecu.IndexOf("S");
            indexFreq = messageRecu.IndexOf("F");
            indexAmpl = messageRecu.IndexOf("A");
            indexOffSet = messageRecu.IndexOf("O");
            indexW = messageRecu.IndexOf("W");

            tempString = messageRecu.Substring((indexSignal + 2), 1);
            tabValuesDecode[0] = tempString;
            tabValuesDecode[0] = ConvertStringToForme(tabValuesDecode[0]);
            txtBoxForme.Text = tabValuesDecode[0];

            tempString = messageRecu.Substring(indexFreq + 2, indexAmpl - (indexFreq + 2));
            tabValuesDecode[1] = tempString;
            txtBoxFrequence.Text = tabValuesDecode[1];

            tempString = messageRecu.Substring(indexAmpl + 2, indexOffSet - (indexAmpl + 2));
            tabValuesDecode[2] = tempString;
            txtBoxAmplitude.Text = tabValuesDecode[2];

            tempString = messageRecu.Substring(indexOffSet + 2, indexW - (indexOffSet + 2));
            tabValuesDecode[3] = tempString;
            txtBoxOffset.Text = tabValuesDecode[3];
        }

        private bool SendMessageTX()
        {
            bool MsgSended = false;
            String messageTX;

            if(serialPort1.IsOpen == true)
            {
                messageTX = composeMSG();

                try
                {
                    byte[] dataToSend = Encoding.ASCII.GetBytes(messageTX);
                    //serialPort1.Write(dataToSend, 0, dataToSend.Length);
                    //System.Diagnostics.Trace.WriteLine("Message sended: " + dataToSend);

                    if (listBoxTX.Items.Count > 5)
                    {
                        listBoxTX.Items.Clear();
                        listBoxTX.Items.Add(messageTX);
                    }
                    else
                    {
                        listBoxTX.Items.Add(messageTX);
                    }

                    MsgSended = true;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString(), "Erreur a l'envoi ! :", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Stop();
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                    MsgSended = false;
                }
            }
            else
            {
                MessageBox.Show("Port non ouvert", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Stop();     // pour éviter problème en mode continu
                MsgSended = false;
            }

            return MsgSended;
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
            //stoppe envoi continu
            if (timer1.Enabled)
            {
                timer1.Stop();
                btnSendContinu.Text = "Envoi continu";
            }

            SendMessageTX();
        }

        private void btnSendContinu_Click(object sender, EventArgs e)
        {
            String messageTxContinu;
            messageTxContinu = composeMSG();
            Button btnContinu = sender as Button;

            if (dataIsSending == false)
            {
                dataIsSending = true;
                cboxForme.Enabled = false;
                numAmplitude.Enabled = false;
                numFrequence.Enabled = false;
                numOffset.Enabled = false;
                btnContinu.Text = "Arret envoi";
                timer1.Start();
            }
            else if (dataIsSending == true)
            {
                dataIsSending = false;
                cboxForme.Enabled = true;
                numAmplitude.Enabled = true;
                numFrequence.Enabled = true;
                numOffset.Enabled = true;
                btnContinu.Text = "Envoi continu";
                timer1.Stop();  
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String messageTX; 

            if(serialPort1.IsOpen == true)
            {
                try
                {
                    messageTX = composeMSG();
                    listBoxTX.Items.Add(messageTX);
                }
                catch (Exception ex)
                {
                    if (!serialPort1.IsOpen)
                        MessageBox.Show(ex.ToString(), "Erreur à l'ouverture du port !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!serialPort1.IsOpen)
                    MessageBox.Show("Erreur à l'ouverture du port !");
            }
        }

        private void btnClearBox_Click(object sender, EventArgs e)
        {
            listBoxTX.Items.Clear();
        }

        private void ReceptionDatas(object sender, SerialDataReceivedEventArgs e)
        {
            listBoxTX.BeginInvoke(myDelegate);

            char[] tabMessageRecu = new char[32];

            tabMessageRecu[0] = (char)serialPort1.ReadChar();
        }
    }


}
