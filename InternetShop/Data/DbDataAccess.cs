﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using InternetShop.Services;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace InternetShop.Data
{
    public abstract class DbDataAccess<T> : IDisposable
    {
        protected readonly DbProviderFactory factory;
        protected readonly DbConnection connection;

        public DbDataAccess()
        {
            factory = DbProviderFactories.GetFactory("ConnectedProvider");
            connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationService.Configuration["DataAccessConnectionString"];
            connection.Open();
        }
        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(T entity);
        public abstract ICollection<T> Select(T entity);
        public void Dispose()
        {
            connection.Close();
        }
    }
}
