using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dojoDiner.Models;

namespace dojoDiner.Factory
{
    public class MenuItemFactory : IFactory<MenuItem>
    {
        private string connectionString;
        public MenuItemFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=dojodiner;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(MenuItem item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"INSERT INTO MENUITEM (NAME, PRICE, DESCRIPTION, ISVEGGO, ISAVAILABLE, CATEGORY) VALUES ('{item.Name}', {item.Price}, '{item.Description}', {item.isVeggo}, {item.isAvailable}, '{item.Category}')";
                
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<MenuItem> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<MenuItem>("SELECT * FROM menuItem");
            }
        }
        // public User FindByID(int id)
        // {
        //     using (IDbConnection dbConnection = Connection)
        //     {
        //         dbConnection.Open();
        //         return dbConnection.Query<User>("SELECT * FROM users WHERE id = @Id", new { Id = id }).FirstOrDefault();
        //     }
        // }
    }
}