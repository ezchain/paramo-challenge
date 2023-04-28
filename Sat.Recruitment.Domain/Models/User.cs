using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Interfaces.Models;

namespace Sat.Recruitment.Domain.Models
{
    public class User : IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserTypeEnum UserType { get; set; }
        public decimal Money { get; set; }
    }
}