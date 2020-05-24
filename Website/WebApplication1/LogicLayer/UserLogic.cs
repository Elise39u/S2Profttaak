using DalLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class UserLogic
    {
        public UserDal UserDal { get; set; } = new UserDal();

        public string DoLogin(string username, string password)
        {
            string getUser = UserDal.CheckIfUserExists(username, password);
            return getUser;
        }
    }
}
