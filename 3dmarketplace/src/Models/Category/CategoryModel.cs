
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3dmarketplace.src.Models.Category
{


    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

        public ICollection<Product>? Products { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Products: {Products?.Count}";
        }

    }

}