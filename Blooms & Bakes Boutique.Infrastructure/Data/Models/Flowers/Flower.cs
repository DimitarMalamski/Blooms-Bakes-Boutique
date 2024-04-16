using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Flowers.Flower;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.User;

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
        [Comment("Flower Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Flower Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(ColourMaxLength)]
        [Comment("Flower Colour")]
        public string Colour { get; set; } = string.Empty;

        [Required]
        [Comment("Flower Image")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Price Per Bouquet")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerBouquet { get; set; }

        [Required]
        [Comment("Category Identifier")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("Florist Identifier")]
        public int FloristId { get; set; }

        [Comment("User id of the Gatherer")]
        public string? GathererId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Comment("Flower's Category")]
        public FlowerCategory FlowerCategory { get; set; } = null!;

        [ForeignKey(nameof(FloristId))]
        [Comment("Florist")]
        public Florist Florist { get; set; } = null!;

		[ForeignKey(nameof(GathererId))]
		public ApplicationUser? Gatherer { get; set; }
	}
}
