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
    public class RouteManager : IRouteService
    {
        IRouteDal _routeDal;

        public RouteManager(IRouteDal routeDal)
        {
            _routeDal = routeDal;
        }
        public IResult Add(Route route)
        {
            _routeDal.Add(route);
            return new SuccessResult(Messages.RouteAddedMessage);
        }

        public IResult Delete(Route route)
        {
            _routeDal.Delete(route);
            return new SuccessResult(Messages.RouteDeletedMessage);
        }

        public IDataResult<List<Route>> GetAll()
        {
            return new SuccessDataResult<List<Route>>(_routeDal.GetAll(), Messages.RoutesListed);
        }

        public IDataResult<List<Route>> GetById(int id)
        {
            return new SuccessDataResult<List<Route>>(_routeDal.GetAll(p => p.RouteId == id));
        }

        public IResult Update(Route route)
        {
            _routeDal.Update(route);
            return new SuccessResult(Messages.RouteUpdatedMessage);
        }
    }
}
