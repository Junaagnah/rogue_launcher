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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signin _signin = new Signin();
            _signin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup _signup = new Signup();
            _signup.Show();
        }
    }
}
