using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Contracts {
    public interface IAsyncRepository<T> where T : EntityBase {

        //* T, EntityBaseden kalıtım almak şartı ile Generic Veritabanı işlemleri
        Task<IReadOnlyList<T>> GetAllAsync ();
        Task<IReadOnlyList<T>> GetAsync (Expression<Func<T, bool>> predicate);
        Task<T> GetOneAsync (Expression<Func<T, bool>> predicate);
        Task<T> AddAsync (T entity);
        Task<T> UpdateAsync (T entity);
        Task<T> DeleteAsync (T entity);
    }
}