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
        Signin _singin = new Signin();
        Signup _signup = new Signup();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _singin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _signup.Show();
        }
    }
}
