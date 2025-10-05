namespace ShopTARgv24.Core.Domain
{
    public class RealEstate
    {
        public Guid Id { get; set; }
        public int? Area { get; set; }           // площадь
        public string? Location { get; set; }    // адрес
        public int? RoomNumber { get; set; }     // количество комнат
        public string? BuildingType { get; set; } // тип здания
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
