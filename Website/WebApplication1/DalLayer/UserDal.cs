using DataMode;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string query = "Select * FROM TowerUser WHERE username = @username AND password = @password";

            SqlCommand command = new SqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@password", password));

            SqlDataReader reader = command.ExecuteReader();
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
            string query = "Select * FROM TowerUser WHERE username = @username";

            SqlCommand command = new SqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new SqlParameter("@username", user.Username));

            SqlDataReader reader = command.ExecuteReader();
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
            string query = "INSERT INTO TowerUser(username, password) " +
                           "VALUES (@username, @password)";
            DALAcces.conn.Open();
            SqlCommand command = new SqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@password", password));
        
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
