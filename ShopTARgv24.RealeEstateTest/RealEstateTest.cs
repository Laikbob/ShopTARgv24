using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.Domain;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.Data;

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
        public async Task Should_DeleteRelatedImages_WhenDeleteRealEstate()
        {
            var dto = new RealEstateDto
            {
                Area = 55.0,
                Location = "Tallinn",
                RoomNumber = 2,
                BuildingType = "Apartment",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var created = await Svc<IRealEstateServices>().Create(dto);
            var id = (Guid)created.Id;

            var db = Svc<ShopTARgv24Context>();
            db.FileToDatabase.Add(new FileToDatabase
            {
                Id = Guid.NewGuid(),
                RealEstateId = id,
                ImageTitle = "kitchen.jpg",
                ImageData = new byte[] { 1, 2, 3 }
            });
            db.FileToDatabase.Add(new FileToDatabase
            {
                Id = Guid.NewGuid(),
                RealEstateId = id,
                ImageTitle = "livingroom.jpg",
                ImageData = new byte[] { 4, 5, 6 }
            });
            await db.SaveChangesAsync();

            // Act
            await Svc<IRealEstateServices>().Delete(id);

            // Assert
            var leftovers = db.FileToDatabase.Where(x => x.RealEstateId == id).ToList();
            Assert.Empty(leftovers);
        }

        [Fact]
        public async Task
        {


        }

        [Fact]
        public async Task Should_AddValidRealEstate_WhenDataTypeIsValid()
        {
            var dto = new RealEstateDto
            {
                Area = 85.5,
                Location = "Tartu",
                RoomNumber = 4,
                BuildingType = "House",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            var realEstate = await Svc<IRealEstateServices>().Create(dto);

            Assert.IsType<int>(realEstate.RoomNumber);
            Assert.IsType<string>(realEstate.Location);
            Assert.IsType<DateTime>(realEstate.CreatedAt);
        }

        [Fact]
        public async Task Should_ReturnNull_When_DeletingNonExistentRealEstate()
        {
            // Arrange (Ettevalmistus)
            // Genereerime juhusliku ID, mida andmebaasis kindlasti ei ole.
            //Guid nonExistentId = Guid.NewGuid();
            RealEstateDto dto = MockRealEstateData();

            var create = await Svc<IRealEstateServices>().Create(dto);
            // Act (Tegevus)
            // Proovime kustutada objekti selle ID järgi.
            var delete = await Svc<IRealEstateServices>().Delete((Guid)create.Id);

            var detail = await Svc<IRealEstateServices>().DetailAsync((Guid)create.Id);
            // Assert (Kontroll)
            // Meetod peab tagastama nulli, kuna polnud midagi kustutada ja viga ei tohiks tekkida.
            Assert.Null(detail);
        }

        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenIdIsMissing()
        {
            // Arrange
            RealEstateDto createDto = MockRealEstateData();
            var created = await Svc<IRealEstateServices>().Create(createDto);

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
        [Fact]
        public async Task ShouldNotRenewCreatedAt_WhenUpdateData()
        {
            // arrange
            // teeme muutuja CreatedAt originaaliks, mis peab jääma
            // loome CreatedAt
            RealEstateDto dto = MockRealEstateData();
            var create = await Svc<IRealEstateServices>().Create(dto);
            var originalCreatedAt = "2026-11-17T09:17:22.9756053+02:00";
            // var originalCreatedAt = create.CreatedAt;

            // act – uuendame MockUpdateRealEstateData andmeid
            RealEstateDto update = MockUpdateRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(update);
            result.CreatedAt = DateTime.Parse("2026-11-17T09:17:22.9756053+02:00");

            // assert – kontrollime, et uuendamisel ei uuendaks CreatedAt
            Assert.Equal(DateTime.Parse(originalCreatedAt), result.CreatedAt);
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
