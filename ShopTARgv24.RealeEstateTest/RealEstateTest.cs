using System.Threading.Tasks;

namespace ShopTARgv24.
{
    public class RealEstateTest
    {
        [Fact]
        public async Task Test1()
        {
            RealEstateDto dto= new ();

            dto.Area=120.5;
            dto.Location= "Downtown";
            dto.RoomNumber = 3;
            dto.BuildingType = "Apartament";
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;

            var result = await Svc<IRealEstateServices>().Create(dto);


        }
    }
}
