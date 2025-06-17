using Microsoft.EntityFrameworkCore;
using MyApiProjectTest.Models.Domain;

namespace MyApiProjectTest.Data{
    public class NzWalksDbContext : DbContext{
        public NzWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions){

        }

        // WE have to create the  properties of DBSet which will create the tables in the database or which will help to get the data from the database?
        public DbSet<Difficulty> difficulties{ get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> walks { get; set; }
    }
}