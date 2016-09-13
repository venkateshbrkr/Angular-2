using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Online.Data.EntityFramework
{
   
    public class EntityFrameworkService : IDataRepository, IDisposable
    {

        Entity _connection;

        /// <summary>
        /// Database Context
        /// </summary>
        public Entity dbConnection
        {
            get { return _connection; }
        }

        /// <summary>
        /// Commit Transaction
        /// </summary>
        /// <param name="closeSession"></param>
        public void CommitTransaction(Boolean closeSession)
        {
            dbConnection.SaveChanges();
        }

        /// <summary>
        /// Rollback Transaction
        /// </summary>
        /// <param name="closeSession"></param>
        public void RollbackTransaction(Boolean closeSession)
        {

        }

        public void Save(object entity) { }
        public void CreateSession() 
        {
            _connection = new APD(); 
        }
        public void BeginTransaction() { }

        public void CloseSession() { }

        /// <summary>
        /// Dispose of connection
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
