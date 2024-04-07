using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Flowers.FlowerCategory;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers
{
    [Comment("Flower's Type/Category")]
    public class FlowerCategory
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Category Flowers")]
        public IEnumerable<Flower> Flowers { get; set; } = new List<Flower>();
    }
}
