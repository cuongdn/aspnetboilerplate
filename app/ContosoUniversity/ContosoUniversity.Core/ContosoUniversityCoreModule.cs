using System.Reflection;
using Abp.Modules;

namespace ContosoUniversity
{
    public class ContosoUniversityCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
