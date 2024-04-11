namespace Blooms___Bakes_Boutique.Core.Contracts.Patissier
{
	public interface IPatissierService
    {
		Task<bool> ExistById(string userId);

		Task<bool> UserWithMasterChefTitleExists(string masterChefTitle);

		Task<bool> UserHasLikedPatries(string userId);

		Task Create(string userId, string masterChefTitle);
	}
}
