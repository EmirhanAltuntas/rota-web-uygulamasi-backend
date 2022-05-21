using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
       
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<List<UserDetailDto>> GetUserDetailByUserId(int userId);
        IDataResult<User> GetById(int id);
    }
}
