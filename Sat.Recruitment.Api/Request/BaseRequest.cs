using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sat.Recruitment.Domain.Exceptions;
using System.Linq;

namespace Sat.Recruitment.Api.Request
{
    public class BaseRequest
    {

        public virtual void IsValid(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(e => e.Errors).Select(e=>e.ErrorMessage);
                throw new RequiredFieldException(errors);

            }
        }


    }
}
