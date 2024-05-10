using MGDockerBlazorApp.Database.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MGDockerBlazorApp.Database
{
    public class MGDatabaseContext : IdentityDbContext
    {
        public DbSet<TestTable> TestTable { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public MGDatabaseContext(DbContextOptions<MGDatabaseContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "admin",
                    LastName = "admin",
                    PasswordHash = hasher.HashPassword(null, "3P7PTIuEkhpkiSmmACzr")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
        }
    }
}
