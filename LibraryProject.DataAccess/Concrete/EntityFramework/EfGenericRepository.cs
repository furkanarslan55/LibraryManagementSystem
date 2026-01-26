using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Abstract;
using LibraryProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
         where TEntity : BaseEntity, new()
         where TContext : DbContext
    {
        protected readonly TContext _context;

        // BURASI DEĞİŞTİ: Context'i new ile oluşturmuyoruz, istiyoruz.
        public EfGenericRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            // FirstOrDefaultAsync: Filtreye uyan ilk kaydı bul, yoksa null dön.
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task AddAsync(TEntity entity)
        {
            // AddAsync: EF Core'un asenkron ekleme metodu
            await _context.Set<TEntity>().AddAsync(entity);
            // SaveChangesAsync: Asıl sihir burası. Veritabanı yazarken thread serbest kalır.
            await _context.SaveChangesAsync();
        }

        public void  Delete(TEntity entity)
        {

            entity.IsDeleted = true;


            _context.Set<TEntity>().Update(entity);

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
        public async Task<List<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize)
        {
            // 1. Önce Veritabanı sorgusunu hazırla (Henüz çalıştırma!)
            var query = _context.Set<TEntity>().AsQueryable();

            // 2. Filtre varsa ekle
            if (filter != null)
            {
                query = query.Where(filter);
            }

           
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(); 
        }
        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                // Filtre yoksa tüm tabloyu say (SELECT COUNT(*) FROM Books)
                return await _context.Set<TEntity>().CountAsync();
            }
            else
            {
                // Filtre varsa ona göre say (SELECT COUNT(*) FROM Books WHERE CategoryId=1)
                return await _context.Set<TEntity>().CountAsync(filter);
            }
        }
    }
}
