using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
// Fenêtre d'acceuil lors de l'execution du launcher
namespace rogue_launcher
{
    public partial class Form1 : Form
    {
        //Déclaration des variables nécessaires au fonctionnement de la classe
        public User user;
        private String userSession = "user";

        //Constructeur
        public Form1()
        {
            InitializeComponent();
            this.user = null;
            Settingspic.Hide();
            ButtonPlay.Hide();
            welcomeText.Hide();
            welcomeText.Text = "";
        }

        //Bouton qui va appeler l'affichage de la fenêtre de connexion
        private void button1_Click(object sender, EventArgs e)
        {
            Signin signin = new Signin(this);
            signin.Show();
        }

        //Bouton qui va appeler l'affichage de la fenêtre d'incription
        private void button2_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
        }

        //Bouton d'accès aux paramètres
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this, this.user);
            settings.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            if (!IsOnline())
            {
                ButtonConnect.Hide();
                ButtonSignup.Hide();
                ButtonPlay.Show();
                welcomeText.Text = "Vous êtes hors ligne.";
                welcomeText.Show();
                MessageBox.Show("Vous êtes hors ligne, vous pouvez jouer mais votre score ne sera pas enregistré.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (File.Exists(this.userSession))
                {
                    File.Delete(this.userSession);
                }

                using (StreamWriter tw = new StreamWriter(this.userSession, true))
                {
                    tw.Write("offline");
                }
            }
        }

        private bool IsOnline()
        {
            bool result = false;

            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        private void Form1_FormClosing(Object Sender, FormClosingEventArgs e)
        {
            if (File.Exists(this.userSession))
            {
                File.Delete(this.userSession);
            }
        }
    }
}
