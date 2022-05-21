using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPostService
    {

        IDataResult<List<Post>> GetAll();
        IDataResult<List<Post>> GetById(int id);
        IDataResult<List<PostDetailDto>> GetByUserId(int userId);
        IResult Update(Post post);
        IResult Delete(Post post);
        IDataResult<Post> Add(Post post);
        IResult AddTransaction(Post post);
        IDataResult<List<AllPostDto>> GetAllPost();
        IDataResult<List<PostDetailDto>> GetPostDetail(int postId);
    }
}
