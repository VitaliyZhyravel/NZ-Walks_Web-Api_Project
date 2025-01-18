using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZ_Walks_web_api_project.Data;

public class NZWalksDbContext : DbContext
{
    public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
}
  
