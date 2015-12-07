using System.Reflection;
using Abp.Modules;

namespace ContosoUniversity
{
    [DependsOn(typeof(ContosoUniversityCoreModule))]
    public class ContosoUniversityApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
