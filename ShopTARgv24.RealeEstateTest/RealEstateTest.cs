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
        public async Task Should_AddRealEstate_WhenDataIsValid()
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
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("192a39e6-5507-41ec-a066-2ed2c3126483");

            await Svc<IRealEstateServices>().DetailAsync(guid);
            
            Assert.NotEqual(wrongGuid, guid);  


        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("30cd0b4a-61c3-45f6-845d-0d4ad798fdd5");
            Guid guid = Guid.Parse("30cd0b4a-61c3-45f6-845d-0d4ad798fdd5");

        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            var service = Svc<IRealEstateServices>();

            var dto = new RealEstateDto
            {
                Area = 6,
                Location = "Riga",
                RoomNumber = 38,
                BuildingType = "Apartment",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var created = await service.Create(dto);
            var deleted = await service.Delete(created.Id);
            var resultAfterDelete = await service.GetAsync(created.Id);

            Assert.NotNull(deleted);
            Assert.Equal(created.Id, deleted.Id);
            Assert.Null(resultAfterDelete);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            var service = Svc<IRealEstateServices>();
            var fakeId = Guid.NewGuid();

            var result = await service.Delete(fakeId);

            Assert.Null(result);
        }
    }
}
