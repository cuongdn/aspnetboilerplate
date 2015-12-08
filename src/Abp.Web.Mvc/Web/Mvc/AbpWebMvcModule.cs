using System.Reflection;
using System.Web.Mvc;
using Abp.Modules;
using Abp.Web.Mvc.Controllers;
using Abp.Web.Mvc.Models;

namespace Abp.Web.Mvc
{
    /// <summary>
    /// This module is used to build ASP.NET MVC web sites using Abp.
    /// </summary>
    [DependsOn(typeof(AbpWebModule))]
    public class AbpWebMvcModule : AbpModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            ModelBinderProviders.BinderProviders.Clear();
            ModelBinderProviders.BinderProviders.Add(new AbpValidationModelBinderProvider());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IocManager.IocContainer.Kernel));
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpHandleErrorAttribute>());
        }
    }
}
