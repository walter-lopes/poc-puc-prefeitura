using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.SupportCitizens.Repositories
{
    public class BaseRepository<T>
    {
        protected IDbContext DbContext { get; set; }

        protected IMongoCollection<T> Collection { get; set; }

        public BaseRepository(IDbContext context, string collection)
        {
            this.DbContext = context;
            this.Collection = context.Context.GetCollection<T>(collection);
        }

        public async Task InsertAsync(T obj) => await this.Collection.InsertOneAsync(obj);

        public async Task InsertManyAsync(IEnumerable<T> objs) => await this.Collection.InsertManyAsync(objs);

        public async Task UpdateAsync(T obj, Expression<Func<T, bool>> func) => await this.Collection.FindOneAndReplaceAsync(func, obj);

        public async Task DeleteAsync(Expression<Func<T, bool>> func) => await this.Collection.DeleteOneAsync(func);

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> func)
        {
            var filter = Builders<T>.Filter.And(
                Builders<T>.Filter.Where(func)
            );

            var obj = await this.Collection.FindAsync(filter);

            return obj.FirstOrDefault();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> func)
        {
            var filter = Builders<T>.Filter.And(
                Builders<T>.Filter.Where(func)
            );

            var obj = await this.Collection.FindAsync(filter);

            return await obj.AnyAsync();
        }

        public async Task<IEnumerable<T>> GetByIdsAsync(Expression<Func<T, Guid>> func, IEnumerable<Guid> ids)
        {
            var filter = Builders<T>.Filter.And(
                Builders<T>.Filter.In(func, ids)
            );

            var obj = await this.Collection.FindAsync(filter);

            return obj.ToList();
        }

        public async Task<IEnumerable<T>> GetByIdsAsync(Expression<Func<T, string>> func, IEnumerable<string> ids)
        {
            var filter = Builders<T>.Filter.And(
                Builders<T>.Filter.In(func, ids)
            );

            var obj = await this.Collection.FindAsync(filter);
            return obj?.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await this.Collection.FindAsync(FilterDefinition<T>.Empty);

            if (result is null) return new List<T>();

            return result.ToList();
        }

        public async Task UpdateManyAsync(IEnumerable<T> objs)
        {
            var updates = new List<WriteModel<T>>();
            var filterBuilder = Builders<T>.Filter;

            foreach (var doc in objs)
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (prop.Name == "Id")
                    {
                        var filter = filterBuilder.Eq(prop.Name, prop.GetValue(doc));
                        updates.Add(new ReplaceOneModel<T>(filter, doc));
                        break;
                    }
                }
            }

            await this.Collection.BulkWriteAsync(updates);
        }
    }

    public interface IDbContext
    {
        IMongoDatabase Context { get; }
    }
}
}
