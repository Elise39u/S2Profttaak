using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class UserLogic
    {
        private readonly UserLogic dal = new UserLogic();
        public bool LoginUser(string username, string password)
        {
           
            bool succesful = false;
            if (dal.LoginUser()) 

        }

        public bool RegisterUser()
        {
            bool succesful = false;

        }
    }
}
