using DataMode;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLayer
{
    public class UserDal
    {
        private readonly Dall DALAcces = new Dall();

        public string CheckIfUserExists(string username, string password)
        {
            DALAcces.conn.Open();
            string query = "Select * FROM user WHERE username = @username AND password = @password";

            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@username", username));
            command.Parameters.Add(new MySqlParameter("@username", password));

            MySqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows == true)
            {
                return "User found in database";
            }
            else
            {
                return "User not found in database"; 
            }
        }

        public UserModel GetUser(UserModel user)
        {
            DALAcces.conn.Open();
            UserModel data = new UserModel();
            string query = "Select * FROM user WHERE username = @username";

            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@username", user.Username));

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Username = reader.GetString(1);
                data.Password = reader.GetString(3);

            }
            DALAcces.conn.Close();
            return data;
        }

        public bool RegisterUser(string username, string password)
        {
            bool succesfull = false;
            string query = "INSERT INTO User(username, password) " +
                           "VALUES (@username, @password)";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@username", username));
            command.Parameters.Add(new MySqlParameter("@password", password));
        
            try
            {
                command.ExecuteNonQuery();
                if (command.ExecuteNonQuery().Equals(1))
                {
                    DALAcces.conn.Close();
                    succesfull = true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                DALAcces.conn.Close();
            }
            return succesfull;
        }
    }
}
