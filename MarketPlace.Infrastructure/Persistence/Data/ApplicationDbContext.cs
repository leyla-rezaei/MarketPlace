using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Infrastructure.Extensions;
using MarketPlace.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Persistence.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(IBaseEntity).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);
        modelBuilder.AddRestrictDeleteBehaviorConvention();
        modelBuilder.AddGolobalFilter(entitiesAssembly);
        modelBuilder.AddPluralizingTableNameConvention();
        modelBuilder.AddSequentialGuidForIdConvention();
        modelBuilder.ApplyConfigurationsFromAssembly(entitiesAssembly);
        ConfigIdentityTables(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreationDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModificationDate = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.Entity.IsArchived = true;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreationDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModificationDate = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.Entity.IsArchived = true;
                    break;
            }
        }
        return base.SaveChanges();
    }

    private void ConfigIdentityTables(ModelBuilder builder)
    {
        //Config Asp Identity table name
        builder.Entity<User>().ToTable("Users");
        builder.Entity<Role>().ToTable("Roles");
        builder.Entity<UserRole>().ToTable("UserRoles");
        builder.Entity<UserLogin>().ToTable("UserLogins");
        builder.Entity<UserToken>().ToTable("UserTokens");


        builder.Entity<UserClaim>(b =>
        {
            // Primary key
            b.HasKey(uc => uc.Id);
            b.Property(uc => uc.Id).HasColumnType("uniqueidentifier");

            // Maps to the AspNetUserClaims table
            b.ToTable("UserClaims");
        });

        builder.Entity<RoleClaim>(b =>
        {
            // Primary key
            b.HasKey(rc => rc.Id);
            b.Property(rc => rc.Id).HasColumnType("uniqueidentifier");

            // Maps to the AspNetRoleClaims table
            b.ToTable("RoleClaims");
        });
    }
}