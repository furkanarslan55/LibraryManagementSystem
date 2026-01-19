using LibraryProject.DataAccess.Abstract;
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
         where TEntity : class
         where TContext : DbContext
    {
        protected readonly TContext _context;

        // BURASI DEĞİŞTİ: Context'i new ile oluşturmuyoruz, istiyoruz.
        public EfGenericRepository(TContext context)
        {
            _context = context;
        }
        // Kodları buraya yazacağız.
        // using kullanımı: Context nesnesini işi bitince bellekten atar (Garbage Collector'ı beklemez).
        // Bu performans için kritiktir.

        public void Add(TEntity entity)
        {
            
            
                var addedEntity = _context.Entry(entity); // Veriyi yakala
                addedEntity.State = EntityState.Added;   // Durumunu "Eklenecek" yap
                _context.SaveChanges();                   // Veritabanına işle
            
        }

        public void Delete(TEntity entity)
        {
            
            
                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            
        }

        public void Update(TEntity entity)
        {
            
            
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
            
        }

        public TEntity GetById(int id)
        {
           
            
                // Set<TEntity>(): Generic olarak tablolara erişmemizi sağlar.
                // Eğer TEntity Book ise, context.Books'a gider.
                return _context.Set<TEntity>().Find(id);
            
        }

        public List<TEntity> GetAll()
        {
           
            
                return _context.Set<TEntity>().ToList();
            
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
           
            
                // Filtre varsa uygula, yoksa hepsini getir.
                return filter == null
                    ? _context.Set<TEntity>().ToList()
                    : _context.Set<TEntity>().Where(filter).ToList();
            
        }
    }
}
