using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICommunityService
    {
        IDataResult<List<Community>> GetAll();
        IResult Update(Community community);
        IResult Delete(Community community);
        IResult Add(Community community);
    }
}
