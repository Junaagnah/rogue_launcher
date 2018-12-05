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
    public partial class Settings : Form
    {
        Form1 form;
        User user;

        public Settings(Form1 f, User user)
        {
            InitializeComponent();
            this.form = f;
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.user = null;
            form.label2.Text = "";
            form.Settingspic.Hide();
            form.ButtonConnect.Show();
            form.ButtonSignup.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.user.isAdmin())
            {
                Admin admin = new Admin();
                admin.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Vous devez être administrateur pour accéder à cette fenêtre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
