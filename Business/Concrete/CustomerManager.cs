using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
           
                _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult Delete(Customer customer)
        {
            if (customer == null)
            {
                return new ErrorResult(Messages.ColorDescriptionInvalid);
            }
            else
            {
                _customerDal.Add(customer);
            }
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll().ToList(), "Tüm kullanıcılar Listelendi");
        }

        public IResult Update(Customer customer)
        {
            if(customer == null)
            {
                return new ErrorResult(Messages.BrandDescriptionInvalid);
            }
            else
            {
                _customerDal.Add(customer);
            }
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
