using Gym.Notes.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym.Notes.Infrastructure
{
    public class DbContext : IdentityDbContext
    {
        private int _maxKeyLength = 25;

        public DbSet<SubscriberModel> Subscribers { get; set; }
        public DbSet<GroupsOfExercisesModel> GroupsOfExercises { get; set; }
        public DbSet<DietModel> Diets { get; set; }
        public DbSet<WeightModel> Weights { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public DbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureIdentity(builder);

            builder.Entity<SubscriberModel>(s =>
            {
                s.HasKey(x => x.Id);
                s.Property(x => x.Email)
                    .IsRequired();
            });

            builder.Entity<GroupsOfExercisesModel>(s =>
            {
                s.HasKey(x => x.Id);
                s.Property(x => x.UserId)
                    .IsRequired();
                s.Property(x => x.DayOfWeek)
                    .IsRequired();
                s.Property(x => x.GroupOfExercise)
                    .IsRequired();
            });

            builder.Entity<DietModel>(s =>
            {
                s.HasKey(x => x.Id);
                s.Property(x => x.UserId)
                    .IsRequired();
                s.Property(x => x.Date)
                    .IsRequired();
                s.Property(x => x.Kcals)
                    .IsRequired();
            });

            builder.Entity<WeightModel>(s =>
            {
                s.HasKey(x => x.Id);
                s.Property(x => x.UserId)
                    .IsRequired();
                s.Property(x => x.Date)
                    .IsRequired();
                s.Property(x => x.Weight)
                    .IsRequired();
            });

            builder.Entity<TaskModel>(s =>
            {
                s.HasKey(x => x.Id);
                s.Property(x => x.UserId)
                    .IsRequired();
                s.Property(x => x.Date)
                    .IsRequired();
                s.Property(x => x.Title)
                    .IsRequired();
                s.Property(x => x.Content);
                s.Property(x => x.Done)
                    .HasDefaultValue(false)
                    .IsRequired();
            });
        }

        private void ConfigureIdentity(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);

                // Indexes for "normalized" username and email, to allow efficient lookups
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

                // Maps to the IdentityUsers table
                b.ToTable("IdentityUsers");

                // A concurrency token for use with the optimistic concurrency checking
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                // The relationships between User and other entity types
                // Note that these relationships are configured with no navigation properties

                // Each User can have many UserClaims
                b.HasMany<IdentityUserClaim<string>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

                // Each User can have many UserLogins
                b.HasMany<IdentityUserLogin<string>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

                // Each User can have many UserTokens
                b.HasMany<IdentityUserToken<string>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                // Primary key
                b.HasKey(uc => uc.Id);

                // Maps to the IdentityUserClaims table
                b.ToTable("IdentityUserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                // Composite primary key consisting of the LoginProvider and the key to use
                // with that provider
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

                // Limit the size of the composite key columns due to common DB restrictions
                b.Property(l => l.LoginProvider).HasMaxLength(128);
                b.Property(l => l.ProviderKey).HasMaxLength(128);

                // Maps to the IdentityUserLogins table
                b.ToTable("IdentityUserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                // Composite primary key consisting of the UserId, LoginProvider and Name
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

                // Limit the size of the composite key columns due to common DB restrictions
                b.Property(t => t.LoginProvider).HasMaxLength(_maxKeyLength);
                b.Property(t => t.Name).HasMaxLength(_maxKeyLength);

                // Maps to the IdentityUserTokens table
                b.ToTable("IdentityUserTokens");
            });

            builder.Entity<IdentityRole>(b =>
            {
                // Primary key
                b.HasKey(r => r.Id);

                // Index for "normalized" role name to allow efficient lookups
                b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

                // Maps to the tRoles table
                b.ToTable("tRoles");

                // A concurrency token for use with the optimistic concurrency checking
                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);

                // The relationships between Role and other entity types
                // Note that these relationships are configured with no navigation properties

                // Each Role can have many entries in the UserRole join table
                b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany<IdentityRoleClaim<string>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                // Primary key
                b.HasKey(rc => rc.Id);

                // Maps to the tRoleClaims table
                b.ToTable("tRoleClaims");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                // Primary key
                b.HasKey(r => new { r.UserId, r.RoleId });

                // Maps to the IdentityUserRoles table
                b.ToTable("IdentityUserRoles");
            });
        }
    }
}
