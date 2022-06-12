using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            //UserAdd();
            //CustomerAdd();

            //Test();
        }
        private static void Update()
        {
            Car car1 = new Car { CarId = 3, BrandId = 5, ColorId = 5, CarDailyPrice = 400, CarModelYear = 2017, CarName = "Opel" };
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Update(car1);
            Console.WriteLine(result.Message);


        }

        private static void Delete()
        {
            Car car1 = new Car { CarId = 3, BrandId = 2, ColorId = 5, CarDailyPrice = 300, CarModelYear = 2016, CarName = "Mazda" };
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Delete(car1);
            Console.WriteLine(result.Message);


        }
        private static void Add()
        {
            Car car1 = new Car { CarId = 6, CarDailyPrice = 500, CarModelYear = 2016, CarName = "Mazda", BrandId = 5, ColorId = 1 };
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Insert(car1);
            Console.WriteLine(result.Message);
        }

        private static void Test2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
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
        private static void UserAdd()
        {
            User user1 = new User() { UserId = 3, Email = "asdasdasd@gmail.com", FirstName = "kaan", LastName = "EFE", Password = "123456789" };
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(user1);


        }
        private static void CustomerAdd()
        {
            Customer customer1 = new Customer() { CompanyName = "armasan", CustomerId = 1};
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(customer1);
        }

    }
}