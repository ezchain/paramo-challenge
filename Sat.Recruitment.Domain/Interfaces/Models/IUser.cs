using Sat.Recruitment.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Interfaces.Models
{
    public interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        UserTypeEnum UserType { get; set; }
        decimal Money { get; set; }
    }
}
