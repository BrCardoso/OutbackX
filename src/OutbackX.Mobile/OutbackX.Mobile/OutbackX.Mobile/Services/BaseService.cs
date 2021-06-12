using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OutbackX.Mobile.Config;
using OutbackX.Mobile.Models;
using SQLite;
using Xamarin.Forms;

namespace OutbackX.Mobile.Services
{
    public abstract class BaseService<T> : IService<T>, IDisposable where T : new()
    {
        private readonly SQLiteConnection dbConnection;

        public BaseService(IDbPathConfig dbPathConfig)
        {
            var dbFile = Path.Combine(dbPathConfig.Path, "Usuario.db");
            this.dbConnection = new SQLiteConnection(dbFile);
            this.dbConnection.CreateTable<Usuario>();
            this.dbConnection.CreateTable<Estabelecimento>();
        }

        public void Dispose()
        {
            this.dbConnection.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbConnection.Table<T>().ToList();
        }

        public T Insert(T model)
        {
            this.dbConnection.Insert(model);
            return model;
        }

        public T Update(T model)
        {
            this.dbConnection.Update(model);
            return model;
        }

        public void Delete(T model)
        {
            this.dbConnection.Delete(model);
        }

        public abstract T GetById(int id);

        protected T FindWithQuery(string query, params object[] args)
        {
            return this.dbConnection.FindWithQuery<T>(query, args);
        }
    }
}
