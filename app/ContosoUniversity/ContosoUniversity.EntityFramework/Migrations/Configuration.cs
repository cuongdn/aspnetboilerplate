using System.Data.Entity.Migrations;

namespace ContosoUniversity.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.EntityFramework.ContosoUniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ContosoUniversity";
        }

        protected override void Seed(ContosoUniversity.EntityFramework.ContosoUniversityDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
