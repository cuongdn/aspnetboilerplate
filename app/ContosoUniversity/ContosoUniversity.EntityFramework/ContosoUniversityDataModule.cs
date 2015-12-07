using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using ContosoUniversity.EntityFramework;

namespace ContosoUniversity
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(ContosoUniversityCoreModule))]
    public class ContosoUniversityDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<ContosoUniversityDbContext>(null);
        }
    }
}
