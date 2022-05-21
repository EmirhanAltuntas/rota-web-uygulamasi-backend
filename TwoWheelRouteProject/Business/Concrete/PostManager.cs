using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

       // [SecuredOperation("post.add,user")]
        public IDataResult<Post> Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessDataResult<Post>(post,Messages.PostAddedMessage);
        }

        public IResult AddTransaction(Post post)
        {
            return null;
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeletedMessage);
        }
        [CacheAspect]

        [PerformanceAspect(4)]
        public IDataResult<List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll(), Messages.PostsListed);

        }

        public IDataResult<List<AllPostDto>> GetAllPost()
        {
            return new SuccessDataResult<List<AllPostDto>>(_postDal.GetAllPostDtos(),Messages.GetAllPost);
        }

        public IDataResult<List<Post>> GetById(int id)
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll(p => p.PostId == id));
        }

        public IDataResult<List<PostDetailDto>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<PostDetailDto>>(_postDal.GetPostDetailDtos(p => p.UserId == userId));
        }

        public IDataResult<List<PostDetailDto>> GetPostDetail(int postId)
        {
            return new SuccessDataResult<List<PostDetailDto>>(_postDal.GetPostDetailDtos(p => p.PostId == postId));
        }

        [CacheRemoveAspect("IPostService.Get")]
        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdatedMessage);
        }
    }
}
