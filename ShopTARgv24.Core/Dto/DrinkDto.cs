namespace ShopTARgv24.Core.Dto
{
    public class DrinkDto
    {
        public string IdDrink { get; set; } = string.Empty;
        public string StrDrink { get; set; } = string.Empty;
        public string StrCategory { get; set; } = string.Empty;
        public string StrAlcoholic { get; set; } = string.Empty;
        public string StrGlass { get; set; } = string.Empty;
        public string StrInstructions { get; set; } = string.Empty;
        public string StrDrinkThumb { get; set; } = string.Empty;

        public string? StrIngredient1 { get; set; }
        public string? StrIngredient2 { get; set; }
        public string? StrIngredient3 { get; set; }
        public string? StrIngredient4 { get; set; }
        public string? StrIngredient5 { get; set; }
        public string? StrIngredient6 { get; set; }

        public string? StrMeasure1 { get; set; }
        public string? StrMeasure2 { get; set; }
        public string? StrMeasure3 { get; set; }
        public string? StrMeasure4 { get; set; }
        public string? StrMeasure5 { get; set; }
        public string? StrMeasure6 { get; set; }
    }
}