using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public  IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(),Messages.CarAdded);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(p=>p.CarId==id));
        }

        public IResult Insert(Car car)
        {
            
            if (car.CarName.Length <= 2 && car.CarDailyPrice > 0)
            {
                return new ErrorResult(Messages.CarNotAdded);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour==12)
            {
                return new ErrorResult(Messages.UpdateNotSuccess);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
