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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal){

            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAddedMessage);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeletedMessage);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(), Messages.CommentsListed);
        }

        public IDataResult<List<Comment>> GetById(int id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(p=>p.CommentId==id), Messages.CommentsListed);
        }

        public IDataResult<List<Comment>> GetByPostId(int id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(p => p.PostId == id));
        }

        public IDataResult<List<Comment>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(p => p.UserId == id));
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdatedMessage);
        }
    }
}
