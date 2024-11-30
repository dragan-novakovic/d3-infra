
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3dmarketplace.src.Models
{


    [Table("Reviews")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required]
        public string? Description { get; set; }
        [ForeignKey("UserId")]
        public required string UserId { get; set; }

        [ForeignKey("ProductId")]
        public required int ProductId { get; set; }

        public required Product Product { get; set; }
    }

}