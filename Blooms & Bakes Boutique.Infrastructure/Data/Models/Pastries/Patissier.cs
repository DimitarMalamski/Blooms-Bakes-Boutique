using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries.Patissier;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastry
{
    [Comment("Pastry's Patissier/Chef")]
    public class Patissier
    {
        [Key]
        [Comment("Patissier Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MasterChefMaxLength)]
        [Comment("Patissier MasterChef Title")]
        public string MasterChefTitle { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [Comment("User")]
        public IdentityUser User { get; set; } = null!;
    }
}
