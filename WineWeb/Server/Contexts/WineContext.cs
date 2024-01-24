using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Contexts
{
    public partial class WineContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public WineContext(DbContextOptions<WineContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = _dateTime.Now;
                        entry.Entity.CreateBy = _authenticatedUser.UserId;

                        entry.Entity.UpdateDate = _dateTime.Now;
                        entry.Entity.UpdateBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateDate = _dateTime.Now;
                        entry.Entity.UpdateBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new LocationConfiguration());
            //modelBuilder.ApplyConfiguration(new ArticleBarcodeConfiguration());
        }
    }
}
