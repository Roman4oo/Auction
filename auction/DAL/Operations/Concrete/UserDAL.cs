using auction.DAL.Core;
using auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction.DAL.Operations.Abstract
{
    class UserDAL 
    {
        DBManager dbManager = new DBManager("auction");
        IDbConnection connection = null;
        
        public void Insert(User user)
        {          
            string commandText = "INSERT INTO users (username, password, email)" + "values(@username, @password, @email)";
            dbManager.Insert(commandText, CommandType.Text, Parameters(user).ToArray());

        }
        public User GetByPassword(string email, string password)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@email", email, DbType.String));
            parameters.Add(dbManager.CreateParameter("@password", password, DbType.String));

            string commandText = "SELECT * FROM users WHERE email = @email AND password = @password;";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, parameters.ToArray(), out connection);
            try
            {
                var user = new User();
                while (dataReader.Read())
                {
                    user.ID = Convert.ToInt32(dataReader["user_id"]);
                    user.Name = Convert.ToString(dataReader["username"]);
                    user.Password = Convert.ToString(dataReader["password"]);
                    user.Email = Convert.ToString(dataReader["email"]);
                }

                return user;

            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                dataReader.Close();
                dbManager.CloseConnection(connection);
            }


        }
        public void Delete(int id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "delete from users where user_id = @Id;";
            dbManager.Delete(commandText, CommandType.Text, parameters.ToArray());
        }

        public List<IDbDataParameter> Parameters(User user)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@username", 50, user.Name, DbType.String));
            parameters.Add(dbManager.CreateParameter("@password", user.Password, DbType.String));
            parameters.Add(dbManager.CreateParameter("@email", user.Email, DbType.String));
            return parameters;
        }
    }
}
