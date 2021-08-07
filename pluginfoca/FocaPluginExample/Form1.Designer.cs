
namespace FocaPluginExample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.URLRELabel = new System.Windows.Forms.Label();
            this.URLREBox = new System.Windows.Forms.TextBox();
            this.Type = new System.Windows.Forms.Label();
            this.comboAlgoritmo = new System.Windows.Forms.ComboBox();
            this.panelReverse = new System.Windows.Forms.Panel();
            this.buttonRE = new System.Windows.Forms.Button();
            this.BoxModelRE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.frameFinal = new System.Windows.Forms.TextBox();
            this.frameInitial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFFStart = new System.Windows.Forms.Label();
            this.buttonFF = new System.Windows.Forms.Button();
            this.BoxModelFF = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.URLFFBox = new System.Windows.Forms.TextBox();
            this.URLFFLabel = new System.Windows.Forms.Label();
            this.panelFaceforensics = new System.Windows.Forms.Panel();
            this.panelKeras = new System.Windows.Forms.Panel();
            this.buttonKIO = new System.Windows.Forms.Button();
            this.URLKIOBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelReal = new System.Windows.Forms.Panel();
            this.buttonAgain = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panelFake = new System.Windows.Forms.Panel();
            this.buttonAgain2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panelError = new System.Windows.Forms.Panel();
            this.buttonAgain3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.panelKIOIMG = new System.Windows.Forms.Panel();
            this.buttonKIOIMG = new System.Windows.Forms.Button();
            this.URLModelKIOIMG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tamanioIMG = new System.Windows.Forms.TextBox();
            this.URLKIOIMG = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxLIME = new System.Windows.Forms.ComboBox();
            this.panelReverse.SuspendLayout();
            this.panelFaceforensics.SuspendLayout();
            this.panelKeras.SuspendLayout();
            this.panelLoading.SuspendLayout();
            this.panelReal.SuspendLayout();
            this.panelFake.SuspendLayout();
            this.panelError.SuspendLayout();
            this.panel.SuspendLayout();
            this.panelKIOIMG.SuspendLayout();
            this.SuspendLayout();
            // 
            // URLRELabel
            // 
            this.URLRELabel.AutoSize = true;
            this.URLRELabel.Location = new System.Drawing.Point(25, 10);
            this.URLRELabel.Name = "URLRELabel";
            this.URLRELabel.Size = new System.Drawing.Size(92, 13);
            this.URLRELabel.TabIndex = 0;
            this.URLRELabel.Text = "URL de la imagen";
            // 
            // URLREBox
            // 
            this.URLREBox.Location = new System.Drawing.Point(28, 26);
            this.URLREBox.Name = "URLREBox";
            this.URLREBox.Size = new System.Drawing.Size(648, 20);
            this.URLREBox.TabIndex = 1;
            // 
            // Type
            // 
            this.Type.AutoSize = true;
            this.Type.Location = new System.Drawing.Point(25, 68);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(83, 13);
            this.Type.TabIndex = 3;
            this.Type.Text = "Modelo a utilizar";
            // 
            // comboAlgoritmo
            // 
            this.comboAlgoritmo.FormattingEnabled = true;
            this.comboAlgoritmo.Items.AddRange(new object[] {
            "FaceForensics",
            "Reverse Engineering",
            "Keras",
            "KerasIMG"});
            this.comboAlgoritmo.Location = new System.Drawing.Point(27, 33);
            this.comboAlgoritmo.Name = "comboAlgoritmo";
            this.comboAlgoritmo.Size = new System.Drawing.Size(121, 21);
            this.comboAlgoritmo.TabIndex = 8;
            this.comboAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.comboAlgoritmo_SelectedIndexChanged);
            // 
            // panelReverse
            // 
            this.panelReverse.Controls.Add(this.buttonRE);
            this.panelReverse.Controls.Add(this.BoxModelRE);
            this.panelReverse.Controls.Add(this.URLRELabel);
            this.panelReverse.Controls.Add(this.URLREBox);
            this.panelReverse.Controls.Add(this.Type);
            this.panelReverse.Location = new System.Drawing.Point(2, 71);
            this.panelReverse.Name = "panelReverse";
            this.panelReverse.Size = new System.Drawing.Size(769, 338);
            this.panelReverse.TabIndex = 9;
            // 
            // buttonRE
            // 
            this.buttonRE.Location = new System.Drawing.Point(28, 141);
            this.buttonRE.Name = "buttonRE";
            this.buttonRE.Size = new System.Drawing.Size(75, 23);
            this.buttonRE.TabIndex = 5;
            this.buttonRE.Text = "Procesar";
            this.buttonRE.UseVisualStyleBackColor = true;
            this.buttonRE.Click += new System.EventHandler(this.buttonRE_Click);
            // 
            // BoxModelRE
            // 
            this.BoxModelRE.FormattingEnabled = true;
            this.BoxModelRE.Items.AddRange(new object[] {
            "0_32000_model_31_70-23.pickle",
            "0_32000_model_29.pickle",
            "0_64000_model_30.pickle"});
            this.BoxModelRE.Location = new System.Drawing.Point(28, 84);
            this.BoxModelRE.Name = "BoxModelRE";
            this.BoxModelRE.Size = new System.Drawing.Size(121, 21);
            this.BoxModelRE.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Servicio";
            // 
            // frameFinal
            // 
            this.frameFinal.Location = new System.Drawing.Point(16, 200);
            this.frameFinal.Name = "frameFinal";
            this.frameFinal.Size = new System.Drawing.Size(80, 20);
            this.frameFinal.TabIndex = 12;
            // 
            // frameInitial
            // 
            this.frameInitial.Location = new System.Drawing.Point(16, 142);
            this.frameInitial.Name = "frameInitial";
            this.frameInitial.Size = new System.Drawing.Size(80, 20);
            this.frameInitial.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Frame final";
            // 
            // labelFFStart
            // 
            this.labelFFStart.AutoSize = true;
            this.labelFFStart.Location = new System.Drawing.Point(13, 123);
            this.labelFFStart.Name = "labelFFStart";
            this.labelFFStart.Size = new System.Drawing.Size(62, 13);
            this.labelFFStart.TabIndex = 9;
            this.labelFFStart.Text = "Fame inicial";
            // 
            // buttonFF
            // 
            this.buttonFF.Location = new System.Drawing.Point(20, 257);
            this.buttonFF.Name = "buttonFF";
            this.buttonFF.Size = new System.Drawing.Size(75, 23);
            this.buttonFF.TabIndex = 8;
            this.buttonFF.Text = "Procesar";
            this.buttonFF.UseVisualStyleBackColor = true;
            this.buttonFF.Click += new System.EventHandler(this.buttonFF_Click);
            // 
            // BoxModelFF
            // 
            this.BoxModelFF.FormattingEnabled = true;
            this.BoxModelFF.Items.AddRange(new object[] {
            "ffpp_c40.pth",
            "ffpp_c23.pth"});
            this.BoxModelFF.Location = new System.Drawing.Point(16, 79);
            this.BoxModelFF.Name = "BoxModelFF";
            this.BoxModelFF.Size = new System.Drawing.Size(121, 21);
            this.BoxModelFF.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Modelo a utilizar";
            // 
            // URLFFBox
            // 
            this.URLFFBox.Location = new System.Drawing.Point(16, 27);
            this.URLFFBox.Name = "URLFFBox";
            this.URLFFBox.Size = new System.Drawing.Size(648, 20);
            this.URLFFBox.TabIndex = 2;
            // 
            // URLFFLabel
            // 
            this.URLFFLabel.AutoSize = true;
            this.URLFFLabel.Location = new System.Drawing.Point(13, 10);
            this.URLFFLabel.Name = "URLFFLabel";
            this.URLFFLabel.Size = new System.Drawing.Size(77, 13);
            this.URLFFLabel.TabIndex = 1;
            this.URLFFLabel.Text = "URL del vídeo";
            // 
            // panelFaceforensics
            // 
            this.panelFaceforensics.Controls.Add(this.buttonFF);
            this.panelFaceforensics.Controls.Add(this.frameFinal);
            this.panelFaceforensics.Controls.Add(this.URLFFLabel);
            this.panelFaceforensics.Controls.Add(this.label3);
            this.panelFaceforensics.Controls.Add(this.frameInitial);
            this.panelFaceforensics.Controls.Add(this.URLFFBox);
            this.panelFaceforensics.Controls.Add(this.label2);
            this.panelFaceforensics.Controls.Add(this.labelFFStart);
            this.panelFaceforensics.Controls.Add(this.BoxModelFF);
            this.panelFaceforensics.Location = new System.Drawing.Point(6, 77);
            this.panelFaceforensics.Name = "panelFaceforensics";
            this.panelFaceforensics.Size = new System.Drawing.Size(700, 332);
            this.panelFaceforensics.TabIndex = 11;
            // 
            // panelKeras
            // 
            this.panelKeras.Controls.Add(this.buttonKIO);
            this.panelKeras.Controls.Add(this.URLKIOBox);
            this.panelKeras.Controls.Add(this.label4);
            this.panelKeras.Location = new System.Drawing.Point(5, 77);
            this.panelKeras.Name = "panelKeras";
            this.panelKeras.Size = new System.Drawing.Size(697, 340);
            this.panelKeras.TabIndex = 13;
            // 
            // buttonKIO
            // 
            this.buttonKIO.Location = new System.Drawing.Point(15, 83);
            this.buttonKIO.Name = "buttonKIO";
            this.buttonKIO.Size = new System.Drawing.Size(75, 23);
            this.buttonKIO.TabIndex = 14;
            this.buttonKIO.Text = "Procesar";
            this.buttonKIO.UseVisualStyleBackColor = true;
            this.buttonKIO.Click += new System.EventHandler(this.buttonKIO_Click);
            // 
            // URLKIOBox
            // 
            this.URLKIOBox.Location = new System.Drawing.Point(15, 41);
            this.URLKIOBox.Name = "URLKIOBox";
            this.URLKIOBox.Size = new System.Drawing.Size(648, 20);
            this.URLKIOBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "URL del vídeo";
            // 
            // panelLoading
            // 
            this.panelLoading.Controls.Add(this.label5);
            this.panelLoading.Location = new System.Drawing.Point(4, 17);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(693, 395);
            this.panelLoading.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Procesando... Esto puede tardar un rato.";
            // 
            // panelReal
            // 
            this.panelReal.Controls.Add(this.buttonAgain);
            this.panelReal.Controls.Add(this.label6);
            this.panelReal.Location = new System.Drawing.Point(1, 2);
            this.panelReal.Name = "panelReal";
            this.panelReal.Size = new System.Drawing.Size(693, 369);
            this.panelReal.TabIndex = 15;
            // 
            // buttonAgain
            // 
            this.buttonAgain.Location = new System.Drawing.Point(271, 191);
            this.buttonAgain.Name = "buttonAgain";
            this.buttonAgain.Size = new System.Drawing.Size(122, 25);
            this.buttonAgain.TabIndex = 1;
            this.buttonAgain.Text = "Volver";
            this.buttonAgain.UseVisualStyleBackColor = true;
            this.buttonAgain.Click += new System.EventHandler(this.buttonAgain_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "El contenido es REAL";
            // 
            // panelFake
            // 
            this.panelFake.Controls.Add(this.buttonAgain2);
            this.panelFake.Controls.Add(this.label7);
            this.panelFake.Location = new System.Drawing.Point(7, 16);
            this.panelFake.Name = "panelFake";
            this.panelFake.Size = new System.Drawing.Size(693, 369);
            this.panelFake.TabIndex = 16;
            // 
            // buttonAgain2
            // 
            this.buttonAgain2.Location = new System.Drawing.Point(271, 191);
            this.buttonAgain2.Name = "buttonAgain2";
            this.buttonAgain2.Size = new System.Drawing.Size(122, 25);
            this.buttonAgain2.TabIndex = 1;
            this.buttonAgain2.Text = "Volver";
            this.buttonAgain2.UseVisualStyleBackColor = true;
            this.buttonAgain2.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "El contenido es FAKE";
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.buttonAgain3);
            this.panelError.Controls.Add(this.label8);
            this.panelError.Location = new System.Drawing.Point(5, 3);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(686, 393);
            this.panelError.TabIndex = 17;
            // 
            // buttonAgain3
            // 
            this.buttonAgain3.Location = new System.Drawing.Point(291, 144);
            this.buttonAgain3.Name = "buttonAgain3";
            this.buttonAgain3.Size = new System.Drawing.Size(75, 23);
            this.buttonAgain3.TabIndex = 1;
            this.buttonAgain3.Text = "Volver";
            this.buttonAgain3.UseVisualStyleBackColor = true;
            this.buttonAgain3.Click += new System.EventHandler(this.buttonAgain3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ha habido algún error";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.comboAlgoritmo);
            this.panel.Controls.Add(this.panelKIOIMG);
            this.panel.Controls.Add(this.panelFaceforensics);
            this.panel.Controls.Add(this.panelKeras);
            this.panel.Controls.Add(this.panelReverse);
            this.panel.Controls.Add(this.panelFake);
            this.panel.Controls.Add(this.panelError);
            this.panel.Controls.Add(this.panelLoading);
            this.panel.Controls.Add(this.panelReal);
            this.panel.Location = new System.Drawing.Point(2, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(694, 432);
            this.panel.TabIndex = 18;
            // 
            // panelKIOIMG
            // 
            this.panelKIOIMG.Controls.Add(this.buttonKIOIMG);
            this.panelKIOIMG.Controls.Add(this.URLModelKIOIMG);
            this.panelKIOIMG.Controls.Add(this.label9);
            this.panelKIOIMG.Controls.Add(this.label10);
            this.panelKIOIMG.Controls.Add(this.tamanioIMG);
            this.panelKIOIMG.Controls.Add(this.URLKIOIMG);
            this.panelKIOIMG.Controls.Add(this.label11);
            this.panelKIOIMG.Controls.Add(this.label12);
            this.panelKIOIMG.Controls.Add(this.comboBoxLIME);
            this.panelKIOIMG.Location = new System.Drawing.Point(4, 65);
            this.panelKIOIMG.Name = "panelKIOIMG";
            this.panelKIOIMG.Size = new System.Drawing.Size(700, 332);
            this.panelKIOIMG.TabIndex = 18;
            // 
            // buttonKIOIMG
            // 
            this.buttonKIOIMG.Location = new System.Drawing.Point(20, 257);
            this.buttonKIOIMG.Name = "buttonKIOIMG";
            this.buttonKIOIMG.Size = new System.Drawing.Size(75, 23);
            this.buttonKIOIMG.TabIndex = 8;
            this.buttonKIOIMG.Text = "Procesar";
            this.buttonKIOIMG.UseVisualStyleBackColor = true;
            this.buttonKIOIMG.Click += new System.EventHandler(this.buttonKIOIMG_Click);
            // 
            // URLModelKIOIMG
            // 
            this.URLModelKIOIMG.Location = new System.Drawing.Point(16, 80);
            this.URLModelKIOIMG.Name = "URLModelKIOIMG";
            this.URLModelKIOIMG.Size = new System.Drawing.Size(648, 20);
            this.URLModelKIOIMG.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "URL de la imagen";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "URL del modelo (TFHub)";
            // 
            // tamanioIMG
            // 
            this.tamanioIMG.Location = new System.Drawing.Point(15, 134);
            this.tamanioIMG.Name = "tamanioIMG";
            this.tamanioIMG.Size = new System.Drawing.Size(80, 20);
            this.tamanioIMG.TabIndex = 11;
            // 
            // URLKIOIMG
            // 
            this.URLKIOIMG.Location = new System.Drawing.Point(16, 27);
            this.URLKIOIMG.Name = "URLKIOIMG";
            this.URLKIOIMG.Size = new System.Drawing.Size(648, 20);
            this.URLKIOIMG.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Usar LIME";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Tamaño de la imagen";
            // 
            // comboBoxLIME
            // 
            this.comboBoxLIME.FormattingEnabled = true;
            this.comboBoxLIME.Items.AddRange(new object[] {
            "Sí",
            "No"});
            this.comboBoxLIME.Location = new System.Drawing.Point(15, 184);
            this.comboBoxLIME.Name = "comboBoxLIME";
            this.comboBoxLIME.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLIME.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 427);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "Prueba";
            this.panelReverse.ResumeLayout(false);
            this.panelReverse.PerformLayout();
            this.panelFaceforensics.ResumeLayout(false);
            this.panelFaceforensics.PerformLayout();
            this.panelKeras.ResumeLayout(false);
            this.panelKeras.PerformLayout();
            this.panelLoading.ResumeLayout(false);
            this.panelLoading.PerformLayout();
            this.panelReal.ResumeLayout(false);
            this.panelReal.PerformLayout();
            this.panelFake.ResumeLayout(false);
            this.panelFake.PerformLayout();
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.panelKIOIMG.ResumeLayout(false);
            this.panelKIOIMG.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label URLRELabel;
        private System.Windows.Forms.TextBox URLREBox;
        private System.Windows.Forms.Label Type;
        private System.Windows.Forms.ComboBox comboAlgoritmo;
        private System.Windows.Forms.Panel panelReverse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BoxModelRE;
        private System.Windows.Forms.Button buttonRE;
        private System.Windows.Forms.Button buttonFF;
        private System.Windows.Forms.TextBox frameFinal;
        private System.Windows.Forms.TextBox frameInitial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelFFStart;
        private System.Windows.Forms.ComboBox BoxModelFF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox URLFFBox;
        private System.Windows.Forms.Label URLFFLabel;
        private System.Windows.Forms.Panel panelFaceforensics;
        private System.Windows.Forms.Panel panelKeras;
        private System.Windows.Forms.Button buttonKIO;
        private System.Windows.Forms.TextBox URLKIOBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelLoading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelReal;
        private System.Windows.Forms.Button buttonAgain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelFake;
        private System.Windows.Forms.Button buttonAgain2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Button buttonAgain3;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelKIOIMG;
        private System.Windows.Forms.Button buttonKIOIMG;
        private System.Windows.Forms.TextBox URLModelKIOIMG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tamanioIMG;
        private System.Windows.Forms.TextBox URLKIOIMG;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxLIME;
    }
}