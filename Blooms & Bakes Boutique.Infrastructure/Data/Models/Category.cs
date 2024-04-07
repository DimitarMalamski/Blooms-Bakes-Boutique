using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Category;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Models
{
    [Comment("Pastry Type/Category")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Category Pastries")]
        public IEnumerable<Pastry> Pastries { get; init; } = new List<Pastry>();
    }
}
