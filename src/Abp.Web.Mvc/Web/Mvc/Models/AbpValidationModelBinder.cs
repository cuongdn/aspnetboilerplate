using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Abp.Runtime.Validation;

namespace Abp.Web.Mvc.Models
{
    public class AbpValidationModelBinder : DefaultModelBinder
    {
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);

            ForceModelValidation(bindingContext);
        }

        private static void ForceModelValidation(ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelState.IsValid) return;

            // Only run this code for an ICustomValidate model
            var model = bindingContext.Model as ICustomValidate;
            if (model == null)
            {
                // Nothing to do
                return;
            }

            // Get the model state
            var modelState = bindingContext.ModelState;

            // Get custom errors
            var errors = new List<ValidationResult>();
            model.AddValidationErrors(errors);

            // Define the keys and values of the model state
            var modelStateKeys = modelState.Keys.ToList();
            var modelStateValues = modelState.Values.ToList();

            foreach (var error in errors)
            {
                // Account for errors that are not specific to a member name
                var errorMemberNames = error.MemberNames.ToList();
                if (errorMemberNames.Count == 0)
                {
                    // Add empty string for errors that are not specific to a member name
                    errorMemberNames.Add(string.Empty);
                }

                foreach (var memberName in errorMemberNames)
                {
                    // Only add errors that haven't already been added.
                    // (This can happen if the model's Validate(...) method is called more than once, which will happen when there are no property-level validation failures)
                    var index = modelStateKeys.IndexOf(memberName);

                    // Try and find an already existing error in the model state
                    if (index == -1 || modelStateValues[index].Errors.All(i => i.ErrorMessage != error.ErrorMessage))
                    {
                        // Add error
                        modelState.AddModelError(memberName, error.ErrorMessage);
                    }
                }
            }
        }
    }
}