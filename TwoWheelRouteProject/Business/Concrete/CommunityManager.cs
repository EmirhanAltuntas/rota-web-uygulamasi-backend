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
    public class CommunityManager : ICommunityService
    {
        ICommunityDal _communityDal;

        public CommunityManager(ICommunityDal communityDal)
        {
            _communityDal = communityDal;
        }

        public IResult Add(Community community)
        {
            _communityDal.Add(community);
            return new SuccessResult(Messages.CommunityAddedMessage);
        }

        public IResult Delete(Community community)
        {
            _communityDal.Delete(community);
            return new SuccessResult(Messages.CommunityDeletedMessage);
        }

        public IDataResult<List<Community>> GetAll()
        {
            return new SuccessDataResult<List<Community>>(_communityDal.GetAll(), Messages.CommunitiesListed);
        }

        public IResult Update(Community community)
        {
            _communityDal.Update(community);
            return new SuccessResult(Messages.CommunityUpdatedMessage);
        }
    }
}
