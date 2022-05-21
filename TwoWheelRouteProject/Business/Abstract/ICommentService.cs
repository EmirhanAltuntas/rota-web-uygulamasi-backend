using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<Comment>> GetById(int id);
        IDataResult<List<Comment>> GetByPostId(int id);
        IDataResult<List<Comment>> GetByUserId(int id);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);
        IResult Add(Comment comment);
    }
}
