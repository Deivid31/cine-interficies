using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Objetos
{
    public class User : IDataErrorInfo
    {
        public String mail { get; set; }
        public String passwd { get; set; }
        public bool admin { get; set; }

        public string Error
        {
            get
            {
                return "";
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = "";
                if (columnName == "mail")
                {
                    if (string.IsNullOrEmpty(mail))
                    {
                        result = "El email no puede ser nulo";
                    } else
                    {
                        if (!EsCorreoValido(mail))
                        {
                            result = "El correo no es válido";
                        }
                    }
                }

                if (columnName == "passwd")
                {
                    if (string.IsNullOrEmpty(passwd))
                    {
                        result = "La contraseña no puede ser nula";
                    }
                    else
                    {
                        if (passwd.Length < 3)
                        {
                            result = "La contraseña debe tener al menos 3 carácteres";
                        }
                    }
                }

                return result;
            }
        }

        public User() {}

        public User(String input1, String input2) {
            mail = input1;
            passwd = input2;
        }

        public User(String input1, String input2, bool input3)
        {
            mail = input1;
            passwd = input2;
            admin = input3;
        }




        private bool EsCorreoValido(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    if (email.Contains("."))
                    {
                        var direccionCorreo = new MailAddress(email);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
