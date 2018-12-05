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
    public partial class Signup : Form
    {
        Cbdd bdd = new Cbdd();

        public Signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            String email = Signup_email.Text;
            String username = Signup_username.Text;
            String passwd = Signup_passwd.Text;
            String confpasswd = Signup_confpasswd.Text;

            if (email != "" && username != "" && passwd != "" && confpasswd != "")
            {
                bool isEmail = false;

                foreach (Char c in email)
                {
                    if (c == '@')
                    {
                        isEmail = true;
                    }
                }

                if (isEmail)
                {
                    if (passwd == confpasswd)
                    {
                        if (!bdd.CheckEmail(email))
                        {
                            if (!bdd.CheckUsername(username))
                            {
                                if (bdd.Signup(email, username, passwd))
                                {
                                    MessageBox.Show("Inscription réussie !", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Close();
                                }
                            } else {
                                MessageBox.Show("Le nom d'utilisateur est déjà utilisé !", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } else
                        {
                            MessageBox.Show("L'adresse e-mail est déjà utilisée !", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("Les mots de passe ne sont pas les mêmes.", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
