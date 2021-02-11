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
             new Car{CarId = 1 , BrandId = 1 ,ColorId = 6, CarName ="Porsche", ModelYear = 1948, DailyPrice = 890, Description = "1 Nolu Araç Açıklaması"},
             new Car{CarId = 2 , BrandId = 1 , ColorId = 3, CarName ="Audi", ModelYear = 1932, DailyPrice = 150, Description = "2 Nolu Araç Açıklaması"},
             new Car{CarId = 3 , BrandId = 2 , ColorId = 2, CarName ="BMW",  ModelYear = 1916, DailyPrice = 500, Description = "3 Nolu Araç Açıklaması"},
             new Car{CarId = 4 , BrandId = 3 , ColorId = 4, CarName ="Ford",  ModelYear = 1903, DailyPrice = 140, Description = "4 Nolu Araç Açıklaması"},
             new Car{CarId = 5 , BrandId = 3 , ColorId = 7, CarName ="Ferrari", ModelYear = 1947, DailyPrice = 458, Description = "5 Nolu Araç Açıklaması"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
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

            var expression = filter.Compile();
            return filter == null ? _cars : _cars.Where(expression).ToList();
        }

        public List<Car> GetByBrandId(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
