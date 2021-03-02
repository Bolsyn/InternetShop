using InternetShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace InternetShop.Data
{
    public class DataAccessAccount : DbDataAccess<Account>
    {
        public override void Delete(Account entity)
        {
            string deleteSqlScript = $"Delete From Account where TelephoneNumber = {entity.TelephoneNumber}";
            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = deleteSqlScript;
                command.ExecuteNonQuery();
            }
        }

        public override void Insert(Account entity)
        {
            string insertSqlScript = "Insert into Account values (@TelephoneNumber, @Wallet)";

            using (var transaction = connection.BeginTransaction())
            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = insertSqlScript;

                try
                {
                    command.Transaction = transaction;

                    var TelParameter = factory.CreateParameter();
                    TelParameter.DbType = System.Data.DbType.String;
                    TelParameter.Value = entity.TelephoneNumber;
                    TelParameter.ParameterName = "TelephoneNumber";

                    command.Parameters.Add(TelParameter);

                    var walletParameter = factory.CreateParameter();
                    walletParameter.DbType = System.Data.DbType.String;
                    walletParameter.Value = entity.Wallet;
                    walletParameter.ParameterName = "Wallet";

                    command.Parameters.Add(walletParameter);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (DbException)
                {
                    transaction.Rollback();
                }
            }
        }

        public override ICollection<Account> Select()
        {
            var selectSqlScript = "select * from Users";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;

            var dataReader = command.ExecuteReader();

            var account = new List<Account>();

            while (dataReader.Read()) // до тех пор пока есть, что читать - читай!
            {
                account.Add(new Account
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    TelephoneNumber = dataReader["TelephoneNumber"].ToString(),
                    Wallet = double.Parse(dataReader["Wallet"].ToString())
                });
            }

            dataReader.Close();
            command.Dispose();
            return account;
        }

        public override Account Select(string entity)
        {
            var selectSqlScript = $"select * from Account where TelephoneNumber = {entity}";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;

            var dataReader = command.ExecuteReader();

            var account = new Account()
            {
                Id = int.Parse(dataReader["Id"].ToString()),
                TelephoneNumber = dataReader["TelephoneNumber"].ToString(),
                Wallet = double.Parse(dataReader["Wallet"].ToString())
            };

            dataReader.Close();
            command.Dispose();
            return account;
        }

        public override void Update(Account entity)
        {
            string updateSqlScript = $"update Account Set Wallet = {entity.Wallet} where TelephoneNumber = {entity.TelephoneNumber}";

            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = updateSqlScript;


                var walletParameter = factory.CreateParameter();
                walletParameter.DbType = System.Data.DbType.String;
                walletParameter.Value = entity.Wallet;
                walletParameter.ParameterName = "Wallet";

                command.Parameters.Add(walletParameter);

                command.ExecuteNonQuery();
            }
        }
    }
}
