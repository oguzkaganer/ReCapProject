using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            var carList = carManager.GetAll();

            foreach (var car in carList)
            {
                Console.WriteLine(car.BrandId);
            }



            Console.ReadLine();
        }
    }
}