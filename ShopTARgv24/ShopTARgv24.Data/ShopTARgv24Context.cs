using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.Domain;

namespace ShopTARgv24.Data
{
    internal class ShopTARgv24Context : DbContext
    {
        public DbSet<Spaceship> Spaceships { get; set; }

    }
}
