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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signin _signin = new Signin(this);
            _signin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup _signup = new Signup();
            _signup.Show();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
