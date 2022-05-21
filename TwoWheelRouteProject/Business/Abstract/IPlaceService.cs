using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPlaceService
    {
        IDataResult<List<Place>> GetAll();
        IDataResult<List<Place>> GetById(int id);
        IResult Update(Place place);
        IResult Delete(Place place);
        IResult Add(Place place);
    }
}
