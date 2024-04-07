using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers
{
    [Comment("Flowers to pick")]
    public class Flower
    {
        [Key]
        [Comment("Flower Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Pastry Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Pastry Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(RecipeMaxLength)]
        [Comment("Pastry Recipe")]
        public string Recipe { get; set; } = string.Empty;

        [Required]
        [Comment("Pastry Image")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Pastry Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Category Identifier")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("Patissier Identifier")]
        public int PatissierId { get; set; }

        [Comment("User id of the Liker")]
        public string? LikerId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Comment("Category")]
        public PastryCategory PastryCategory { get; set; } = null!;

        [ForeignKey(nameof(PatissierId))]
        [Comment("Patissier")]
        public Patissier Patissier { get; set; } = null!;
    }
}
