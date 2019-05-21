using auction.DAL.Core;
using auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction.DAL.Operations.Concrete
{
    class LotDAL
    {
        DBManager dbManager = new DBManager("auction");
        IDbConnection connection = null;
        public void Insert(Lot lot)
        {
            string commandText = "INSERT INTO lots (name, price, time_to)" + "values(@name, @price, @time_to)";
            dbManager.Insert(commandText, CommandType.Text, Parameters(lot).ToArray());

        }

        public void Delete(int id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "delete from lots where lot_id = @Id;";
            dbManager.Delete(commandText, CommandType.Text, parameters.ToArray());
        }

        public List<Lot> GetAll()
        {
            string commandText = "select * from lots";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, null, out connection);
            try
            {
                var lots = new List<Lot>();
                while (dataReader.Read())
                {
                    var lot = new Lot();
                    lot.ID = Convert.ToInt32(dataReader["lot_id"]);
                    lot.Name = Convert.ToString(dataReader["name"]);
                    lot.Price = Convert.ToDouble(dataReader["price"]);
                    lot.TimeTo = Convert.ToDouble(dataReader["time_to"]);
                    lots.Add(lot);
                }

                return lots;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataReader.Close();
                dbManager.CloseConnection(connection);
            }
        }



        public List<IDbDataParameter> Parameters(Lot lot)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@name", lot.Name, DbType.String));
            parameters.Add(dbManager.CreateParameter("@price", lot.Price, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@time_to", lot.TimeTo, DbType.Double));
            return parameters;
        }
    }
}
