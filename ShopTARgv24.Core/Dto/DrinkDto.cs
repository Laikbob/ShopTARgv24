
namespace ShopTARgv24.Core.Dto
{
    public class DrinkDto
    {
        public string IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrCategory { get; set; }
        public string StrAlcoholic { get; set; }
        public string StrGlass { get; set; }
        public string StrInstructions { get; set; }
        public string StrDrinkThumb { get; set; }
    }

    public class IngredientDto
    {
        public string IdIngredient { get; set; }
        public string StrIngredient { get; set; }
        public string StrDescription { get; set; }
        public string StrType { get; set; }
    }

    public class CocktailApiResponse
    {
        public List<DrinkDto> Drinks { get; set; }
    }

    public class IngredientApiResponse
    {
        public List<IngredientDto> Ingredients { get; set; }
    }
}