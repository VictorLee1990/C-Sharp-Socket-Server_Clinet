namespace Socket_Server_Clinet
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.serverButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.clinetButton = new System.Windows.Forms.Button();
            this.enterbutton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.CreateServer = new System.Windows.Forms.RadioButton();
            this.CreateClinet = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverButton
            // 
            this.serverButton.Location = new System.Drawing.Point(36, 52);
            this.serverButton.Name = "serverButton";
            this.serverButton.Size = new System.Drawing.Size(72, 32);
            this.serverButton.TabIndex = 0;
            this.serverButton.Text = "建立server";
            this.serverButton.UseVisualStyleBackColor = true;
            this.serverButton.Click += new System.EventHandler(this.serverButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "";
            this.textBox1.Text = "127.0.0.1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 90);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(295, 142);
            this.textBox2.TabIndex = 2;
            // 
            // clinetButton
            // 
            this.clinetButton.Location = new System.Drawing.Point(121, 52);
            this.clinetButton.Name = "clinetButton";
            this.clinetButton.Size = new System.Drawing.Size(72, 32);
            this.clinetButton.TabIndex = 3;
            this.clinetButton.Text = "clinet";
            this.clinetButton.UseVisualStyleBackColor = true;
            this.clinetButton.Click += new System.EventHandler(this.clinetButton_Click);
            // 
            // enterbutton
            // 
            this.enterbutton.Location = new System.Drawing.Point(211, 247);
            this.enterbutton.Name = "enterbutton";
            this.enterbutton.Size = new System.Drawing.Size(75, 23);
            this.enterbutton.TabIndex = 4;
            this.enterbutton.Text = "Enter";
            this.enterbutton.UseVisualStyleBackColor = true;
            this.enterbutton.Click += new System.EventHandler(this.enterbutton_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(36, 247);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(169, 22);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "monkey";
            // 
            // CreateServer
            // 
            this.CreateServer.AutoSize = true;
            this.CreateServer.Location = new System.Drawing.Point(12, 12);
            this.CreateServer.Name = "CreateServer";
            this.CreateServer.Size = new System.Drawing.Size(89, 16);
            this.CreateServer.TabIndex = 7;
            this.CreateServer.Text = "Create  Server";
            this.CreateServer.UseVisualStyleBackColor = true;
            // 
            // CreateClinet
            // 
            this.CreateClinet.AutoSize = true;
            this.CreateClinet.Location = new System.Drawing.Point(12, 34);
            this.CreateClinet.Name = "CreateClinet";
            this.CreateClinet.Size = new System.Drawing.Size(87, 16);
            this.CreateClinet.TabIndex = 8;
            this.CreateClinet.Text = "Create  Clinet";
            this.CreateClinet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "連線狀態";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Server IP:";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(209, 52);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(72, 32);
            this.disconnectButton.TabIndex = 11;
            this.disconnectButton.Text = "disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 291);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateClinet);
            this.Controls.Add(this.CreateServer);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.enterbutton);
            this.Controls.Add(this.clinetButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.serverButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button serverButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button clinetButton;
        private System.Windows.Forms.Button enterbutton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton CreateServer;
        private System.Windows.Forms.RadioButton CreateClinet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox textBox2;
    }
}

