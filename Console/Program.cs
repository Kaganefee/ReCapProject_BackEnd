using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            
        }

        private static void Test()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetail();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    
                    System.Console.WriteLine(car.CarName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
        }
    }
}
