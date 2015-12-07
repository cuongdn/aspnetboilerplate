using Abp.Web.Mvc.Views;

namespace ContosoUniversity.Web.Views
{
    public abstract class ContosoUniversityWebViewPageBase : ContosoUniversityWebViewPageBase<dynamic>
    {

    }

    public abstract class ContosoUniversityWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ContosoUniversityWebViewPageBase()
        {
            LocalizationSourceName = ContosoUniversityConsts.LocalizationSourceName;
        }
    }
}