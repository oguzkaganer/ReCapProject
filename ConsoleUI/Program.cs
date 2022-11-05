using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car() {Id=1, BrandId = 1, ColorId = 1, ModelYear = 2022, DailyPrice = 650, Description = "Manuel" };

            carManager.Update(car1);

            int i=1;
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(i+". "+car.Id+" - "+car.BrandName+" - "+car.ColorName+" - "+car.DailyPrice);
                i++;
            }
           
            Console.ReadLine();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car() { BrandId = 1, ColorId = 1, ModelYear = 2022, DailyPrice = -100, Description = "Otomatik" };

            carManager.Add(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId);
            }

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.BrandId);
            }

            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.BrandId);
            }
        }
    }
}