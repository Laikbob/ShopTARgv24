namespace ShopTARgv24.Models
{
    public class WeatherModel
    {
        public MainInfo Main { get; set; }
        public List<WeatherInfo> Weather { get; set; }
        public string Name { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
    }

    public class WeatherInfo
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
