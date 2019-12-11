using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace UOW
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public MongoClient Client { get; set; }
        public IMongoDatabase Database { get; set; }
        private IClientSessionHandle clientSessionHandle;
        
        public void Commit()
        {
            clientSessionHandle.CommitTransaction();
        }

        /// <summary>
        /// 释放与事务有关的资源
        /// </summary>
        public void Rollback()
        {
            clientSessionHandle.AbortTransaction();
        }

        public void Transaction()
        {
            clientSessionHandle = Client.StartSession();
            clientSessionHandle.StartTransaction();
        }
    }
}
