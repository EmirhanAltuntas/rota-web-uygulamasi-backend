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
    public class PhotoManager : IPhotoService
    {
        IPhotoDal _photoDal;
        IFileHelper _fileHelper;

        public PhotoManager(IPhotoDal photoDal,IFileHelper fileHelper)
        {
            _photoDal = photoDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile formFile, Photo photo)
        {
            IResult result = BusinessRules.Run(CheckIfPostImageLimit(photo.PostId));
            if (result!=null)
            {
                return result;
            }
            photo.PhotoPath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
            _photoDal.Add(photo);
            return new SuccessResult(Messages.PhotoAddedMessage);
        }

        public IResult Delete(Photo photo)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + photo.PhotoPath);
            _photoDal.Delete(photo);
            return new SuccessResult(Messages.PhotoDeletedMessage);
        }

        public IDataResult<List<Photo>> GetAll()
        {
            return new SuccessDataResult<List<Photo>>(_photoDal.GetAll(), Messages.PhotosListed);

        }

        public IDataResult<List<Photo>> GetById(int id)
        {
            return new SuccessDataResult<List<Photo>>(_photoDal.GetAll(p => p.PhotoId == id));
        }

        public IDataResult<List<Photo>> GetByPostId(int id)
        {
            return new SuccessDataResult<List<Photo>>(_photoDal.GetAll(p => p.PostId == id));
        }

        public IResult Update(IFormFile formFile, Photo photo)
        {
            photo.PhotoPath = _fileHelper.Update(formFile, PathConstants.ImagesPath + photo.PhotoPath, PathConstants.ImagesPath);
            _photoDal.Update(photo);
            return new SuccessResult(Messages.PhotoUpdatedMessage);
        }

        private IResult CheckIfPostImageLimit(int postId)
        {
            var result = _photoDal.GetAll(p => p.PostId == postId).Count;
            if (result>=3)
            {
                return new ErrorResult(Messages.ImagesLimit);
            }
            return new SuccessResult();
        }

    }
}
