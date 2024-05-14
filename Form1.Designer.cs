namespace APP_MINF_Ver_GL
{
    partial class ControlGen_V1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.cboxPortCOM = new System.Windows.Forms.ComboBox();
            this.gpBoxTX = new System.Windows.Forms.GroupBox();
            this.chBoxSuavegarde = new System.Windows.Forms.CheckBox();
            this.btnSendContinu = new System.Windows.Forms.Button();
            this.btnSend_1fois = new System.Windows.Forms.Button();
            this.listBoxTX = new System.Windows.Forms.ListBox();
            this.numOffset = new System.Windows.Forms.NumericUpDown();
            this.numAmplitude = new System.Windows.Forms.NumericUpDown();
            this.numFrequence = new System.Windows.Forms.NumericUpDown();
            this.cboxForme = new System.Windows.Forms.ComboBox();
            this.lblOffset = new System.Windows.Forms.Label();
            this.lblAmplitude = new System.Windows.Forms.Label();
            this.lblFormeS = new System.Windows.Forms.Label();
            this.lblFrequence = new System.Windows.Forms.Label();
            this.gpBoxRX = new System.Windows.Forms.GroupBox();
            this.listBox_RX = new System.Windows.Forms.ListBox();
            this.txtBoxOffset = new System.Windows.Forms.TextBox();
            this.txtBoxAmplitude = new System.Windows.Forms.TextBox();
            this.txtBoxFrequence = new System.Windows.Forms.TextBox();
            this.txtBoxForme = new System.Windows.Forms.TextBox();
            this.lblOffsetRX = new System.Windows.Forms.Label();
            this.lblFrequenceRX = new System.Windows.Forms.Label();
            this.lblAmplitudeRX = new System.Windows.Forms.Label();
            this.lblFormeRX = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClearBox = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gpBoxTX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequence)).BeginInit();
            this.gpBoxRX.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenPort);
            this.groupBox1.Controls.Add(this.cboxPortCOM);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reglage port COM";
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPort.Location = new System.Drawing.Point(160, 31);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(102, 23);
            this.btnOpenPort.TabIndex = 1;
            this.btnOpenPort.Text = "Open port";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // cboxPortCOM
            // 
            this.cboxPortCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPortCOM.FormattingEnabled = true;
            this.cboxPortCOM.Location = new System.Drawing.Point(9, 31);
            this.cboxPortCOM.Name = "cboxPortCOM";
            this.cboxPortCOM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboxPortCOM.Size = new System.Drawing.Size(121, 21);
            this.cboxPortCOM.TabIndex = 0;
            // 
            // gpBoxTX
            // 
            this.gpBoxTX.Controls.Add(this.btnClearBox);
            this.gpBoxTX.Controls.Add(this.chBoxSuavegarde);
            this.gpBoxTX.Controls.Add(this.btnSendContinu);
            this.gpBoxTX.Controls.Add(this.btnSend_1fois);
            this.gpBoxTX.Controls.Add(this.listBoxTX);
            this.gpBoxTX.Controls.Add(this.numOffset);
            this.gpBoxTX.Controls.Add(this.numAmplitude);
            this.gpBoxTX.Controls.Add(this.numFrequence);
            this.gpBoxTX.Controls.Add(this.cboxForme);
            this.gpBoxTX.Controls.Add(this.lblOffset);
            this.gpBoxTX.Controls.Add(this.lblAmplitude);
            this.gpBoxTX.Controls.Add(this.lblFormeS);
            this.gpBoxTX.Controls.Add(this.lblFrequence);
            this.gpBoxTX.Location = new System.Drawing.Point(12, 106);
            this.gpBoxTX.Name = "gpBoxTX";
            this.gpBoxTX.Size = new System.Drawing.Size(286, 338);
            this.gpBoxTX.TabIndex = 1;
            this.gpBoxTX.TabStop = false;
            this.gpBoxTX.Text = "TX";
            // 
            // chBoxSuavegarde
            // 
            this.chBoxSuavegarde.AutoSize = true;
            this.chBoxSuavegarde.Location = new System.Drawing.Point(6, 141);
            this.chBoxSuavegarde.Name = "chBoxSuavegarde";
            this.chBoxSuavegarde.Size = new System.Drawing.Size(93, 17);
            this.chBoxSuavegarde.TabIndex = 11;
            this.chBoxSuavegarde.Text = "Sauvegarde ?";
            this.chBoxSuavegarde.UseVisualStyleBackColor = true;
            // 
            // btnSendContinu
            // 
            this.btnSendContinu.Location = new System.Drawing.Point(160, 112);
            this.btnSendContinu.Name = "btnSendContinu";
            this.btnSendContinu.Size = new System.Drawing.Size(120, 23);
            this.btnSendContinu.TabIndex = 10;
            this.btnSendContinu.Text = "Envoi continu";
            this.btnSendContinu.UseVisualStyleBackColor = true;
            this.btnSendContinu.Click += new System.EventHandler(this.btnSendContinu_Click);
            // 
            // btnSend_1fois
            // 
            this.btnSend_1fois.Location = new System.Drawing.Point(6, 112);
            this.btnSend_1fois.Name = "btnSend_1fois";
            this.btnSend_1fois.Size = new System.Drawing.Size(75, 23);
            this.btnSend_1fois.TabIndex = 9;
            this.btnSend_1fois.Text = "Envoi";
            this.btnSend_1fois.UseVisualStyleBackColor = true;
            this.btnSend_1fois.Click += new System.EventHandler(this.btnSend_1fois_Click);
            // 
            // listBoxTX
            // 
            this.listBoxTX.FormattingEnabled = true;
            this.listBoxTX.Location = new System.Drawing.Point(6, 164);
            this.listBoxTX.Name = "listBoxTX";
            this.listBoxTX.Size = new System.Drawing.Size(274, 160);
            this.listBoxTX.TabIndex = 8;
            // 
            // numOffset
            // 
            this.numOffset.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numOffset.Location = new System.Drawing.Point(230, 82);
            this.numOffset.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numOffset.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numOffset.Name = "numOffset";
            this.numOffset.Size = new System.Drawing.Size(50, 20);
            this.numOffset.TabIndex = 7;
            // 
            // numAmplitude
            // 
            this.numAmplitude.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAmplitude.Location = new System.Drawing.Point(230, 32);
            this.numAmplitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAmplitude.Name = "numAmplitude";
            this.numAmplitude.Size = new System.Drawing.Size(50, 20);
            this.numAmplitude.TabIndex = 6;
            // 
            // numFrequence
            // 
            this.numFrequence.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numFrequence.Location = new System.Drawing.Point(92, 78);
            this.numFrequence.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numFrequence.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numFrequence.Name = "numFrequence";
            this.numFrequence.Size = new System.Drawing.Size(50, 20);
            this.numFrequence.TabIndex = 5;
            this.numFrequence.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cboxForme
            // 
            this.cboxForme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxForme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxForme.FormattingEnabled = true;
            this.cboxForme.Location = new System.Drawing.Point(70, 29);
            this.cboxForme.Name = "cboxForme";
            this.cboxForme.Size = new System.Drawing.Size(72, 24);
            this.cboxForme.TabIndex = 4;
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffset.Location = new System.Drawing.Point(157, 82);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(41, 16);
            this.lblOffset.TabIndex = 3;
            this.lblOffset.Text = "Offset";
            // 
            // lblAmplitude
            // 
            this.lblAmplitude.AutoSize = true;
            this.lblAmplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmplitude.Location = new System.Drawing.Point(157, 33);
            this.lblAmplitude.Name = "lblAmplitude";
            this.lblAmplitude.Size = new System.Drawing.Size(67, 16);
            this.lblAmplitude.TabIndex = 2;
            this.lblAmplitude.Text = "Amplitude";
            // 
            // lblFormeS
            // 
            this.lblFormeS.AutoSize = true;
            this.lblFormeS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormeS.Location = new System.Drawing.Point(6, 33);
            this.lblFormeS.Name = "lblFormeS";
            this.lblFormeS.Size = new System.Drawing.Size(46, 16);
            this.lblFormeS.TabIndex = 1;
            this.lblFormeS.Text = "Forme";
            // 
            // lblFrequence
            // 
            this.lblFrequence.AutoSize = true;
            this.lblFrequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrequence.Location = new System.Drawing.Point(6, 78);
            this.lblFrequence.Name = "lblFrequence";
            this.lblFrequence.Size = new System.Drawing.Size(72, 16);
            this.lblFrequence.TabIndex = 0;
            this.lblFrequence.Text = "Frequence";
            // 
            // gpBoxRX
            // 
            this.gpBoxRX.Controls.Add(this.listBox_RX);
            this.gpBoxRX.Controls.Add(this.txtBoxOffset);
            this.gpBoxRX.Controls.Add(this.txtBoxAmplitude);
            this.gpBoxRX.Controls.Add(this.txtBoxFrequence);
            this.gpBoxRX.Controls.Add(this.txtBoxForme);
            this.gpBoxRX.Controls.Add(this.lblOffsetRX);
            this.gpBoxRX.Controls.Add(this.lblFrequenceRX);
            this.gpBoxRX.Controls.Add(this.lblAmplitudeRX);
            this.gpBoxRX.Controls.Add(this.lblFormeRX);
            this.gpBoxRX.Location = new System.Drawing.Point(304, 106);
            this.gpBoxRX.Name = "gpBoxRX";
            this.gpBoxRX.Size = new System.Drawing.Size(264, 338);
            this.gpBoxRX.TabIndex = 2;
            this.gpBoxRX.TabStop = false;
            this.gpBoxRX.Text = "RX";
            // 
            // listBox_RX
            // 
            this.listBox_RX.FormattingEnabled = true;
            this.listBox_RX.Location = new System.Drawing.Point(6, 164);
            this.listBox_RX.Name = "listBox_RX";
            this.listBox_RX.Size = new System.Drawing.Size(252, 160);
            this.listBox_RX.TabIndex = 8;
            // 
            // txtBoxOffset
            // 
            this.txtBoxOffset.Location = new System.Drawing.Point(127, 117);
            this.txtBoxOffset.Name = "txtBoxOffset";
            this.txtBoxOffset.ReadOnly = true;
            this.txtBoxOffset.Size = new System.Drawing.Size(100, 20);
            this.txtBoxOffset.TabIndex = 7;
            // 
            // txtBoxAmplitude
            // 
            this.txtBoxAmplitude.Location = new System.Drawing.Point(127, 90);
            this.txtBoxAmplitude.Name = "txtBoxAmplitude";
            this.txtBoxAmplitude.ReadOnly = true;
            this.txtBoxAmplitude.Size = new System.Drawing.Size(100, 20);
            this.txtBoxAmplitude.TabIndex = 6;
            // 
            // txtBoxFrequence
            // 
            this.txtBoxFrequence.Location = new System.Drawing.Point(127, 63);
            this.txtBoxFrequence.Name = "txtBoxFrequence";
            this.txtBoxFrequence.ReadOnly = true;
            this.txtBoxFrequence.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFrequence.TabIndex = 5;
            // 
            // txtBoxForme
            // 
            this.txtBoxForme.Location = new System.Drawing.Point(127, 36);
            this.txtBoxForme.Name = "txtBoxForme";
            this.txtBoxForme.ReadOnly = true;
            this.txtBoxForme.Size = new System.Drawing.Size(100, 20);
            this.txtBoxForme.TabIndex = 4;
            // 
            // lblOffsetRX
            // 
            this.lblOffsetRX.AutoSize = true;
            this.lblOffsetRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffsetRX.Location = new System.Drawing.Point(26, 121);
            this.lblOffsetRX.Name = "lblOffsetRX";
            this.lblOffsetRX.Size = new System.Drawing.Size(41, 16);
            this.lblOffsetRX.TabIndex = 3;
            this.lblOffsetRX.Text = "Offset";
            // 
            // lblFrequenceRX
            // 
            this.lblFrequenceRX.AutoSize = true;
            this.lblFrequenceRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrequenceRX.Location = new System.Drawing.Point(26, 67);
            this.lblFrequenceRX.Name = "lblFrequenceRX";
            this.lblFrequenceRX.Size = new System.Drawing.Size(72, 16);
            this.lblFrequenceRX.TabIndex = 2;
            this.lblFrequenceRX.Text = "Frequence";
            // 
            // lblAmplitudeRX
            // 
            this.lblAmplitudeRX.AutoSize = true;
            this.lblAmplitudeRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmplitudeRX.Location = new System.Drawing.Point(26, 94);
            this.lblAmplitudeRX.Name = "lblAmplitudeRX";
            this.lblAmplitudeRX.Size = new System.Drawing.Size(67, 16);
            this.lblAmplitudeRX.TabIndex = 1;
            this.lblAmplitudeRX.Text = "Amplitude";
            // 
            // lblFormeRX
            // 
            this.lblFormeRX.AutoSize = true;
            this.lblFormeRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormeRX.Location = new System.Drawing.Point(26, 40);
            this.lblFormeRX.Name = "lblFormeRX";
            this.lblFormeRX.Size = new System.Drawing.Size(46, 16);
            this.lblFormeRX.TabIndex = 0;
            this.lblFormeRX.Text = "Forme";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ReceptionDatas);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnClearBox
            // 
            this.btnClearBox.Location = new System.Drawing.Point(160, 135);
            this.btnClearBox.Name = "btnClearBox";
            this.btnClearBox.Size = new System.Drawing.Size(120, 23);
            this.btnClearBox.TabIndex = 12;
            this.btnClearBox.Text = "Clear box";
            this.btnClearBox.UseVisualStyleBackColor = true;
            this.btnClearBox.Click += new System.EventHandler(this.btnClearBox_Click);
            // 
            // ControlGen_V1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(580, 478);
            this.Controls.Add(this.gpBoxRX);
            this.Controls.Add(this.gpBoxTX);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ControlGen_V1";
            this.Text = "Control Gen.V1";
            this.groupBox1.ResumeLayout(false);
            this.gpBoxTX.ResumeLayout(false);
            this.gpBoxTX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequence)).EndInit();
            this.gpBoxRX.ResumeLayout(false);
            this.gpBoxRX.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.ComboBox cboxPortCOM;
        private System.Windows.Forms.GroupBox gpBoxTX;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Label lblAmplitude;
        private System.Windows.Forms.Label lblFormeS;
        private System.Windows.Forms.Label lblFrequence;
        private System.Windows.Forms.GroupBox gpBoxRX;
        private System.Windows.Forms.ListBox listBoxTX;
        private System.Windows.Forms.NumericUpDown numOffset;
        private System.Windows.Forms.NumericUpDown numAmplitude;
        private System.Windows.Forms.NumericUpDown numFrequence;
        private System.Windows.Forms.ComboBox cboxForme;
        private System.Windows.Forms.CheckBox chBoxSuavegarde;
        private System.Windows.Forms.Button btnSendContinu;
        private System.Windows.Forms.Button btnSend_1fois;
        private System.Windows.Forms.ListBox listBox_RX;
        private System.Windows.Forms.TextBox txtBoxOffset;
        private System.Windows.Forms.TextBox txtBoxAmplitude;
        private System.Windows.Forms.TextBox txtBoxFrequence;
        private System.Windows.Forms.TextBox txtBoxForme;
        private System.Windows.Forms.Label lblOffsetRX;
        private System.Windows.Forms.Label lblFrequenceRX;
        private System.Windows.Forms.Label lblAmplitudeRX;
        private System.Windows.Forms.Label lblFormeRX;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClearBox;
    }
}

