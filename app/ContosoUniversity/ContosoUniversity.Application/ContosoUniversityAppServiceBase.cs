using Abp.Application.Services;

namespace ContosoUniversity
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ContosoUniversityAppServiceBase : ApplicationService
    {
        protected ContosoUniversityAppServiceBase()
        {
            LocalizationSourceName = ContosoUniversityConsts.LocalizationSourceName;
        }
    }
}