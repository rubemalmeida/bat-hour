namespace Bat_Hour
{
    partial class Initial
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
            this.components = new System.ComponentModel.Container();
            this.btnOnOff = new System.Windows.Forms.Button();
            this.tbxDiskUsage = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.tbxSetpoint = new System.Windows.Forms.TextBox();
            this.cbxPort = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOnOff
            // 
            this.btnOnOff.Enabled = false;
            this.btnOnOff.Location = new System.Drawing.Point(12, 65);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(192, 23);
            this.btnOnOff.TabIndex = 0;
            this.btnOnOff.Text = "Turn On";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnOnOff_Click);
            // 
            // tbxDiskUsage
            // 
            this.tbxDiskUsage.Location = new System.Drawing.Point(12, 39);
            this.tbxDiskUsage.Name = "tbxDiskUsage";
            this.tbxDiskUsage.ReadOnly = true;
            this.tbxDiskUsage.Size = new System.Drawing.Size(92, 20);
            this.tbxDiskUsage.TabIndex = 1;
            this.tbxDiskUsage.Text = "Usage: ";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 94);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(192, 173);
            this.listBox.TabIndex = 2;
            // 
            // tbxSetpoint
            // 
            this.tbxSetpoint.Location = new System.Drawing.Point(110, 39);
            this.tbxSetpoint.Name = "tbxSetpoint";
            this.tbxSetpoint.Size = new System.Drawing.Size(94, 20);
            this.tbxSetpoint.TabIndex = 3;
            this.tbxSetpoint.Text = "Setpoint: ";
            this.tbxSetpoint.TextChanged += new System.EventHandler(this.tbxSetpoint_TextChanged);
            // 
            // cbxPort
            // 
            this.cbxPort.FormattingEnabled = true;
            this.cbxPort.Location = new System.Drawing.Point(110, 12);
            this.cbxPort.Name = "cbxPort";
            this.cbxPort.Size = new System.Drawing.Size(94, 21);
            this.cbxPort.TabIndex = 4;
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(92, 21);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // Initial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 279);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbxPort);
            this.Controls.Add(this.tbxSetpoint);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.tbxDiskUsage);
            this.Controls.Add(this.btnOnOff);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(232, 318);
            this.MinimumSize = new System.Drawing.Size(232, 318);
            this.Name = "Initial";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.TextBox tbxDiskUsage;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox tbxSetpoint;
        private System.Windows.Forms.ComboBox cbxPort;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnConnect;
    }
}

