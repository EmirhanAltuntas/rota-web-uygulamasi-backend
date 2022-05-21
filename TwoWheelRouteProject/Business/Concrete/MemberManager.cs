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
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }
        public IResult Add(Member member)
        {
            _memberDal.Add(member);
            return new SuccessResult(Messages.MemberAddedMessage);
        }

        public IResult Delete(Member member)
        {
            _memberDal.Delete(member);
            return new SuccessResult(Messages.MemberDeletedMessage);
        }

        public IDataResult<List<Member>> GetAll()
        {
            return new SuccessDataResult<List<Member>>(_memberDal.GetAll(), Messages.MembersListed);

        }

        public IDataResult<List<Member>> GetById(int id)
        {
            return new SuccessDataResult<List<Member>>(_memberDal.GetAll(p => p.MemberId == id));
        }

        public IResult Update(Member member)
        {
            _memberDal.Update(member);
            return new SuccessResult(Messages.MemberUpdatedMessage);
        }
    }

}
