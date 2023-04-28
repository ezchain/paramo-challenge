using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Extension
{
    public static class ListExtension
    {
        public static string GetValues(this IEnumerable<string> list)
        {
          return string.Join(" ", list);
        }
    }
}
