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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
    public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(User user)
        {
            if (user == null)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else
            {
                _userDal.Add(user);
            }
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user == null)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else
            {
                _userDal.Delete(user);
            }
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll().ToList(), "Tüm kullanıcılar Listelendi");
        }

        public IResult Update(User user)
        {
            if (user == null)
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }
            else
            {
                _userDal.Update(user);
            }
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
