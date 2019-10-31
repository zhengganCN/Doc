using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Commons
{
    public class MongoDBContext
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;
        private readonly NLog.ILogger _nLogger;
        public MongoDBContext()
        {
            _nLogger= NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            _mongoClient = ConnectMongoDbClient();
            _mongoDatabase = GetMongoDbDatabase();
        }

        private string CollectionName<T>() where T : class
        {
            var collectionClassName = typeof(T).Name;
            return collectionClassName.Substring(0, collectionClassName.Length - 10);
        }

        private MongoClient ConnectMongoDbClient()
        {
            try
            {
                var mongoClient = new MongoClient(ConfigHelp.ConfigKeys.MongoDbConnectString);
                //_nLogger.LogInformation("MongoDb客户端连接成功");
                _nLogger.Info("MongoDb客户端连接成功");
                return mongoClient;
            }
            catch (Exception e)
            {
                _nLogger.Error("MongoDb客户端连接失败" + e.Message);
                return null;
            }
        }

        private IMongoDatabase GetMongoDbDatabase()
        {
            try
            {
                var database = _mongoClient.GetDatabase(ConfigHelp.ConfigKeys.MongoDbDatabase);
                _nLogger.Info("连接MongoDb数据库成功;");
                return database;
            }
            catch (Exception e)
            {
                _nLogger.Error("连接MongoDb数据库失败;" + e.Message);
                return null;
            }
        }
        public IList<BsonDocument> GetALLDatabase()
        {
            try
            {
                return _mongoClient.ListDatabases().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #region 插入操作
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="data">实体数据</param>
        /// <returns></returns>
        public long InsertOne<T>(T data) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                mongoCollection.InsertOne(data);
                _nLogger.Info("成功插入一条数据;");
                _nLogger.Debug(data.ToJson());
                return 1;
            }
            catch (Exception e)
            {
                _nLogger.Error("插入一条数据失败成功;" + e.Message);
                _nLogger.Debug(data.ToJson());
                return -1;
            }
        }
        /// <summary>
        /// 异步插入一条数据
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="data">实体数据</param>
        /// <returns></returns>
        public async Task<int> InsertOneAsync<T>(T data) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                await mongoCollection.InsertOneAsync(data);
                _nLogger.Info("成功插入一条数据;");
                _nLogger.Debug(data.ToJson());
                return 1;
            }
            catch (Exception e)
            {
                _nLogger.Error("插入一条数据失败成功;" + e.Message);
                _nLogger.Debug(data.ToJson());
                return 0;
            }
        }
        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="datas">实体数据集合</param>
        public int InsertMany<T>(IList<T> datas) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                mongoCollection.InsertMany(datas);
                _nLogger.Info("成功插入{0}条数据;",datas.Count);
                _nLogger.Debug(datas.ToJson());
                return datas.Count;
            }
            catch (Exception e)
            {
                _nLogger.Error("成功插入{0}条数据;" + e.Message, datas.Count);
                _nLogger.Debug(datas.ToJson());
                return -1;
            }
        }
        /// <summary>
        /// 异步插入多条数据
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="datas">实体数据集合</param>
        /// <returns></returns>
        public async Task<int> InsertManyAsync<T>(IList<T> datas) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                
                await mongoCollection.InsertManyAsync(datas);
                _nLogger.Info("成功插入{0}条数据;", datas.Count);
                _nLogger.Debug(datas.ToJson());
                return datas.Count;
            }
            catch (Exception e)
            {
                _nLogger.Error("插入{0}条数据失败;" + e.Message, datas.Count);
                _nLogger.Debug(datas.ToJson());
                return -1;
            }
        }
        #endregion

        
        #region 查询操作
        public T FindFirst<T>(FilterDefinition<T> filter,SortDefinition<T> sortDefinition=null) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                T document=null;
                if (sortDefinition==null)
                {
                    document= mongoCollection.Find(filter).FirstOrDefault();
                }
                else
                {
                    document = mongoCollection.Find(filter).Sort(sortDefinition).FirstOrDefault();
                }
                _nLogger.Info("查询数据成功");
                _nLogger.Debug(document.ToJson());
                return document;
            }
            catch (Exception e)
            {
                _nLogger.Error("查询数据失败;" + e.Message);
                _nLogger.Debug(filter.ToJson());
                return null;
            }
        }
        public async Task<T> FindFirstAsync<T>(FilterDefinition<T> filter, SortDefinition<T> sortDefinition = null) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                T document = null;
                if (sortDefinition == null)
                {
                    document = await mongoCollection.Find(filter).FirstOrDefaultAsync();
                }
                else
                {
                    document = await mongoCollection.Find(filter).Sort(sortDefinition).FirstOrDefaultAsync();
                }
                _nLogger.Info("查询数据成功");
                _nLogger.Debug(document.ToJson());
                return document;
            }
            catch (Exception e)
            {
                _nLogger.Error("查询数据失败;" + e.Message);
                _nLogger.Debug(filter.ToJson());
                return null;
            }
        }
        public IList<T> Find<T>(FilterDefinition<T> filter, int pageIndex = 1, int pageSize = 10, SortDefinition<T> sortDefinition = null) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                IList<T> documents = null;
                if (sortDefinition == null)
                {
                    documents = mongoCollection.Find(filter).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
                }
                else
                {
                    documents = mongoCollection.Find(filter).Sort(sortDefinition).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
                }
                _nLogger.Info("查询数据成功");
                _nLogger.Debug(documents.ToJson());
                return documents;
            }
            catch (Exception e)
            {
                _nLogger.Error("查询数据失败;" + e.Message);
                _nLogger.Debug(filter.ToJson());
                return null;
            }
        }
        public IList<T> FindAll<T>(FilterDefinition<T> filter,SortDefinition<T> sortDefinition = null) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                IList<T> documents = null;
                if (sortDefinition == null)
                {
                    documents = mongoCollection.Find(filter).ToList();
                }
                else
                {
                    documents = mongoCollection.Find(filter).Sort(sortDefinition).ToList();
                }
                _nLogger.Info("查询数据成功");
                _nLogger.Debug(documents.ToJson());
                return documents;
            }
            catch (Exception e)
            {
                _nLogger.Error("查询数据失败;" + e.Message);
                _nLogger.Debug(filter.ToJson());
                return null;
            }
        }
        #endregion
        #region 统计操作
        public long Count<T>(FilterDefinition<T> filter) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var count = mongoCollection.CountDocuments(filter);
                _nLogger.Info("查询统计数据成功");
                _nLogger.Debug(count.ToString());
                return count;
            }
            catch (Exception e)
            {
                _nLogger.Error("查询统计数据失败;" + e.Message);
                _nLogger.Debug(filter.ToJson());
                return -1;
            }
        }

        public async Task<long> CountAsync<T>(FilterDefinition<T> filter) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var count = await mongoCollection.CountDocumentsAsync(filter);
                _nLogger.Info("查询统计数据成功");
                _nLogger.Debug(count.ToString());
                return count;
            }
            catch (Exception e)
            {
                _nLogger.Error("查询统计数据失败;" + e.Message);
                _nLogger.Debug(filter.ToJson());
                return -1;
            }
        }
        #endregion
        #region 更新操作
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update"></param>
        /// <returns></returns>
        public long UpdateOne<T>(FilterDefinition<T> filter, UpdateDefinition<T> update) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var result = mongoCollection.UpdateOne(filter, update);
                _nLogger.Info("成功更新{0}条数据",result.ModifiedCount);
                _nLogger.Debug("更新条件：{0};\n更新数据：{1}",filter.ToJson(),update.ToJson());
                return result.ModifiedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("更新数据失败;异常信息：{0}",e.Message);
                _nLogger.Debug("更新条件：{0};\n更新数据：{1}", filter.ToJson(), update.ToJson());
                return -1;
            }
        }
        /// <summary>
        /// 异步更新一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task<long> UpdateOneAsync<T>(FilterDefinition<T> filter, UpdateDefinition<T> update) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var result= await mongoCollection.UpdateOneAsync(filter, update);
                _nLogger.Info("成功更新{0}条数据", result.ModifiedCount);
                _nLogger.Debug("更新条件：{0};\n更新数据：{1}", filter.ToJson(), update.ToJson());
                return result.ModifiedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("更新数据失败;异常信息：{0}", e.Message);
                _nLogger.Debug("更新条件：{0};\n更新数据：{1}", filter.ToJson(), update.ToJson());
                return -1;
            }
        }

        public long UpdateMany<T>(FilterDefinition<T> filter, UpdateDefinition<T> update) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var result = mongoCollection.UpdateMany(filter, update);
                _nLogger.Info("成功更新{0}条数据", result.ModifiedCount);
                _nLogger.Debug("更新条件：{0};\n更新数据：{1}", filter.ToJson(), update.ToJson());
                return result.ModifiedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("更新数据失败;异常信息：{0}", e.Message);
                _nLogger.Debug("更新条件：{0};\n更新数据：{1}", filter.ToJson(), update.ToJson());
                return -1;
            }
        }
        public async Task<long> UpdateManyAsync<T>(FilterDefinition<T> filter, UpdateDefinition<T> update) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var result = await mongoCollection.UpdateManyAsync(filter, update);
                if (result.IsModifiedCountAvailable)
                {
                    return result.ModifiedCount;
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// 替换数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        /// <param name="updateBsonDocument"></param>
        /// <returns></returns>
        public long ReplaceOne<T>(FilterDefinition<T> filter, T updateBsonDocument) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var replaceOneResult = mongoCollection.ReplaceOne(filter, updateBsonDocument);
                _nLogger.Info("成功替换{0}条数据", replaceOneResult.ModifiedCount);
                _nLogger.Debug("替换条件：{0};\n替换数据：{1}", filter.ToJson(), updateBsonDocument.ToJson());
                return replaceOneResult.ModifiedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("替换数据失败;异常信息：{0}", e.Message);
                _nLogger.Debug("替换条件：{0};\n替换数据：{1}", filter.ToJson(), updateBsonDocument.ToJson());
                return -1;
            }
        }
        /// <summary>
        /// 异步替换数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        /// <param name="updateBsonDocument"></param>
        /// <returns></returns>
        public async Task<long> ReplaceOneAsync<T>(FilterDefinition<T> filter, T updateBsonDocument) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var replaceOneResult = await mongoCollection.ReplaceOneAsync(filter, updateBsonDocument);
                _nLogger.Info("成功替换{0}条数据", replaceOneResult.ModifiedCount);
                _nLogger.Debug("替换条件：{0};\n替换数据：{1}", filter.ToJson(), updateBsonDocument.ToJson());
                return replaceOneResult.ModifiedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("替换数据失败;异常信息：{0}", e.Message);
                _nLogger.Debug("替换条件：{0};\n替换数据：{1}", filter.ToJson(), updateBsonDocument.ToJson());
                return -1;
            }
        }
        #endregion
        #region 删除操作
        public long DeleteOne<T>(FilterDefinition<T> filter) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var deleteResult = mongoCollection.DeleteOne(filter);
                _nLogger.Info("成功删除{0}条数据", deleteResult.DeletedCount);
                _nLogger.Debug("删除条件：{0}", filter.ToJson());
                return deleteResult.DeletedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("删除数据失败;异常信息：{0}", e.Message);
                _nLogger.Debug("删除条件：{0}", filter.ToJson());
                return -1;
            }
        }
        public async Task<long> DeleteOneAsync<T>(FilterDefinition<T> filter) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var deleteResult = await mongoCollection.DeleteOneAsync(filter);
                _nLogger.Info("成功删除{0}条数据", deleteResult.DeletedCount);
                _nLogger.Debug("删除条件：{0}", filter.ToJson());
                return deleteResult.DeletedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("删除数据失败;异常信息：{0}", e.Message);
                _nLogger.Debug("删除条件：{0}", filter.ToJson());
                return -1;
            }
        }
        public long DeleteMany<T>(FilterDefinition<T> filter) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var deleteResult = mongoCollection.DeleteMany(filter);
                _nLogger.Info("成功删除{0}条数据", deleteResult.DeletedCount);
                _nLogger.Debug("删除条件：{0}", filter.ToJson());
                return deleteResult.DeletedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("删除数据失败;异常信息：{0}", e.Message);
                _nLogger.Debug("删除条件：{0}", filter.ToJson());
                return -1;
            }
        }
        public async Task<long> DeleteManyAsync<T>(FilterDefinition<T> filter) where T : class
        {
            try
            {
                var mongoCollection = _mongoDatabase.GetCollection<T>(CollectionName<T>());
                var deleteResult = await mongoCollection.DeleteManyAsync(filter);
                _nLogger.Info("成功删除{0}条数据", deleteResult.DeletedCount);
                _nLogger.Debug("删除条件：{0}", filter.ToJson());
                return deleteResult.DeletedCount;
            }
            catch (Exception e)
            {
                _nLogger.Error("删除数据失败;异常信息：{0}", e.Message);
                _nLogger.Debug("删除条件：{0}", filter.ToJson());
                return -1;
            }
        }
        #endregion
    }
}
