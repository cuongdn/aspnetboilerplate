using System;
using System.Web.Mvc;

namespace Abp.Web.Mvc.Models
{
    public class AbpValidationModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            return new AbpValidationModelBinder();
        }
    }
}
