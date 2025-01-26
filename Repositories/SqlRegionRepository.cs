using Microsoft.EntityFrameworkCore;
using NZ_Walks_web_api_project.Data;
using NZWalks.Models.Domain;

namespace NZ_Walks_web_api_project.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
        public async Task<Region?> GetByIdAsync(Guid id)
        {
           return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<Region> CreateAsync(Region region)
        {
           await dbContext .Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var updateRegion = await dbContext .Regions.FirstOrDefaultAsync(x => x.Id ==id);
            if (updateRegion == null) return null;

           
            updateRegion.Name = region.Name;
            updateRegion.Code = region.Code;
            updateRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return region;
        }
        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null) return null;

            dbContext.Regions.Remove(region);

            await dbContext.SaveChangesAsync();

            return region;
        }
    }
}
