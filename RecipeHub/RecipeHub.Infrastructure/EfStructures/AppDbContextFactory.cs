using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace RecipeHub.Infrastructure.EfStructures
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=tcp:ne-sqlserver-intern.database.windows.net,1433;Initial Catalog=ne-sqldb-internt;Persist Security Info=False;User ID=admin123;Password={pass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new AppDbContext(optionsBuilder.Options);
        }

       
    }
}
