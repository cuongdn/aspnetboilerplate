using System.Data.Entity;
using Abp.EntityFramework;
using ContosoUniversity.Entities;
using ContosoUniversity.Students;

namespace ContosoUniversity.EntityFramework
{
    public class ContosoUniversityDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...
        public virtual IDbSet<Student> Students { get; set; }

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ContosoUniversityDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ContosoUniversityDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ContosoUniversityDbContext since ABP automatically handles it.
         */
        public ContosoUniversityDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
              .Map<Student>(m => m.Requires("Discriminator").HasValue("Student"));
            //                .Map<CreditCard>(m => m.Requires("BillingDetailType").HasValue("CC"));
            base.OnModelCreating(modelBuilder);
          
        }
    }
}
