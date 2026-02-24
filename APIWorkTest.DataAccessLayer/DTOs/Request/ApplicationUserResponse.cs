using System.ComponentModel.DataAnnotations;

namespace APIWorkTest.PresentationLayer.DTOs.Request
{
    public class ApplicationUserResponse
    {
        public string ApplicationUserId { get; set; }
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        
    }
}
