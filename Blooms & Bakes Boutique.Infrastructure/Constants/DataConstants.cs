using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Infrastructure.Constants
{
    public static class DataConstants
    {
        // Pastry data constants class
        public class Pastry
        {
            // IndividualPastry data constants class
            public class IndividualPastry
            {
                // IndividualPastry title length requirements 
                public const int TitleMinLength = 5;
                public const int TitleMaxLength = 100;

                // IndividualPastry description length requirements
                public const int DescriptionMinLength = 20;
                public const int DescriptionMaxLength = 300;

                // IndividualPastry recipe length requirements
                public const int RecipeMinLength = 10;
                public const int RecipeMaxLength = 1000;

                // IndividualPastry price length requirements
                public const string PriceMinLength = "0";
                public const string PriceMaxLength = "200";

            }

            // Category data constants class
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
        
        public class Flowers
        {
            // IndividualPastry data constants class
            public class IndividualPastry
            {
                // IndividualPastry title length requirements 
                public const int TitleMinLength = 5;
                public const int TitleMaxLength = 100;

                // IndividualPastry description length requirements
                public const int DescriptionMinLength = 20;
                public const int DescriptionMaxLength = 300;

                // IndividualPastry recipe length requirements
                public const int RecipeMinLength = 10;
                public const int RecipeMaxLength = 1000;

                // IndividualPastry price length requirements
                public const string PriceMinLength = "0";
                public const string PriceMaxLength = "200";

            }

            // Category data constants class
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
    }
}
