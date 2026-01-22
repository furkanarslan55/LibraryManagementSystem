using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllPagedAsync(Expression<Func<T, bool>> filter, int pageNumber, int pageSize);
        Task AddAsync(T entity);
        //Ef CORE DA update ve delete metotları senkron çalışır..Hafızada değişiklik yapar ve savechanges ile veritabanına yazarız.
        void Update(T entity);
        void Delete(T entity);

    }
}
