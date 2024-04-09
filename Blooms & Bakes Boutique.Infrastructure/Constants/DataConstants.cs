using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Infrastructure.Constants
{
    public static class DataConstants
    {
        // Pastries data constants class
        public class Pastries
        {
            // Pastry data constants class
            public class Pastry
            {
                // Pastry title length requirements 
                public const int TitleMinLength = 5;
                public const int TitleMaxLength = 100;

                // Pastry description length requirements
                public const int DescriptionMinLength = 20;
                public const int DescriptionMaxLength = 500;

                // Pastry recipe length requirements
                public const int RecipeMinLength = 10;
                public const int RecipeMaxLength = int.MaxValue;

                // Pastry price length requirements
                public const string PriceMinLength = "0";
                public const string PriceMaxLength = "200";

            }

            // Pastry Category data constants class
            public class PastryCategory
            {
                // Pastry Category name max length  
                public const int NameMaxLength = 40;
            }

            // Patissier data constants class
            public class Patissier
            {
                // Patissier MasterChef Title length requirements 
                public const int MasterChefMinLength = 5;
                public const int MasterChefMaxLength = 30;
            }
        }
        
        // Flowers data constants class
        public class Flowers
        {
            // Flowers data constants class
            public class Flower
            {
                // Flower title length requirements 
                public const int TitleMinLength = 10;
                public const int TitleMaxLength = 60;

                // Flower description length requirements
                public const int DescriptionMinLength = 20;
                public const int DescriptionMaxLength = 500;

                // Flower recipe length requirements
                public const int ColourMinLength = 3;
                public const int ColourMaxLength = 20;

                // Flower price length requirements
                public const string PricePerBouquetMinLength = "0";
                public const string PricePerBouquetMaxLength = "1000";

            }

            // Flower Category data constants class
            public class FlowerCategory
            {
                // Flower Category name max length  
                public const int NameMaxLength = 40;
            }

            // Florist data constants class
            public class Florsit
            {
                // Patissier FlowerMaster Title length requirements 
                public const int FlowerMasterMinLength = 5;
                public const int FlowerMasterMaxLength = 30;
            }
        }
    }
}
