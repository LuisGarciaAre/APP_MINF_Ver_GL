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
        // Declaration des variables de classe
        public delegate void ReceiverD();
        public ReceiverD myDelegate;

        String[] tabFormes = { "Sinus", "Carre", "Triangle", "DentScie" };
        String[] tabPortCom = SerialPort.GetPortNames();    // Lecture et sauvegarde des port connectés

        // Fonction a realiser lors d'init de APP
        public ControlGen_V1()
        {
            InitializeComponent();
            cboxPortCOM.Items.AddRange(tabPortCom);
            cboxPortCOM.SelectedIndex = 0;
            gpBoxRX.Enabled = false;
            gpBoxTX.Enabled = false;
            myDelegate = new ReceiverD(DispInListRxData);
        }

        // Fonction composition de message
        private String composeMSG()
        {
            // Declaration de variables locales
            StringBuilder messageTx = new StringBuilder("!S=");

            // Lecture des parametres et conversion en String + ajout a chaine de caracteres
            messageTx.Append(ConvFormeToMSG(cboxForme.SelectedIndex));
            messageTx.Append("F=");
            messageTx.Append(numFrequence.Value.ToString());
            messageTx.Append("A=");
            messageTx.Append(numAmplitude.Value.ToString());
            messageTx.Append("O=");
            messageTx.Append(numOffset.Value.ToString());
            messageTx.Append("W=");

            // Si caisse sauvegarde cochée ajout 1# à la chaine 
            if (chBoxSuavegarde.Checked == true)
            {
                messageTx.Append("1#");
            }
            else
            {
                messageTx.Append("0#");
            }

            // retour de chaine en String
            return messageTx.ToString();
        }

        // Fonction qui retourne le caractere en fonction d'index recu en parametre
        /* 0 = S (en String)
         * 1 = C (en String)
         * 2 = T (en String)
         * 3 = D (en String)
         */
        private String ConvFormeToMSG(int valInt)
        {
            // Declaration des variables locales
            String formeSelect = "E";

            // Si valeur d'index recu en param autre que S,C,T,D forme = E(error)
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

        /* Fonction qui converti la lettre extrait de la chaine du message recu en forme
         * S = Sinus
         * C = Carre
         * T = Triangle
         * D = Dent de Scie
         */
        private String ConvertStringToForme(String indiceForme)
        {
            String forme = "Error";

            switch (indiceForme)
            {
                case "S":
                    {
                        forme = "Sinus";
                        break;
                    }
                case "C":
                    {
                        forme = "Carre";
                        break;
                    }
                case "T":
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

        /**
         * Fonction qui décode un message reçu en extrayant et affichant les informations de signal.
         * Les informations extraites sont :
         * - La forme du signal (S)
         * - La fréquence (F)
         * - L'amplitude (A)
         * - L'offset (O)
         *
         * @param messageRecu Le message reçu à décoder.
         */
        private void DecodeMessageRX(String messageRecu)
        {
            String[] tabValuesDecode = new String[4];

            int indexSignal, indexFreq, indexAmpl, indexOffSet, indexW;
            String tempString;

            if (listBox_RX.Items.Count > 50)
            {
                listBox_RX.Items.Clear();
                listBox_RX.Items.Add(messageRecu);
            }
            else
            {
                listBox_RX.Items.Add(messageRecu);
            }

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

        /**
         * Fonction qui envoie un message via le port série ouvert.
         * Le message est composé et envoyé en utilisant l'encodage ASCII.
         * Si le port série est fermé ou une erreur se produit lors de l'envoi,
         * une alerte est affichée et le port série est nettoyé.
         */
        private void SendMessageTX()
        {
            String messageTX;

            if (serialPort1.IsOpen == true)
            {
                messageTX = composeMSG();

                try
                {
                    byte[] dataToSend = Encoding.ASCII.GetBytes(messageTX);
                    serialPort1.Write(dataToSend, 0, dataToSend.Length);

                    if (listBoxTX.Items.Count > 50)
                    {
                        listBoxTX.Items.Clear();
                        listBoxTX.Items.Add(messageTX);
                    }
                    else
                    {
                        listBoxTX.Items.Add(messageTX);
                    }

                }
                catch
                {
                    MessageBox.Show("Erreur à l'envoi, impossible à envoyer, port deconnecte?");
                    timer1.Stop();
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                }
            }
            else
            {
                timer1.Stop();     // pour éviter problème en mode continu
                MessageBox.Show("Impossible d'envoyer des données, port fermé");
                CloseCom();
            }
        }

        /**
         * Fonction qui gère l'événement de clic sur le bouton d'ouverture/fermeture du port série.
         * Si le port est fermé, il le configure et l'ouvre. Si le port est ouvert, il le ferme.
         *
         */
        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
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
                    if(cboxForme.Items.Count > 0)
                    {
                        cboxForme.Items.Clear();
                    }
                    cboxForme.Enabled = true;
                    cboxForme.Items.AddRange(tabFormes);
                    cboxForme.SelectedIndex = 0;
                }
                catch
                {
                    if (!serialPort1.IsOpen)
                    {
                        MessageBox.Show("Erreur port non trouvé");
                        CloseCom();
                    }

                }
            }
            else
            {
                try
                {
                    timer1.Stop();
                    serialPort1.Close();

                    btnOpenPort.Text = "Open Port";
                    gpBoxRX.Enabled = false;
                    gpBoxTX.Enabled = false;
                    cboxPortCOM.Enabled = true;
                    cboxForme.SelectedIndex = 0;
                    cboxPortCOM.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    timer1.Stop();
                    cboxForme.SelectedIndex = 0;
                    MessageBox.Show(ex.ToString(), "Erreur à la fermeture du port, relancer l'APP !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseCom();
                    cboxForme.SelectedIndex = 0;
                    cboxPortCOM.SelectedIndex = 0;
                }

            }
        }

        /**
         * Fonction qui gère l'événement de clic sur le bouton pour envoyer un message une fois.
         * Arrête l'envoi continu s'il est en cours, puis envoie un message via le port série.
         *
         */
        private void btnSend_1fois_Click(object sender, EventArgs e)
        {
            // Si timer 1 actif, stop timer, change texte de bouton envoi en continu
            if (timer1.Enabled)
            {
                timer1.Stop();
                btnSendContinu.Text = "Envoi continu";
            }

            SendMessageTX();
        }


        private void btnSendContinu_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!timer1.Enabled)
                {
                    timer1.Interval = 25;
                    btnSendContinu.Text = "Arret envoi";
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                    btnSendContinu.Text = "Envoi continu";
                }
            }
            else
            {
                MessageBox.Show("Port non ouvert", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Stop();    

                CloseCom(); // Fermeture du port de communication
            }
        }

        /**
         * Fonction qui gère l'événement de clic sur le bouton pour envoyer des messages en continu.
         * Si le port série est ouvert, démarre ou arrête l'envoi continu de messages à intervalles réguliers.
         * Si le port n'est pas ouvert, affiche un message d'erreur et arrête le timer.
         *
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                // Essie d'envoyer, sinon stop timer et ferme port
                try
                {
                    SendMessageTX();
                }
                catch
                {
                    timer1.Stop();
                    CloseCom();
                }
            }
            else
            {
                // Si port non ouvert, stop timer et ferme port
                timer1.Stop();
                MessageBox.Show("Erreur port deconecté!");
                CloseCom();
            }
        }

        private void btnClearBox_Click(object sender, EventArgs e)
        {
            listBoxTX.Items.Clear();
            listBox_RX.Items.Clear();
        }

        // Fonction qui appel fonciont DispInListRxData
        private void ReceptionDatas(object sender, SerialDataReceivedEventArgs e)
        {
            listBoxTX.BeginInvoke(myDelegate);
        }

        /**
        * Fonction qui lit les données reçues via le port série et les affiche dans une liste sur App.
        * Les données sont lues sous forme de tableau de bytes, converties en caractères,
        * puis décodées pour être affichées.
        */
        public void DispInListRxData()
        {
            byte[] DatasReceived = new byte[30];

            StringBuilder messageRx = new StringBuilder("");
            String messageRecu = null;

            serialPort1.Read(DatasReceived, 0, 30);

            for (int i = 0; i < DatasReceived.Length; i++)
            {
                messageRx.Append(Convert.ToChar(DatasReceived[i]));
            }

            messageRecu = messageRx.ToString();

            DecodeMessageRX(messageRecu);
        }

        /**
         * Fonction qui ferme le port série et effectue des nettoyages nécessaires.
         * Affiche une alerte en cas d'échec de la fermeture du port.
         */
        private void CloseCom()
        {
            try
            {
                // Fermeture du port
                serialPort1.Close();
            }
            catch
            {
                MessageBox.Show("Impossible de fermer port!");
                // Nettoyage des listes de transmition récéption
                listBoxTX.Items.Clear();
                listBox_RX.Items.Clear();
                cboxPortCOM.Items.Clear();
            }

            btnOpenPort.Text = "Open Port";
            gpBoxTX.Enabled = false;
            gpBoxRX.Enabled = false;
            cboxPortCOM.Enabled = true;
            btnSendContinu.Text = "Envoi continu";

            // Nettoyage des listes de transmition récéption
            listBoxTX.Items.Clear();
            listBox_RX.Items.Clear();
            cboxPortCOM.Items.Clear();

        }

        /**
         * Fonction qui gère l'événement de déroulement du menu déroulant de sélection du port COM.
         * Vérifie et récupère la liste des ports série disponibles, puis les ajoute à la liste déroulante.
         *
         */
        private void cboxPortCOM_DropDown(object sender, EventArgs e)
        {
            // Vérification des ports
            // Get a list of serial port names.
            cboxPortCOM.Items.Clear();
            tabPortCom = SerialPort.GetPortNames();
            cboxPortCOM.Items.AddRange(tabPortCom);
            cboxPortCOM.SelectedIndex = 0;
        }

        /**
         * Fonction qui gère l'événement de fermeture de app.
         * Arrête le timer, désactive les signaux de contrôle du port série,
         * supprime l'événement de réception de données et ferme le port série s'il est ouvert.
         *
         */
        private void ControlGen_V1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();

            try
            {
                serialPort1.Handshake = Handshake.None;
                serialPort1.DtrEnable = false;
                serialPort1.RtsEnable = false;
                serialPort1.DataReceived -= ReceptionDatas;
                if (serialPort1.IsOpen)
                {
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erreur à la fermeture du port !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
