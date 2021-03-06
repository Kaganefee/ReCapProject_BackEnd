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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.CarName equals b.BrandName
                             join co in context.Colors
                             on b.BrandName equals co.ColorName
                             select new CarDetailDto { BrandName = b.BrandName, CarName = c.CarName, ColorName = co.ColorName };
                return result.ToList();
            }
        }
    }
}