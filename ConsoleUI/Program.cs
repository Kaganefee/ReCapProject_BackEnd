using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //Delete();
            //Update();
            //Add();

            
            //Test();
        }
        private static void Update()
        {
            Car car1 = new Car { CarId = 3, CarBrandId = 5, CarColorId = 5, CarDailyPrice = 400, CarModelYear = 2017, CarName = "Opel" };
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Update(car1);
            Console.WriteLine(result.Message);


        }

        private static void Delete()
        {
            Car car1 = new Car { CarId = 3, CarBrandId = 2, CarColorId = 5, CarDailyPrice = 300, CarModelYear = 2016, CarName="Mazda" };
            CarManager carManager = new CarManager(new EfCarDal());
            var result=carManager.Delete(car1);
            Console.WriteLine(result.Message);
            
            
        }
        private static void Add()
        {
            Car car1 = new Car { CarId = 11, CarBrandId = 2, CarColorId = 5, CarDailyPrice = 300, CarModelYear = 2016, CarName = "Mazda" };
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.BrandId = car1.CarBrandId;
            var result = carManager.Insert(car1);
            var result2 = brandManager.Add(brand);
            Console.WriteLine(result.Message);
        }

        private static void Test2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void Test()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetail();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {

                    Console.WriteLine(car.CarName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}