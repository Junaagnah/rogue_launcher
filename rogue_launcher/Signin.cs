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
        Cbdd bdd = new Cbdd();
        Form1 form = null;
        public Signin(Form1 f)
        {
            InitializeComponent();
            form = f;
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
                    if (bdd.CheckEmail(email)){

                        if (bdd.CheckBan(email))
                        {
                            MessageBox.Show("Votre compte a été banni  ¯\\_(ツ)_/¯", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            User user = bdd.Signin(email, passwd);

                            if (user != null)
                            {
                                form.user = user;
                                form.ButtonConnect.Hide();
                                form.ButtonSignup.Hide();
                                form.label2.Text = "Bienvenue \r\n" + user.pseudo;
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cette adresse e-mail ne correspond a aucun compte enregistré, merci de créer un compte si vous n'en possédez pas.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } else
                {
                    MessageBox.Show("Veuillez entrer une adresse e-mail valide.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            } else
            {
                MessageBox.Show("Merci de remplir tous les champs.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
