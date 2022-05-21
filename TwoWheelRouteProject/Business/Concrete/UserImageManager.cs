using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;
        IFileHelper _fileHelper;

        public UserImageManager(IUserImageDal userImageDal,IFileHelper fileHelper)
        {
            _userImageDal = userImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile formFile, UserImage userImage)
        {
            userImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
            userImage.Date = DateTime.Now;
            _userImageDal.Add(userImage);
            
            return new SuccessResult(Messages.UserImageAdded);
        }
        public IResult Update(IFormFile formFile, UserImage userImage)
        {
            userImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagesPath + userImage.ImagePath, PathConstants.ImagesPath);
            _userImageDal.Update(userImage);
            userImage.Date = DateTime.Now;
            return new SuccessResult(Messages.UserImageUpdated);
        }

        public IResult Delete(UserImage userImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + userImage.ImagePath);
            _userImageDal.Delete(userImage);
            return new SuccessResult(Messages.UserImageDeleted);
        }

        public IDataResult<List<UserImage>> GetAll()
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll());
        }

        public IDataResult<List<UserImage>> GetByUserId(int userId)
        {
            IResult result = BusinessRules.Run(CheckIfUserHasImage(userId));
            if (result!=null)
            {
                return new SuccessDataResult<List<UserImage>>(new List<UserImage>() { new UserImage {ImagePath="default.png"}});
            }
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(i => i.UserId == userId));
        }

        private IResult CheckIfUserHasImage(int userId)
        {
            var result = _userImageDal.GetAll(u => u.UserId == userId);
            if (result.Count<=0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

       
    }
}
