using Sat.Recruitment.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IUser Create(IUser request);
        void Create(string path);
    }
}
