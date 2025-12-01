using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.Data;
using ShopTARgv24.SpaceshipTest;

namespace ShopTARgv24.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        private SpaceshipDto MockSpaceshipData()
        {
            return new SpaceshipDto
            {
                Name = "Explorer",
                TypeName = "Battlecruiser",
                BuiltDate = DateTime.Now.AddYears(-3),
                Crew = 120,
                EnginePower = 8000,
                Passengers = 50,
                InnerVolume = 700,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
        }
        
        private SpaceshipDto MockUpdatedSpaceshipData(Guid id)
        {
            return new SpaceshipDto
            {
                Id = id,
                Name = "Explorer MK2",
                TypeName = "Heavy Cruiser",
                BuiltDate = DateTime.Now.AddYears(-1),
                Crew = 200,
                EnginePower = 12000,
                Passengers = 80,
                InnerVolume = 900,
                CreatedAt = DateTime.Now.AddYears(-3),
                ModifiedAt = DateTime.Now
            };
        }

        // ----------------------------------------------------------------------
        //Цель: Убедиться, что метод Create работает корректно с валидными данными.
        
                [Fact]
        public async Task Should_CreateSpaceship_WithValidData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var result = await Svc<ISpaceshipsServices>().Create(dto);

            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(dto.Crew, result.Crew);
        }

        // ----------------------------------------------------------------------
        // Цель: Проверить, что после создания объекта можно получить тот же объект по его Id.
        [Fact]
        public async Task Should_ReturnSameSpaceship_WhenGetDetailsAfterCreate()
        {
            SpaceshipDto dto = MockSpaceshipData();

            var created = await Svc<ISpaceshipsServices>().Create(dto);
            var fetched = await Svc<ISpaceshipsServices>().DetailAsync((Guid)created.Id);

            Assert.NotNull(fetched);
            Assert.Equal(created.Id, fetched.Id);
            Assert.Equal(created.Name, fetched.Name);
        }

        // ----------------------------------------------------------------------
        //Цель: Убедиться, что удаление объекта работает корректно и возвращает удалённый объект.
        

        [Fact]
        public async Task Should_DeleteSpaceship_WhenDeleteById()
        {
            var dto = MockSpaceshipData();
            var created = await Svc<ISpaceshipsServices>().Create(dto);
            var deleted = await Svc<ISpaceshipsServices>().Delete((Guid)created.Id);

            Assert.Equal(created.Id, deleted.Id);
        }

        // ----------------------------------------------------------------------
        // Цель: Проверить корректное обновление объекта и что данные реально изменяются.
        
         [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var dto = MockSpaceshipData();
            var created = await Svc<ISpaceshipsServices>().Create(dto);

            Svc<ShopTARgv24Context> ().ChangeTracker.Clear();

            SpaceshipDto update = MockUpdatedSpaceshipData((Guid)created.Id);

            var updated = await Svc<ISpaceshipsServices>().Update(update);

            Assert.Equal(update.Id, updated.Id);
            Assert.NotEqual(created.Name, updated.Name);
            Assert.NotEqual(created.EnginePower, updated.EnginePower);
        }

        // ----------------------------------------------------------------------
        //Цель: Проверить корректное обновление объекта и что данные реально изменяются.

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenIdDoesNotExist()
        {
            // Arrange
            SpaceshipDto update = MockSpaceshipData();
            update.Id = Guid.NewGuid();

            // Act & Assert
            try
            {
                await Svc<ISpaceshipsServices>().Update(update);
                // Если исключение не выброшено — тест должен провалиться
                Assert.True(false, "Expected DbUpdateConcurrencyException was not thrown.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Проверяем, что это именно наше ожидаемое исключение
                Assert.NotNull(ex);
            }
        }
    }
}