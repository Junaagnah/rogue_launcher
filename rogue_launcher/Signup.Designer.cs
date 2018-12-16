namespace rogue_launcher
{
    partial class Signup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Signup_confpasswd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Signup_passwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Signup_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Signup_email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Signup_confpasswd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Signup_passwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Signup_username);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Signup_email);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Signup_confpasswd
            // 
            this.Signup_confpasswd.Location = new System.Drawing.Point(10, 257);
            this.Signup_confpasswd.Name = "Signup_confpasswd";
            this.Signup_confpasswd.Size = new System.Drawing.Size(502, 26);
            this.Signup_confpasswd.TabIndex = 9;
            this.Signup_confpasswd.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(436, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "CONFIRMATION DU MOT DE PASSE :";
            // 
            // Signup_passwd
            // 
            this.Signup_passwd.Location = new System.Drawing.Point(10, 189);
            this.Signup_passwd.Name = "Signup_passwd";
            this.Signup_passwd.Size = new System.Drawing.Size(502, 26);
            this.Signup_passwd.TabIndex = 7;
            this.Signup_passwd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "MOT DE PASSE :";
            // 
            // Signup_username
            // 
            this.Signup_username.Location = new System.Drawing.Point(10, 122);
            this.Signup_username.Name = "Signup_username";
            this.Signup_username.Size = new System.Drawing.Size(502, 26);
            this.Signup_username.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "NOM D\'UTILISATEUR :";
            // 
            // Signup_email
            // 
            this.Signup_email.Location = new System.Drawing.Point(10, 54);
            this.Signup_email.Name = "Signup_email";
            this.Signup_email.Size = new System.Drawing.Size(502, 26);
            this.Signup_email.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADRESSE E-MAIL :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(396, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "VALIDER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 57);
            this.button2.TabIndex = 2;
            this.button2.Text = "ANNULER";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Signup
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 388);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSCRIPTION";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Signup_passwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Signup_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Signup_email;
        private System.Windows.Forms.TextBox Signup_confpasswd;
        private System.Windows.Forms.Label label4;
    }
}