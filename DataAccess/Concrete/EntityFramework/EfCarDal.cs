using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands on car.BrandId equals b.Id
                             join cl in context.Colors on car.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = car.DailyPrice
                             };

                return result.ToList();

            }
        }
    }
}
