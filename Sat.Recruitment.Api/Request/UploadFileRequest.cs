using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Request
{
    public class UploadFileRequest : BaseRequest
    {
        [Required]
        public string Path { get; set; }
    }
}
