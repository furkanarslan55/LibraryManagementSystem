using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {// (Dependency Injection)
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public AuditInterceptor(IAuthenticatedUserService authenticatedUserService)
        {
            _authenticatedUserService = authenticatedUserService;
        }
        // SaveChangesAsync çağrıldığında BU metot çalışır.
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
             DbContextEventData eventData,
             InterceptionResult<int> result,
             CancellationToken cancellationToken = default)
        {
            var dbContext = eventData.Context;
            if (dbContext == null) return base.SavingChangesAsync(eventData, result, cancellationToken);

            // 2. O anki kullanıcının ID'sini al
            var currentUserId = _authenticatedUserService.UserId;

            var entries = dbContext.ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;

                   
                    entry.Entity.CreatedBy = currentUserId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;

                 
                    entry.Entity.UpdatedBy = currentUserId;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
