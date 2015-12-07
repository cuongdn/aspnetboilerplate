using Abp.Web.Mvc.Controllers;

namespace ContosoUniversity.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class ContosoUniversityControllerBase : AbpController
    {
        protected ContosoUniversityControllerBase()
        {
            LocalizationSourceName = ContosoUniversityConsts.LocalizationSourceName;
        }
    }
}