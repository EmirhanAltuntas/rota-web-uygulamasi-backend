using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
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

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(), Messages.UsersListed);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetailByUserId(int userId)
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(u => u.UserId == userId));
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>( _userDal.Get(u=>u.UserId==id));
        }
        public IResult Update(User user)
        {
            User _user = new User { Email = user.Email, PasswordHash = user.PasswordHash, PasswordSalt = user.PasswordSalt, Status = user.Status };
          
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdatedMessage);
        }
    }
}
