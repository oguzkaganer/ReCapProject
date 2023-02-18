using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		IFileHelper _fileHelper;

		public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
		{
			_carImageDal = carImageDal;
			_fileHelper = fileHelper;
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
		}

		public IDataResult<List<CarImage>> GetByCarId(int carId)
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
		}

		public IResult Add(CarImage carImage, IFormFile formFile)
		{
			IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
			if (result != null)
			{
				return result;
			}
			carImage.ImagePath = _fileHelper.Upload(formFile, "wwwroot/images");
			carImage.Date = DateTime.Now;
			_carImageDal.Add(carImage);
			return new SuccessResult("Resim başarıyla yüklendi");
		}

		public IResult Update(CarImage carImage, IFormFile formFile)
		{
			return new SuccessResult();
		}

		public IResult Delete(CarImage carImage)
		{
			return new SuccessResult();
		}

		private IResult CheckIfCarImageLimit(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
			if (result >= 5)
			{
				return new ErrorResult();
			}
			return new SuccessResult();
		}
		private IDataResult<List<CarImage>> GetDefaultImage(int carId)
		{

			List<CarImage> carImage = new List<CarImage>();
			carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
			return new SuccessDataResult<List<CarImage>>(carImage);
		}
		private IResult CheckCarImage(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
			if (result > 0)
			{
				return new SuccessResult();
			}
			return new ErrorResult();
		}
	}
}
