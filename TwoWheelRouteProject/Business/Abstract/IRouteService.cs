using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRouteService
    {
        IDataResult<List<Route>> GetAll();
        IDataResult<List<Route>> GetById(int id);
        IResult Update(Route route);
        IResult Delete(Route route);
        IResult Add(Route route);
    }
}
