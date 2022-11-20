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
            //UserTest();
            //CustomerTest();
            //RentalTest();

            Console.ReadLine();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental1 = new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = null
                //ReturnDate = DateTime.Now.AddDays(1)
            };

            Console.WriteLine(rentalManager.Add(rental1).Message);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer1 = new Customer()
            {
                UserId = 1,
                CompanyName = "SmartPro"
            };

            //customerManager.Add(customer1);

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            User user1 = new User()
            {
                Id = 1,
                FirstName = "Oğuz Kağan",
                LastName = "ER",
                Email = "oguzkagan@gmail.com",
                Password = "1234"
            };

            //userManager.Add(user1);
            //userManager.Update(user1);

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName);
            }

            Console.WriteLine(userManager.GetAll().Success);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color color1 = new Color() { Name = "Orange" };

            //colorManager.Add(color1);

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + " - " + color.Name);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand() { Name = "Alfa Romeo" };

            //brandManager.Add(brand1);

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + " - " + brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car() { BrandId = 1, ColorId = 1, ModelYear = 2022, DailyPrice = -100, Description = "Otomatik" };

            //Console.WriteLine(carManager.Add(car1).Message);

            var result = carManager.GetAll();

            Console.WriteLine(result.Message);

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandId);
            }

            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.BrandId);
            }

            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.BrandId);
            }

            Car car2 = new Car() { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2022, DailyPrice = 650, Description = "Manuel" };

            //carManager.Update(car2);

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Id + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);

            }
        }
    }
}