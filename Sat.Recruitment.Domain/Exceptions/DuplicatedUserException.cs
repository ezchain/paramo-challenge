using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Exceptions
{
    public class DuplicatedUserException : Exception
    {
        public DuplicatedUserException()
        {
        }
        public override string Message => "User is duplicated";
    }
}
