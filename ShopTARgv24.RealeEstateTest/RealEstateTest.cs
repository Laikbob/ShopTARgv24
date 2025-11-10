using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ShopTARgv24.ApplicationServices.Services;
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
                .Delete((Guid)createdRealEstate2.Id);

            Assert.NotEqual(result.Id ,createdRealEstate1.Id);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            //Arrange
            var guid = new Guid("192a39e6-5507-41ec-a066-2ed2c3126483");

            RealEstateDto dto = MockRealEstateData();

            RealEstateDto domain = new();

            domain.Id = Guid.Parse("192a39e6-5507-41ec-a066-2ed2c3126483");
            domain.Area = 200.0;
            domain.Location = "Secret Plase";
            domain.RoomNumber = 5;
            domain.BuildingType = "Villa";
            domain.CreatedAt = DateTime.Now;
            domain.ModifiedAt = DateTime.Now;
            //Act
            await Svc<IRealEstateServices>().Update(dto);

            //Assert
            Assert.Equal(guid, domain.Id);
            //DoesNotMatch ja kasutage seda Location ja Roomnumberi jaoks
            Assert.DoesNotMatch(dto.Location, domain.Location);
            Assert.DoesNotMatch(dto.RoomNumber.ToString(), domain.RoomNumber.ToString());
            Assert.NotEqual(dto.RoomNumber, domain.RoomNumber);
            Assert.NotEqual(dto.Area, domain.Area);

        }
        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData2()
        {
            //Arrange
            //peate kasutama MockRealEstaData meetodit
            RealEstateDto dto = MockRealEstateData();
            //kasutate andmete loomisel
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            //tuleb teha uus mock meetod, mistagastab RealEstateDto (peate ise uue temaga ja nimi
            //peab olems MockupdateRealEstateData())
            RealEstateDto update = MockUpdateRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(update);


            //Assert
            Assert.DoesNotMatch(dto.Location, result.Location);
            Assert.NotEqual(dto.ModifiedAt, result.ModifiedAt);

        }

        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenDidNotUpdateData()
        {
            //teha test nimega SholdNot_UpdateRealEstate_WhenDidNotUpdateData()

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
        private RealEstateDto MockUpdateRealEstateData()
        {
            RealEstateDto dto = new RealEstateDto()
            {

                Area = 90.0,
                Location = "Maountain",
                RoomNumber = 6,
                BuildingType = "Cabin log",
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1)
            };
            return dto;

        }
    }
}
