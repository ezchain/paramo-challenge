using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Interfaces.Services
{
    public interface IFileReaderService
    {
        IList<string> ReadFromFile(string path);
    }
}
