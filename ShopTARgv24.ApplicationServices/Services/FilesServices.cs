using System.IO;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Data;
using Microsoft.Extensions.Hosting;
using ShopTARgv24.Core.Domain;
using ShopTARgv24.Core.ServiceInterface;

namespace ShopTARgv24.ApplicationServices.Services

{
    public class FilesServices: IFileServices
    {
        private readonly ShopTARgv24Context _context;
        private readonly IHostEnvironment _webHost;

        public FilesServices
            (
             ShopTARgv24Context context,
             IHostEnvironment _webHost

            )
        {
          _context = context;
          _webHost = _webHost;
        }
        public void FielsToApi(SpaceshipDto dto, Spaceship spaceship)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");
                }
                foreach (var file in dto.Files)
                {
                    //muutuja string uploadsFolder j sinna laetakse failid
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");

                    //muutuja string uniqueFileName ja siin genereeritakse uus Guid ja lisatakse see faili ette
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.Name;  

                    // muutuja srting filePath kombineeritakse koos unikalse nimega
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStrem = new FileStream(filePath, FileMode.Create))
                    { 
                        file.CopyTo(fileStrem);

                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            SpaceshipId = spaceship.Id
                        };

                        _context.FileToApi.AddAsync( path );
                    }
                }
            }
        }
    }
}
