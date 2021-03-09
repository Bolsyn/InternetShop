using InternetShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace InternetShop.Data
{
    public class GameDataAccess : DbDataAccess<Game>
    {        

        public override void Delete(Game game)
        {
            var deleteSqlScript = "";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = deleteSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
            
                
        }
        public override void Insert(Game game)
        {
            var insertSqlScript = "";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = insertSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public override ICollection<Game> Select(Game game)
        {
            var selectSqlScript = "";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var games = new List<Game>();
            while (dataReader.Read())
            {
                games.Add(new Game
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                    Price = double.Parse(dataReader["Price"].ToString()),
                    Developer = dataReader["Developer"].ToString(),
                    Description = dataReader["Description"].ToString(),
                    Rating = double.Parse(dataReader["Name"].ToString())

                });
            }
            dataReader.Close();
            command.Dispose();

            return games;
        }

        public override ICollection<Game> Select(string selectSqlScript)
        {

            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var games = new List<Game>();
            while (dataReader.Read())
            {
                games.Add(new Game
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                    Price = double.Parse(dataReader["Price"].ToString()),
                    Developer = dataReader["Developer"].ToString(),
                    Description = dataReader["Description"].ToString(),
                    Rating = double.Parse(dataReader["Name"].ToString())

                });
            }
            dataReader.Close();
            command.Dispose();

            return games;
        }

        public override void Update(Game game)
        {
            var updateSqlScript = "";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = updateSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }
    
    }
}
