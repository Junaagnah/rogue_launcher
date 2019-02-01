using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rogue_launcher
{
    //Classe permettant d'effectuer des opérations sur les mots de passe
    public static class Password
    {
        //Vérifie si le mot de passe est valide
        public static bool checkPasswd(string password)
        {
            bool isPasswd = false;
            string errorMsg = "";
            bool upperCase = false;
            bool lowerCase = false;
            bool number = false;

            if (password.Length > 7)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] == ' ')
                    {
                        errorMsg = "Votre mot de passe ne peut pas contenir d'espace.";
                        break;
                    }
                }

                if (errorMsg == "")
                {
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (Char.IsUpper(password[i]))
                        {
                            upperCase = true;
                        }

                        if (Char.IsLower(password[i]))
                        {
                            lowerCase = true;
                        }

                        if (Char.IsNumber(password[i]))
                        {
                            number = true;
                        }
                    }

                    if (!upperCase || !lowerCase || !number)
                    {
                        errorMsg = "Votre mot de passe doit contenir au moins une lettre minuscule, une lettre majuscule et un chiffre.";
                    }
                    else
                    {
                        isPasswd = true;
                    }
                }
            }
            else
            {
                errorMsg = "Votre mot de passe doit contenir au moins 7 caractères.";
            }

            if (!isPasswd)
            {
                MessageBox.Show(errorMsg, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isPasswd;
        }
    }
}
