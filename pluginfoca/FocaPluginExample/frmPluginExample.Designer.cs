using System.Windows.Forms;

namespace FocaPluginExample
{
    partial class FrmPluginExample
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
            this.panel = new System.Windows.Forms.Panel();
            this.btnSendFoca = new System.Windows.Forms.Button();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnSendFoca);
            this.panel.Controls.Add(this.lblDomain);
            this.panel.Controls.Add(this.lblWelcome);
            this.panel.Controls.Add(this.txtDomain);
            this.panel.Controls.Add(this.listBox);
            this.panel.Location = new System.Drawing.Point(8, 8);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(463, 237);
            this.panel.TabIndex = 0;
            // 
            // btnSendFoca
            // 
            this.btnSendFoca.Location = new System.Drawing.Point(68, 128);
            this.btnSendFoca.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendFoca.Name = "btnSendFoca";
            this.btnSendFoca.Size = new System.Drawing.Size(81, 21);
            this.btnSendFoca.TabIndex = 3;
            this.btnSendFoca.Text = "Send to Foca";
            this.btnSendFoca.UseVisualStyleBackColor = true;
            this.btnSendFoca.Click += new System.EventHandler(this.btnSendFoca_Click);
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(65, 90);
            this.lblDomain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(43, 13);
            this.lblDomain.TabIndex = 2;
            this.lblDomain.Text = "Domain";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(65, 45);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(166, 13);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome to Foca Plugin Example";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(112, 88);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(2);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(309, 20);
            this.txtDomain.TabIndex = 0;
            // 
            // listBox
            // 
            this.listBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.listBox.Location = new System.Drawing.Point(68, 165);
            this.listBox.Margin = new System.Windows.Forms.Padding(2);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(81, 56);
            this.listBox.TabIndex = 4;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // FrmPluginExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 252);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPluginExample";
            this.Text = "Foca plugin example";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Button btnSendFoca;
        private ListBox listBox;
    }
}

