using ShopTARgv24.Core.Domain;
using ShopTARgv24.Core.Dto;

namespace ShopTARgv24.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<RealeEstate> Create(RealeEstateDto dto);
        Task<RealeEstate> DetailAsync(Guid id);
        Task<RealeEstate> Delete(Guid id);
        Task<RealeEstate> Update(RealeEstateDto dto);
    }
}
