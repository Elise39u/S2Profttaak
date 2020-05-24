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
        private readonly UserDal  dal = new UserDal();
     
        public string DoLogin(string username, string password)
        {
            string getUser = dal.CheckIfUserExists(username, password);
            return getUser;
           // je kan er een bool van maken
        }
        public bool RegisterUser(string username, string password, string password2)
        {
            bool succesful = false;
            if( password == password2)
            {
                if (dal.RegisterUser(username, password) == true)
                {
                    succesful = true;
                }
            }
            return succesful;
            //oke klaar
        }
    }
}
