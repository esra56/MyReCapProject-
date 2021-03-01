using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.FileU
{
   public interface IFileUpload
    {
        IDataResult<CarImage> UploadImage(IFormFile file, CarImage carImage);
        IDataResult<CarImage> UpdateImage(IFormFile file, CarImage carImage);
        IDataResult<CarImage> DeleteImage(CarImage carImage);
    }
}
