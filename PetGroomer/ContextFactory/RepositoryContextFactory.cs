using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace PetGroomer.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            var connectionString = configuration.GetConnectionString("sqlConnection");

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseMySql(connectionString, serverVersion, b => b.MigrationsAssembly("PetGroomer"));

            return new RepositoryContext(builder.Options);
        }
    }
}

