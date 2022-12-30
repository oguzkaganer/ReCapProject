﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
		}

		public IDataResult<Car> Get(int id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
		}

		public IResult Add(Car car)
		{
			ValidationTool.Validate(new CarValidator(),car);

			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}
	}
}
