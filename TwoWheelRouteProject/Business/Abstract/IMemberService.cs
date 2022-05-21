using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMemberService
    {
        IDataResult<List<Member>> GetAll();
        IDataResult<List<Member>> GetById(int id);
        IResult Update(Member member);
        IResult Delete(Member member);
        IResult Add(Member member);
    }
}
