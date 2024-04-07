using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries.Pastry;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastry
{
    [Comment("Pastry to taste")]
    public class Pastry
    {
        [Key]
        [Comment("Pastry Identifier")]
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

        [Comment("User id of the Taster")]
        public string? TasterId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Comment("Pastry's Category")]
        public PastryCategory PastryCategory { get; set; } = null!;

        [ForeignKey(nameof(PatissierId))]
        [Comment("Patissier")]
        public Patissier Patissier { get; set; } = null!;
    }
}
