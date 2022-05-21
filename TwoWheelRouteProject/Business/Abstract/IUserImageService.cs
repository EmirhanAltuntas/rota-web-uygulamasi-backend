using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IResult Add(IFormFile formFile, UserImage userImage);
        IResult Update(IFormFile formFile, UserImage userImage);
        IResult Delete(UserImage userImage);
        IDataResult<List<UserImage>> GetAll();
        IDataResult<List<UserImage>> GetByUserId(int userId);

    }
}
