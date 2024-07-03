using Microsoft.AspNetCore.Identity;

/// <summary>
/// DTO User Class.
/// </summary>
/// <remarks></remarks>
namespace Dot.Net.WebApi.Domain
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}