using System.Collections.Generic;

namespace ShopTARgv24.Core.Dto.Cocktail
{
    public class IngredientDto
    {
        public string StrIngredient1 { get; set; } = string.Empty;
    }

    public class IngredientApiResponse
    {
        public List<IngredientDto>? Ingredients { get; set; }
    }
}
