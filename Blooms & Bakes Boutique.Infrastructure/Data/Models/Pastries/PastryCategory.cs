using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries.PastryCategory;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries
{
    [Comment("Pastry's Type/Category")]
    public class PastryCategory
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Category Pastries")]
        public IEnumerable<Pastry> Pastries { get; set; } = new List<Pastry>();
    }
}
