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
                ExecuteTranaction(command);
            }
        }

        public override ICollection<Account> Select()
        {
            return null;
        }

        public override void Update(Account entity)
        {
            
        }
    }
}
