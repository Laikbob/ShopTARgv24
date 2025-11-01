using Microsoft.AspNetCore.Http;
using ShopTARgv24.Core.Domain;
using ShopTARgv24.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShopTARgv24.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(KindergartenDto dto, Kindergarten domain);
        void UploadFilesToDatabase(KindergartenDto dto, Kindergarten domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
        Task<FileToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
    }
}
