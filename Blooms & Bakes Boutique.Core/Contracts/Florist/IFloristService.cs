namespace Blooms___Bakes_Boutique.Core.Contracts.Florist
{
	public interface IFloristService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<bool> FloristWithFlowerMasterTitleExistsAsync(string flowerMasterTitle);

        Task CreateAsync(string userId, string flowerMasterTitle);

        Task<int?> GetFloristIdAsync(string userId);
	}
}
