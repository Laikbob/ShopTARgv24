using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;
using Xunit;

namespace ShopTARgv24.KindergartenTest
{
    public class KindergartenTest : TestBase
    {
        private readonly IKindergartenServices _service;

        public KindergartenTest()
        {
            _service = Svc<IKindergartenServices>();
        }

        private KindergartenDto CreateDto()
        {
            return new KindergartenDto
            {
                GroupName = "Group A",
                ChildrenCount = 20,
                KindergartenName = "Sunny Kids",
                TeacherName = "Anna Smith"
            };
        }

        // CREATE
        [Fact]
        public async Task Create_ShouldCreateKindergarten()
        {
            var result = await _service.Create(CreateDto());

            Assert.NotNull(result);
            Assert.Equal("Group A", result.GroupName);
            Assert.Equal(20, result.ChildrenCount);
        }

        // DETAIL
        [Fact]
        public async Task DetailAsync_ShouldReturnKindergarten()
        {
            var created = await _service.Create(CreateDto());

            var result = await _service.DetailAsync(created.Id);

            Assert.NotNull(result);
            Assert.Equal(created.Id, result.Id);
        }

        // UPDATE
        [Fact]
        public async Task Update_ShouldUpdateKindergarten()
        {
            var created = await _service.Create(CreateDto());

            var updateDto = new KindergartenDto
            {
                Id = created.Id,
                GroupName = "Updated Group",
                ChildrenCount = 30,
                KindergartenName = "Updated Name",
                TeacherName = "New Teacher",
                CreatedAt = created.CreatedAt
            };

            var result = await _service.Update(updateDto);

            Assert.Equal("Updated Group", result.GroupName);
            Assert.Equal(30, result.ChildrenCount);
        }

        // DELETE
        [Fact]
        public async Task Delete_ShouldRemoveKindergarten()
        {
            var created = await _service.Create(CreateDto());

            await _service.Delete(created.Id);
            var result = await _service.DetailAsync(created.Id);

            Assert.Null(result);
        }

        // CREATE without files
        [Fact]
        public async Task Create_WithoutFiles_ShouldWork()
        {
            var dto = CreateDto();
            dto.Files = null;

            var result = await _service.Create(dto);

            Assert.NotNull(result);
        }

        // DETAIL not found
        [Fact]
        public async Task DetailAsync_WhenNotFound_ShouldReturnNull()
        {
            var result = await _service.DetailAsync(Guid.NewGuid());

            Assert.Null(result);
        }
    }
}
