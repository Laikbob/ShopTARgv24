namespace ShopTARgv24.Models.RealeEstate
{
    public class RealEstateDetailsViewModel
    {
        public Guid? Id { get; set; }
        public int? Area { get; set; }
        public string? Location { get; set; }
        public int? RoomNumber { get; set; }
        public int? BuildingType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
