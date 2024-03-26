using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person:BaseEntity
    {
        private string username;
        private string pass;
        private bool isAdmin;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
   
        public bool IsAdmin
        {
            get { return isAdmin;}
            set { isAdmin = value;}
        }

        public string Pass { get => pass; set => pass = value; }
    }
}
