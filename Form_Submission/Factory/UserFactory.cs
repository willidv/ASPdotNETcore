using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Form_Submission.Models;

namespace Form_Submission.Factory
{
    public class UserFactory : IFactory<User>
    {
        private string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=users;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(User user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"INSERT INTO users (First_name, Last_name, Age, Email, Password) VALUES ('{user.First_Name}', '{user.Last_Name}', {user.Age}, '{user.Email}', '{user.Password}')";
                
                dbConnection.Open();
                dbConnection.Execute(query, user);
            }
        }
        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }
    }
}