﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        IFindeksService _findeksService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, IFindeksService findeksService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _findeksService = findeksService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetRentalDetails(x => x.CarId == carId && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll().ToList(), "Tüm kullanıcılar Listelendi");
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),
                Messages.CustomerAdded);
        }

        public IResult UpdateReturnDate(int Id)
        {
            var result = _rentalDal.GetAll(x => x.CarId == Id);
            var updatedRental = result.LastOrDefault();
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult();
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult();
        }

        private IResult IfCheckFindeksScore(Rental rental)
        {
            var car = _carService.Get(rental.CarId);
            var findeks = _findeksService.GetFindeksScore(rental.CustomerId);

            if (car.Success && findeks.Success)
            {
                if (car.Data.FindeksScore < findeks.Data)
                {
                    return new SuccessResult(Messages.FindeksPointsSufficient);
                }
                return new ErrorResult(Messages.FindeksPointsInsufficient);
            }
            return new ErrorResult(Messages.GetErrorRentalMessage);
        }
    }
    }
   

