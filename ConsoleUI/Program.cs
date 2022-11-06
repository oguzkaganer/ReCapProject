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

            //BrandTest();

            //ColorTest();



            Console.ReadLine();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color color1 = new Color() { Name = "Orange" };

            colorManager.Add(color1);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + " - " + color.Name);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand() { Name = "Alfa Romeo" };

            brandManager.Add(brand1);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + " - " + brand.Name);
            }
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

            Car car2 = new Car() { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2022, DailyPrice = 650, Description = "Manuel" };

            carManager.Update(car2);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);

            }
        }
    }
}