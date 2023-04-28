using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Extension
{
    public static class StringExtension
    {
        public static string FormatEmail(this string email)
        {
            if(String.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("Email");

            if (!Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                throw new ArgumentException("The Email field is not a valid e-mail address.");

            var splitedString = email.Split('@');
            var firstPart = splitedString[0].Replace(".", "").Split('+')[0];
            return  firstPart + "@" + splitedString[1];
        }

        public static UserTypeEnum GetUserType(this string type) => type?.ToUpper() switch
        {
            "NORMAL" => UserTypeEnum.NORMAL,
            "SUPERUSER" => UserTypeEnum.SUPER_USER,
            "PREMIUM" => UserTypeEnum.PREMIUM,
            _ => UserTypeEnum.NORMAL
        };
    }
}
