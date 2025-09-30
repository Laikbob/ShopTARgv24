using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.Domain;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.Data;


//namespace ShopTARgv24.ApplicationServices.Services
//{
//    public class RealeEstateServices : IRealeEstateServices
//    {
//        private readonly ShopTARgv24Context _context;
//        private readonly IFileServices _fileServices;

//        public RealeEstateServices(
//            ShopTARgv24Context context,
//            IFileServices fileServices)
//        {
//            _context = context;
//            _fileServices = fileServices;
//        }

//        public async Task<RealeEstate> Create(RealeEstateDto dto)
//        {
//            RealeEstate realeestate = new RealeEstate
//            {
//                Id = Guid.NewGuid(),
//                Name = dto.Name,
//                TypeName = dto.TypeName,
//                BuiltDate = dto.BuiltDate,
//                Crew = dto.Crew,
//                EnginePower = dto.EnginePower,
//                Passengers = dto.Passengers,
//                InnerVolume = dto.InnerVolume,
//                CreatedAt = DateTime.Now,
//                ModifiedAt = DateTime.Now
//            };

//            _fileServices.FilesToApi(dto, realeestate);

//            await _context.RealeEstate.AddAsync(realeestate);
//            await _context.SaveChangesAsync();

//            return realeestate;
//        }

//        public async Task<RealeEstate> DetailAsync(Guid id)
//        {
//            return await _context.RealeEstate.FirstOrDefaultAsync(x => x.Id == id);
//        }
//    }
//}



