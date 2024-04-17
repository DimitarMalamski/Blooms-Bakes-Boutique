using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Blooms___Bakes_Boutique.ModelBinders
{
	public class DecimalModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

			if (valueProviderResult == null)
			{
				return Task.CompletedTask;
			}

			var value = valueProviderResult.FirstValue;

			if (string.IsNullOrEmpty(value))
			{
				return Task.CompletedTask;
			}

			// Remove unnecessary commas and spaces
			value = value.Replace(",", string.Empty).Trim();

			decimal myValue = 0;
			try
			{
				myValue = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
				bindingContext.Result = ModelBindingResult.Success(myValue);
				return Task.CompletedTask;
			}
			catch (Exception m)
			{
				return Task.CompletedTask;
			}

		}
	}
}
