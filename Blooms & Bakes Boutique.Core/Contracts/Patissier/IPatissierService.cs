namespace Blooms___Bakes_Boutique.Core.Contracts.Patissier
{
	public interface IPatissierService
    {
		Task<bool> ExistByIdAsync(string userId);

		Task<bool> UserWithMasterChefTitleExistsAsync(string masterChefTitle);

		Task<bool> UserHasLikedPatriesAsync(string userId);

		Task CreateAsync(string userId, string masterChefTitle);
	}
}
