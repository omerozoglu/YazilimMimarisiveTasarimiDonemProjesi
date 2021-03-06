using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Common;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories {
    public class MongoDBRepositoryBase<T> : IAsyncRepository<T> where T : EntityBase {
        protected readonly IMongoContext<T> _context;

        public MongoDBRepositoryBase (IMongoContext<T> context) {
            _context = context;
        }
        public async Task<T> GetOneAsync (Expression<Func<T, bool>> predicate) {
            return await _context.Collection.Find (predicate).FirstOrDefaultAsync ();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync () {
            return await _context.Collection.Find (x => true).ToListAsync ();
        }

        public async Task<IReadOnlyList<T>> GetAsync (Expression<Func<T, bool>> predicate) {
            return await _context.Collection.Find (predicate).ToListAsync ();
        }

        public async Task<T> AddAsync (T entity) {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            entity.CreatedDate = DateTime.UtcNow;
            await _context.Collection.InsertOneAsync (entity, options);
            return entity;
        }

        public async Task<T> UpdateAsync (T entity) {
            entity.LastModifiedDate = DateTime.UtcNow;
            await _context.Collection.FindOneAndReplaceAsync (x => x.Id == entity.Id, entity);
            return entity;
        }
        public async Task<T> DeleteAsync (T entity) {
            await _context.Collection.FindOneAndDeleteAsync (x => x.Id == entity.Id);
            return entity;
        }

    }
}