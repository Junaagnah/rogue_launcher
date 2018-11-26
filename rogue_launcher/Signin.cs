using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace rogue_launcher
{
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email = Signin_email.Text;
            String passwd = Signin_password.Text;

            if (email != "" && passwd != "")
            {
                bool isEmail = false;

                if (email.Length > 0)
                {
                    foreach (char c in email)
                    {
                        if (c == '@')
                        {
                            isEmail = true;
                        }
                    }
                }

                if (isEmail)
                {

                } else
                {
                    MessageBox.Show("Veuillez entrer une adresse e-mail valide.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            } else
            {
                MessageBox.Show("Merci de remplir tous les champs.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
