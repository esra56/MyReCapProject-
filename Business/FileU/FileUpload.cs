using Business.FileU;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.FileU
{
    public class FileUpload : IFileUpload
    {
        private IHostingEnvironment _hostingEnvironment;
        public FileUpload(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

        }
        public IDataResult<CarImage> UploadImage(IFormFile file, CarImage carImage)
        {
            var fullPath = FullPath(file);

            var addedCarImage = new CarImage
            {
                Date = DateTime.Now,
                CarId = carImage.CarId,
                ImagePath = fullPath
            };

            using (var streamFileStream = File.Create(fullPath))
            {
                file.CopyTo(streamFileStream);
            }

            return new SuccessDataResult<CarImage>(addedCarImage);
        }
        public IDataResult<CarImage> UpdateImage(IFormFile file, CarImage carImage)
        {
            var fullPath = FullPath(file);

            var updatedImage = new CarImage
            {
                Id = carImage.Id,
                ImagePath = fullPath,
                Date = DateTime.Now,
                CarId = carImage.CarId
            };
            using (var stream = File.Create(fullPath))
            {
                file.CopyTo(stream);
            }

            return new SuccessDataResult<CarImage>(updatedImage);
        }

        public IDataResult<CarImage> DeleteImage(CarImage carImage)
        {
            File.Delete(carImage.ImagePath);
            return new SuccessDataResult<CarImage>(carImage);
        }
        private string FullPath(IFormFile file)
        {
            var path = _hostingEnvironment.ContentRootPath + @"\wwwroot\";
            var imagePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(path, imagePath);
            return fullPath;
        }
    }
}
