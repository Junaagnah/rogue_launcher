namespace rogue_launcher
{
    partial class MainScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonSignup = new System.Windows.Forms.Button();
            this.Settingspic = new System.Windows.Forms.PictureBox();
            this.ButtonPlay = new System.Windows.Forms.Button();
            this.welcomeText = new System.Windows.Forms.Label();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.BackgroundDownloader = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.Settingspic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROGUELIKE LAUNCHER";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(18, 57);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(30, 31);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1164, 542);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("http://185.213.24.116/~roguelike/", System.UriKind.Absolute);
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(18, 608);
            this.ButtonConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(879, 65);
            this.ButtonConnect.TabIndex = 2;
            this.ButtonConnect.Text = "CONNEXION";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonSignup
            // 
            this.ButtonSignup.Location = new System.Drawing.Point(912, 608);
            this.ButtonSignup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonSignup.Name = "ButtonSignup";
            this.ButtonSignup.Size = new System.Drawing.Size(273, 65);
            this.ButtonSignup.TabIndex = 3;
            this.ButtonSignup.Text = "INSCRIPTION";
            this.ButtonSignup.UseVisualStyleBackColor = true;
            this.ButtonSignup.Click += new System.EventHandler(this.button2_Click);
            // 
            // Settingspic
            // 
            this.Settingspic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settingspic.Image = global::rogue_launcher.Properties.Resources.settings_icon;
            this.Settingspic.Location = new System.Drawing.Point(1143, 9);
            this.Settingspic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Settingspic.Name = "Settingspic";
            this.Settingspic.Size = new System.Drawing.Size(39, 38);
            this.Settingspic.TabIndex = 4;
            this.Settingspic.TabStop = false;
            this.Settingspic.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.Location = new System.Drawing.Point(20, 609);
            this.ButtonPlay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(879, 65);
            this.ButtonPlay.TabIndex = 5;
            this.ButtonPlay.Text = "JOUER";
            this.ButtonPlay.UseVisualStyleBackColor = true;
            // 
            // welcomeText
            // 
            this.welcomeText.Location = new System.Drawing.Point(908, 609);
            this.welcomeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.welcomeText.Name = "welcomeText";
            this.welcomeText.Size = new System.Drawing.Size(273, 65);
            this.welcomeText.TabIndex = 6;
            this.welcomeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(20, 609);
            this.DownloadProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(1162, 65);
            this.DownloadProgressBar.TabIndex = 7;
            this.DownloadProgressBar.UseWaitCursor = true;
            this.DownloadProgressBar.Visible = false;
            // 
            // BackgroundDownloader
            // 
            this.BackgroundDownloader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // MainScreen
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.Settingspic);
            this.Controls.Add(this.ButtonSignup);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonPlay);
            this.Controls.Add(this.welcomeText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roguelike Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Settingspic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        public System.Windows.Forms.Button ButtonConnect;
        public System.Windows.Forms.Button ButtonSignup;
        public System.Windows.Forms.PictureBox Settingspic;
        public System.Windows.Forms.Button ButtonPlay;
        public System.Windows.Forms.Label welcomeText;
        public System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.ComponentModel.BackgroundWorker BackgroundDownloader;
    }
}

