using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car { CarId = 1, CarBrandId = 1, CarColorId = 1, CarDailyPrice = 200, CarModelYear = 2015 },
            new Car { CarId = 2, CarBrandId = 2, CarColorId = 3, CarDailyPrice = 220, CarModelYear =2017 },
            new Car { CarId = 3, CarBrandId = 2, CarColorId = 4, CarDailyPrice = 240, CarModelYear = 2020},
            new Car { CarId = 4, CarBrandId = 1, CarColorId = 2, CarDailyPrice = 280, CarModelYear = 2022 }
        };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarBrandId = car.CarBrandId;
            carToUpdate.CarColorId = car.CarColorId;
            carToUpdate.CarDailyPrice = car.CarDailyPrice;
            carToUpdate.CarModelYear = car.CarModelYear;
        }


    }
}
