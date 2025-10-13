using ShopTARgv24.Core.Dto;

namespace ShopTARgv24.Core.ServiceInterface
{
    public class IWeatherForecsastServices
    {
        public object GetWeatherByCity(string city)
        {
            throw new NotImplementedException();
        }

        Task<AccuLocationWeatherResultDto> AccuWeatherResul(AccuLocationWeatherResultDto dto);
    }
}
