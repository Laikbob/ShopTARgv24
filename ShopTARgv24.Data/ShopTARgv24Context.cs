using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.Domain;


namespace ShopTARgv24.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
        : base(options) { }
        public DbSet<Kindergarten> Kindergarten { get; set; }

        public DbSet<FileToApi> FileToApis { get; set; }
    }
}