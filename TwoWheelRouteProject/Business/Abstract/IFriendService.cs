using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFriendService
    {

        IDataResult<List<Friend>> GetAll();
        IDataResult<List<Friend>> GetById(int id);
        IDataResult<List<Friend>> GetByUserId(int id);
        IResult Update(Friend friend);
        IResult Delete(Friend friend);
        IResult Add(Friend friend);
    }
}
