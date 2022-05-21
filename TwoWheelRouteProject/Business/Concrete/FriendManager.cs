using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public class FriendManager : IFriendService
    {
        IFriendDal _friendDal;

        public FriendManager(IFriendDal friendDal)
        {
            _friendDal = friendDal;
        }
        public IResult Add(Friend friend)
        {
            _friendDal.Add(friend);
            return new SuccessResult(Messages.FriendAddedMessage);
        }

        public IResult Delete(Friend friend)
        {
            _friendDal.Delete(friend);
            return new SuccessResult(Messages.FriendDeletedMessage);
        }

        public IDataResult<List<Friend>> GetAll()
        {
            return new SuccessDataResult<List<Friend>>(_friendDal.GetAll(), Messages.FriendsListed);
        }

        public IDataResult<List<Friend>> GetById(int id)
        {
            return new SuccessDataResult<List<Friend>>(_friendDal.GetAll(p=>p.FriendId==id));
        }

        public IDataResult<List<Friend>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<Friend>>(_friendDal.GetAll(p => p.UserId1 == id));
        }

        public IResult Update(Friend friend)
        {
            _friendDal.Update(friend);
            return new SuccessResult(Messages.FriendUpdatedMessage);
        }
    }
}
