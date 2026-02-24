using Microsoft.AspNetCore.Identity;

namespace APIWorkTest.PresentationLayer.Models
{
    public class ApplicationUser :IdentityUser
    {

        public String FullName { get; set; } = string.Empty;
        public int Address  { get; set; }
    }
}
