using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using MyApiProjectTest.Data;
using MyApiProjectTest.Models.Domain;

namespace MyAPIProjectTest.Repositories{
    public class RegionDBRepository : IDbRepository
    {
       private readonly NzWalksDbContext _dbContext;
        public RegionDBRepository(NzWalksDbContext context){
            _dbContext = context;
        }

        public async Task<int> AddRegionAsync(Region region)
        {
            try{
                await _dbContext.regions.AddAsync(region);
                await _dbContext.SaveChangesAsync();
                return 0;
            }
            catch(Exception ex){ throw; }
        }

        public async Task<int> DeleteRegionAsync(Region region)
        {
            _dbContext.regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return 0;
        }

        public async Task<List<Region>> GetAllRegionAsync()
        {
            return await _dbContext.regions.ToListAsync();
        }

        public async Task<Region> GetRegionAsync(Guid guid)
        {
            return await _dbContext.regions.FirstOrDefaultAsync(x => x.Id == guid) ?? new Region();
        }

        public async Task<int> UpdateRegionAsync(Region region)
        {
            _dbContext.regions.Update(region);
            await _dbContext.SaveChangesAsync();
            return 0;
        }
    }
}