namespace Blooms___Bakes_Boutique.Core.Contracts.Patissier
{
	public interface IPatissierService
    {
		Task<bool> ExistByIdAsync(string userId);

		Task<bool> PatissierWithMasterChefTitleExistsAsync(string masterChefTitle);

		Task CreateAsync(string userId, string masterChefTitle);

		Task<int?> GetPatissierIdAsync(string userId);
	}
}
