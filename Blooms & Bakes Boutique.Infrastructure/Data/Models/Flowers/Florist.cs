﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Flowers.Florsit;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.User;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers
{
    [Index(nameof(FlowerMasterTitle), IsUnique = true)]
    [Comment("Flower's Florist")]
    public class Florist
    {
        [Key]
        [Comment("Florist Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(FlowerMasterMaxLength)]
        [Comment("Florist FlowerMaster Title")]
        public string FlowerMasterTitle { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [Comment("User")]
        public ApplicationUser User { get; set; } = null!;
    }
}
