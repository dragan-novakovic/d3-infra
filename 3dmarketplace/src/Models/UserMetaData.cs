using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace _3dmarketplace.src.Models
{

    [Table("UserMetaData")]
    public class UserMetadata : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Product>? Products { get; set; }

    }

}