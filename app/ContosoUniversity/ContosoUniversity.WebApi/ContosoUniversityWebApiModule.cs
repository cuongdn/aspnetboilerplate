using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace ContosoUniversity
{
    [DependsOn(typeof(AbpWebApiModule), typeof(ContosoUniversityApplicationModule))]
    public class ContosoUniversityWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ContosoUniversityApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
