using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		IDataResult<List<CarImage>> GetAll();
		IDataResult<List<CarImage>> GetByCarId(int carId);
		IResult Add(CarImage carImage, IFormFile formFile);
		IResult Update(CarImage carImage, IFormFile formFile);
		IResult Delete(CarImage carImage);
	}
}
