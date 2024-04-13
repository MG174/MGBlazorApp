using MGDockerBlazorApp.Database.DatabaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MGDockerBlazorApp.Database
{
    public class MGDatabaseContext : DbContext
    {
        public DbSet<TestTable> TestTable { get; set; }

        public MGDatabaseContext(DbContextOptions<MGDatabaseContext> options)
        : base(options)
        {
        }
    }
}
