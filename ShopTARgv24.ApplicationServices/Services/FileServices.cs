using ShopTARgv24.Core.Dto;
using ShopTARgv24.Data;
using Microsoft.Extensions.Hosting;
using ShopTARgv24.Core.Domain;
using ShopTARgv24.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace ShopTARgv24.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly ShopTARgv24Context _context;
        private readonly IHostEnvironment _webHost;

        public FileServices
            (
                ShopTARgv24Context context,
                IHostEnvironment webHost
            )
        {
            _context = context;
            _webHost = webHost;
        }

        public void FilesToApi(KindergartenDto dto, Kindergarten kindergarten)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");
                }

                foreach (var file in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.Name;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            KindergartenId = kindergarten.id
                        };

                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }
    }
}