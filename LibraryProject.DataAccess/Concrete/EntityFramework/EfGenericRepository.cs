using LibraryProject.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.DataAccess.Abstract;

namespace LibraryProject.DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
         where TEntity : class
         where TContext : DbContext
    {
        protected readonly TContext _context;

        // BURASI DEĞİŞTİ: Context'i new ile oluşturmuyoruz, istiyoruz.
        public EfGenericRepository(TContext context)
        {
            _context = context;
        }


        public async Task AddAsync(TEntity entity)
        {
            // AddAsync: EF Core'un asenkron ekleme metodu
            await _context.Set<TEntity>().AddAsync(entity);
            // SaveChangesAsync: Asıl sihir burası. Veritabanı yazarken thread serbest kalır.
            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            // Delete işlemi hafızada olduğu için async gerekmez ama SaveChanges ASYNC olmalı.
            // Ancak generic yapıda dönüş tipini void bıraktığımız için burada SaveChanges senkron kalabilir 
            // VEYA UnitOfWork deseninde tek seferde kaydederiz.
            // ŞİMDİLİK BASİT TUTUYORUZ:
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
          
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
           
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
