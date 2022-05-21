using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPhotoService
    {

        IDataResult<List<Photo>> GetAll();
        IDataResult<List<Photo>> GetById(int id);
        IDataResult<List<Photo>> GetByPostId(int postId);   
        IResult Add(IFormFile form, Photo photo);
        IResult Update(IFormFile form, Photo photo);
        IResult Delete(Photo photo);
    }
}
