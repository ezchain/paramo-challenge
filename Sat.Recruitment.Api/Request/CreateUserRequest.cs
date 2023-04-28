using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Interfaces.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sat.Recruitment.Api.Request
{
    public class CreateUserRequest : BaseRequest, IUser 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public UserTypeEnum UserType { get; set; }
        public decimal Money { get; set; }

    }
}
