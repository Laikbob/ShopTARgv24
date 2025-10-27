using ShopTARgv24.Core.Dto;


namespace ShopTARgv24.Models.Cocktail
{
    public class CocktailSearchModel
    {
        public string CocktailName { get; set; } = string.Empty;
        public List<ShopTARgv24.Core.Dto.DrinkDto>? Drinks { get; set; }
    }
}
