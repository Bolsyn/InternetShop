using InternetShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace InternetShop.Data
{
    public class GameDataAccess : DbDataAccess<Game>
    {        

        public override void Delete(Game game,string name)
        {
            string deleteSqlScript = $"Delete from Game where Name = '{name}'";

            using (var transaction = connection.BeginTransaction())
            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = deleteSqlScript;

                try
                {
                    command.Transaction = transaction;

                    var nameParameter = factory.CreateParameter();
                    nameParameter.DbType = System.Data.DbType.String;
                    nameParameter.Value = game.Name;
                    nameParameter.ParameterName = "Name";

                    command.Parameters.Add(nameParameter);                 

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

        public override void Insert(Game game)
        {
            string insertSqlScript = "Insert into Game values (...)";

            using (var transaction = connection.BeginTransaction())
            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = insertSqlScript;

                try
                {
                    command.Transaction = transaction;

                    var loginParameter = factory.CreateParameter();
                    loginParameter.DbType = System.Data.DbType.String;
                    loginParameter.Value = game.Name;
                    loginParameter.ParameterName = "Name";

                    command.Parameters.Add(loginParameter);

                    var passwordParameter = factory.CreateParameter();
                    passwordParameter.DbType = System.Data.DbType.String;
                    passwordParameter.Value = game.Price;
                    passwordParameter.ParameterName = "Price";

                    command.Parameters.Add(passwordParameter);

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

        public override ICollection<Game> Select()
        {
            var selectSqlScript = $"select * from Game ";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;

            var dataReader = command.ExecuteReader();

            var users = new List<Game>();

            while (dataReader.Read())
            {
                users.Add(new Game
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                    Price = double.Parse(dataReader["Price"].ToString())
                });
            }

            dataReader.Close();
            command.Dispose();
            return users;
            
        }

        public override void Update(Game game, string name)
        {
            string updateSqlScript = $"Update Game set Name = '{name}'";

            using (var transaction = connection.BeginTransaction())
            using (var command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = updateSqlScript;

                try
                {
                    command.Transaction = transaction;

                    var nameParameter = factory.CreateParameter();
                    nameParameter.DbType = System.Data.DbType.String;
                    nameParameter.Value = game.Name;
                    nameParameter.ParameterName = "Name";
                    command.Parameters.Add(nameParameter);

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
    }
}
