namespace Blooms___Bakes_Boutique.Core.Contracts.Florist
{
	public interface IFloristService
    {
        Task<bool> ExistById(string userId);

        Task<bool> UserWithFlowerMasterTitleExists(string flowerMasterTitle);

        Task<bool> UserHasGatheredFlowers(string userId);

        Task Create(string userId, string flowerMasterTitle);
	}
}
