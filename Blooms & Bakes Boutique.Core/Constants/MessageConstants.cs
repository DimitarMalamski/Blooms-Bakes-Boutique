namespace Blooms___Bakes_Boutique.Core.Constants
{
	public static class MessageConstants
	{
		public const string RequiredMessage = "The {0} field is required!";

		public const string LengthMessage = "The field {0} must be between {2} and {1} characters long!";

		public const string RegexErrorMessage = "The field {0} must contain at least one capital letter!";

		public const string FlowerMasterTitleExists = "FlowerMaster title already exists! Enter another one.";

		public const string HasGathered = "You should have no gathered flowers to become a florist!";

		public const string MasterChefTitleExists = "MasterChef title already exists! Enter another one.";

		public const string HasTasted = "You should have no tasted pastries to become a patissier!";

		public const string PriceErrorMessage = "Price Of Pastry must be a positive number and less than {2} leva!";

		public const string FlowerCategoryDoesNotExist = "Flower Category does not exist!";

		public const string PastryCategoryDoesNotExist = "Pastry Category does not exist!";

		public const string UnauthorizedActionExceptionTaster = "The user is mot the taster of the pastry!";

		public const string UnauthorizedActionExceptionGatherer = "The user is mot the gatherer of the flower!";
	}
}
