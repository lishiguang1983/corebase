using kdb.platform.commons;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using PetaPoco.NetCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace kdb.platform.repositorys.DataProvide
{
    /// <summary>
    /// mysql
    /// </summary>
    public class MySqlContext : ISqlContext
    {
        private readonly IOptions<AppSettings> _settings;
        public MySqlContext(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        private IDbConnection _connection;
        /// <summary>
        /// 获取数据库连接桥
        /// </summary>
        private IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new MySqlConnection(_settings.Value.MySqlConnectionStrings);
                    _connection.Open();
                }
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                if (_connection.State == ConnectionState.Broken)
                {
                    _connection.Close();
                    _connection.Open();
                }
                return _connection;
            }
        }

        private Database _database;

        public Database DataBase
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database(Connection);
                }
                return _database;
            }
        }
        #region IDisposable Implementation

        protected bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                // Do nothing if the object has already been disposed of.
                if (disposed)
                    return;
                if (disposing)
                {
                    // Release disposable objects used by this instance here.
                    if (_connection != null)
                        _connection.Dispose();
                }

                // Release unmanaged resources here. Don't access reference type fields.

                // Remember that the object has been disposed of.
                disposed = true;
            }
        }
        public virtual void Dispose()
        {
            Dispose(true);
            // Unregister object for finalization.
            GC.SuppressFinalize(this);
        }
        #endregion  
    }
}
