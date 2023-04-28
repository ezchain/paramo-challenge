using Sat.Recruitment.Domain.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Exceptions
{
    public class RequiredFieldException : Exception
    {
        public IEnumerable<string> Errors { get; set; }
        public RequiredFieldException(IEnumerable<string> errors) {
        Errors = errors;
        }

        public override string Message => Errors.GetValues();
    }
}
