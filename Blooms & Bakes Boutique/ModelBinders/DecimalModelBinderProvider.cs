using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blooms___Bakes_Boutique.ModelBinders
{
	public class DecimalModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder GetBinder(ModelBinderProviderContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			if (context.Metadata.ModelType == typeof(decimal))
			{
				return new DecimalModelBinder();
			}

			return null;
		}
	}
}
