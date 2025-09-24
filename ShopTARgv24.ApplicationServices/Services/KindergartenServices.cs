using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.Core.Domain;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Data;


namespace ShopTARgv24.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopTARgv24Context _context;
        private readonly IFileServices _fileServices;
        public KindergartenServices
    (
        ShopTARgv24Context context,
        IFileServices fileServices
    )
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new Kindergarten();

            kindergarten.id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.TeacherName = dto.TeacherName;
            kindergarten.CreatedAt = dto.CreatedAt;
            kindergarten.UpdatedAt = dto.UpdatedAt;

            _fileServices.FilesToApi(dto, kindergarten);

            await _context.Kindergarten.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }
        public async Task<Kindergarten> DetailAsync(Guid id)
        {
            var result = await _context.Kindergarten
                .FirstOrDefaultAsync(x => x.id == id);

            return result;
        }
        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergarten = await _context.Kindergarten
                .FirstOrDefaultAsync(x => x.id == id);

            _context.Kindergarten.Remove(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }
        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            Kindergarten domain = new();

            domain.id = dto.id;
            domain.GroupName = dto.GroupName;
            domain.ChildrenCount = dto.ChildrenCount;
            domain.KindergartenName = dto.KindergartenName;
            domain.TeacherName = dto.TeacherName;
            domain.CreatedAt = dto.CreatedAt;
            domain.UpdatedAt = DateTime.Now;

            _context.Kindergarten.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}