using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.RealeEstateTest.Mock;

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
            //Arrange
            Guid databaseGuid = Guid.Parse("192a39e6-5507-41ec-a066-2ed2c3126483");
            Guid guid = Guid.Parse("192a39e6-5507-41ec-a066-2ed2c3126483");

            //Act
            await Svc<IRealEstateServices>().DetailAsync(guid);
            
            //Assert
            ResourceAsset.Equals(databaseGuid, guid);


        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            RealEstateDto dto = MockRealEstateData();

            var createdRealEstate = await Svc<IRealEstateServices>()
                .Create(dto);
            var deletedRealEstate = await Svc<IRealEstateServices>()
                .Delete((Guid)createdRealEstate.Id);

            Assert.Equal(createdRealEstate, deletedRealEstate);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            //Arrange
            RealEstateDto dto = MockRealEstateData();
            //Act
            var createdRealEstate1  = await Svc<IRealEstateServices>()
                .Create(dto);
            var createdRealEstate2 = await Svc<IRealEstateServices>()
                .Create(dto);
            var result = await Svc<IRealEstateServices>()
                .Delete((Guid)createdRealEstate1.Id);

            Assert.NotEqual(result.Id ,createdRealEstate1.Id);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            //Arrange
            var service = Svc<IRealEstateServices>();
            var realEstate = MockRealEstateData();

            //Act


            //Assert

        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto dto = new RealEstateDto()
            {
                Area = 120.5,
                Location = "Downtown",
                RoomNumber = 3,
                BuildingType = "Apartment",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            return dto;
        }
    }
}
