using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rogue_launcher
{
    public partial class Form1 : Form
    {
        public User user;

        public Form1()
        {
            InitializeComponent();
            this.user = null;
            Settingspic.Hide();
            ButtonPlay.Hide();
            welcomeText.Hide();
            welcomeText.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signin signin = new Signin(this);
            signin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this, this.user);
            settings.Show();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
