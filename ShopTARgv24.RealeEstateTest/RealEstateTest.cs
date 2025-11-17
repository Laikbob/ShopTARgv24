using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;

namespace ShopTARgv24.RealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            // Arrange
            RealEstateDto dto = new();

            dto.Area = 120.5;
            dto.Location = "Downtown";
            dto.RoomNumber = 3;
            dto.BuildingType = "Apartment";
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            // Act
            var result = await Svc<IRealEstateServices>().Create(dto);

            // Assert
            Assert.NotNull(result);

        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            // Arrange
            Guid wrongGuid = Guid.NewGuid();
            Guid guid = Guid.Parse("e83448d3-ee24-4e02-8544-f105743ccafb");

            // Act
            await Svc<IRealEstateServices>().DetailAsync(guid);

            // Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsEqual()
        {
            //Arrange
            Guid databaseGuid = Guid.Parse("e83448d3-ee24-4e02-8544-f105743ccafb");
            Guid guid = Guid.Parse("e83448d3-ee24-4e02-8544-f105743ccafb");

            //Act
            await Svc<IRealEstateServices>().DetailAsync(guid);

            //Assert
            Assert.Equal(databaseGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //Arrange
            RealEstateDto dto = MockRealEstateData();

            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var deletedRealEstate = await Svc<IRealEstateServices>().Delete((Guid)createdRealEstate.Id);

            //Assert
            Assert.Equal(deletedRealEstate, createdRealEstate);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            //Arrange
            RealEstateDto dto = MockRealEstateData();

            //Act
            var createdRealEstate1 = await Svc<IRealEstateServices>().Create(dto);
            var createdRealEstate2 = await Svc<IRealEstateServices>().Create(dto);

            var result = await Svc<IRealEstateServices>().Delete((Guid)createdRealEstate2.Id);

            //Assert
            Assert.NotEqual(result.Id, createdRealEstate1.Id);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            //Arrange
            var guid = new Guid("7f7769cf-e139-4c6b-a2f2-467785f987b8");

            RealEstateDto dto = MockRealEstateData();
            RealEstateDto domain = new();

            domain.Id = guid;
            domain.Area = 200.0;
            domain.Location = "Secret Place";
            domain.RoomNumber = 5;
            domain.BuildingType = "Villa";
            domain.CreatedAt = DateTime.Now;
            domain.ModifiedAt = DateTime.Now;

            //Act
            await Svc<IRealEstateServices>().Update(dto);

            //Assert
            Assert.Equal(guid, domain.Id);
            Assert.DoesNotMatch(dto.Location, domain.Location);
            Assert.DoesNotMatch(dto.RoomNumber.ToString(), domain.RoomNumber.ToString());
            Assert.NotEqual(dto.RoomNumber, domain.RoomNumber);
            Assert.NotEqual(dto.Area, domain.Area);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData2()
        {
            //Arrange
            RealEstateDto dto = MockRealEstateData();

            //Act
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);
            RealEstateDto update = MockUpdateRealEstateData();

            var result = await Svc<IRealEstateServices>().Update(update);

            //Assert
            Assert.DoesNotMatch(dto.Location, result.Location);
            Assert.NotEqual(dto.ModifiedAt, result.ModifiedAt);
        }

        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenDidNotUpdateData()
        {
            //Arrange
            RealEstateDto dto = MockRealEstateData();

            //Act
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);
            RealEstateDto update = MockNullRealEstateData();

            var result = await Svc<IRealEstateServices>().Update(update);

            //Assert
            Assert.NotEqual(dto.Id, result.Id);
        }
        [Fact]
        public async Task Should_ReturnNull_WhenGettingRealEstateWithWrongId()
        {
            // Arrange
            Guid wrongId = Guid.NewGuid();

            // Act
            var result = await Svc<IRealEstateServices>().DetailAsync(wrongId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ShouldNot_DeleteRealEstate_WhenIdDoesNotExist()
        {
            // Arrange
            Guid wrongId = Guid.NewGuid();

            // Act
            var result = await Svc<IRealEstateServices>().Delete(wrongId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenIdIsMissing()
        {
            // Arrange
            RealEstateDto createDto = MockRealEstateData();
            var created = await Svc<IRealEstateServices>().Create(createDto);

            // DTO без Id → обновление невозможно
            RealEstateDto updateDto = new RealEstateDto
            {
                Id = null,
                Area = 999,
                Location = "Wrong",
                RoomNumber = 99,
                BuildingType = "Test",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            // Act
            var result = await Svc<IRealEstateServices>().Update(updateDto);
            var afterUpdate = await Svc<IRealEstateServices>().DetailAsync((Guid)created.Id);

            // Assert
            Assert.Equal(created.Location, afterUpdate.Location);
            Assert.Equal(created.Area, afterUpdate.Area);
            Assert.Equal(created.RoomNumber, afterUpdate.RoomNumber);
        }


        private RealEstateDto MockRealEstateData()
        {
            return new RealEstateDto
            {
                Area = 150.0,
                Location = "Uptown",
                RoomNumber = 3,
                BuildingType = "Apartment",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
        }

        private RealEstateDto MockUpdateRealEstateData()
        {
            return new RealEstateDto
            {
                Area = 100.0,
                Location = "Mountain",
                RoomNumber = 3,
                BuildingType = "Cabin log",
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };
        }

        private RealEstateDto MockNullRealEstateData()
        {
            return new RealEstateDto
            {
                Id = null,
                Area = null,
                Location = null,
                RoomNumber = null,
                BuildingType = null,
                CreatedAt = null,
                ModifiedAt = null,
            };
            
        }
    }
}
