using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Objetos
{
    public class User
    {
        public String mail { get; set; }
        public String passwd { get; set; }
        public bool admin { get; set; }


        public User()
        {
        }


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


    }
}
