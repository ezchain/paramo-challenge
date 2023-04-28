using Sat.Recruitment.Domain.Interfaces.Services;

namespace Sat.Recruitment.Infrastructure
{
    public class FileReaderService : IFileReaderService
    {
        public IList<string> ReadFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines.ToList();
        }
    }
}