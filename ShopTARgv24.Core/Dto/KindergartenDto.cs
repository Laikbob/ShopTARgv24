using Microsoft.AspNetCore.Http;

namespace ShopTARgv24.Core.Dto
{
    public class KindergartenDto
    {
        public Guid id { get; set; }
        public string? GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public string? KindergartenName { get; set; }
        public string? TeacherName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<IFormFile> Files { get; set; }

    }
}
