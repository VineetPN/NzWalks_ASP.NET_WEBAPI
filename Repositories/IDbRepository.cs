using MyApiProjectTest.Models.Domain;

namespace MyAPIProjectTest.Repositories
{
    public interface IDbRepository{
        Task<List<Region>> GetAllRegionAsync();

        Task<Region> GetRegionAsync(Guid guid);

        Task<int> AddRegionAsync(Region region);

        Task<int> UpdateRegionAsync(Region region);

        Task<int> DeleteRegionAsync(Region region);
    }
}