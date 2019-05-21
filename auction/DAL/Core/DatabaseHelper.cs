using System;
using System.Data;
using System.Data.Common;
namespace auction.DAL.Core
{
    public class DatabaseHelper
    {

        public ProviderManager ProviderManager { get; set; }
        public string ConnectionString { get; set; }

        public DatabaseHelper()
        {
            ConnectionString = ConfigurationSettings.ConnectionString;
            ProviderManager = new ProviderManager();
        }
        public DatabaseHelper(string connectionName)
        {
            ConnectionString = ConfigurationSettings.GetConnectionString(connectionName);
            ProviderManager = new ProviderManager(ConfigurationSettings.GetProviderName(connectionName));
        }
        public DatabaseHelper(string connectionString, string providerName)
        {
            ConnectionString = connectionString;
            ProviderManager = new ProviderManager(providerName);
        }
        public IDbConnection GetConnection()
            {
                try
                {
                    var connection = ProviderManager.Factory.CreateConnection();
                    connection.ConnectionString = ConnectionString;
                    connection.Open();

                    return connection;
                }
                catch (Exception)
                {
                    throw new Exception("Error occured while creating connection.Please check connection string and provider name.");
                }
            }
            public void CloseConnection(IDbConnection connection)
            {
                connection.Close();
            }
            public IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType)
            {
                try
                {
                    IDbCommand command = ProviderManager.Factory.CreateCommand();
                    command.CommandText = commandText;
                    command.Connection = connection;
                    command.CommandType = commandType;
                    return command;
                }
                catch (Exception)
                {
                    throw new Exception("Invalid parameter 'commandText'.");
                }
            }

            public DbDataAdapter GetDataAdapter(IDbCommand command)
            {
                DbDataAdapter adapter = ProviderManager.Factory.CreateDataAdapter();
                adapter.SelectCommand = (DbCommand)command;
                adapter.InsertCommand = (DbCommand)command;
                adapter.UpdateCommand = (DbCommand)command;
                adapter.DeleteCommand = (DbCommand)command;
                return adapter;
            }
            public DbParameter GetParameter(string name, object value, DbType dbType)
            {
                try
                {
                    DbParameter dbParam = ProviderManager.Factory.CreateParameter();
                    dbParam.ParameterName = name;
                    dbParam.Value = value;
                    dbParam.Direction = ParameterDirection.Input;
                    dbParam.DbType = dbType;
                    return dbParam;
                }
                catch (Exception)
                {
                    throw new Exception("Invalid parameter or type.");
                }
            }
            public DbParameter GetParameter(string name, object value, DbType dbType, ParameterDirection parameterDirection)
            {
                try
                {
                    DbParameter dbParam = ProviderManager.Factory.CreateParameter();
                    dbParam.ParameterName = name;
                    dbParam.Value = value;
                    dbParam.Direction = parameterDirection;
                    dbParam.DbType = dbType;
                    return dbParam;
                }
                catch (Exception)
                {
                    throw new Exception("Invalid parameter or type");
                }
            }

            public DbParameter GetParameter(string name, object value, DbType dbType, int size, ParameterDirection parameterDirection)
            {
                try
                {
                    DbParameter dbParam = ProviderManager.Factory.CreateParameter();
                    dbParam.ParameterName = name;
                    dbParam.Value = value;
                    dbParam.Size = size;
                    dbParam.Direction = parameterDirection;
                    dbParam.DbType = dbType;
                    return dbParam;
                }
                catch (Exception)
                {
                    throw new Exception("Invalid parameter or type.");
                }
            }

        }
    }

