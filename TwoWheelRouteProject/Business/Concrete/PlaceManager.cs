using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PlaceManager : IPlaceService
    {
        IPlaceDal _placeDal;
        public PlaceManager(IPlaceDal placeDal)
        {
            _placeDal = placeDal;
        }
        public IResult Add(Place place)
        {
            _placeDal.Add(place);
            return new SuccessResult(Messages.PlaceAddedMessage);
        }

        public IResult Delete(Place place)
        {
            _placeDal.Delete(place);
            return new SuccessResult(Messages.PlaceDeletedMessage);
        }

        public IDataResult<List<Place>> GetAll()
        {
            return new SuccessDataResult<List<Place>>(_placeDal.GetAll(), Messages.PlacesListed);
        }

        public IDataResult<List<Place>> GetById(int id)
        {
            return new SuccessDataResult<List<Place>>(_placeDal.GetAll(p => p.PlaceId == id));
        }

        public IResult Update(Place place)
        {
            _placeDal.Update(place);
            return new SuccessResult(Messages.PlaceUpdatedMessage);
        }
    }
}
