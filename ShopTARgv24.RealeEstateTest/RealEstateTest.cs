using System;
using System.Threading.Tasks;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;
using Xunit;

namespace ShopTARgv24.RealeEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task CreateRealEstate_ShouldReturnCreatedEntity()
        {
            var dto = new RealEstateDto
            {
                Area = 120.5,
                Location = "Downtown",
                RoomNumber = 3,
                BuildingType = "Apartment",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var service = Svc<IRealEstateServices>();

            var result = await service.Create(dto);

            Assert.NotNull(result);
            Assert.Equal(dto.Location, result.Location);
            Assert.Equal(dto.Area, result.Area);
        }
    }
}
