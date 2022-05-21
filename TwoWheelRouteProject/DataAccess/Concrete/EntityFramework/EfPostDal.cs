using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostDal : EfEntityRepositoryBase<Post, TwoWheelRouteDbContext>, IPostDal
    {

        public List<AllPostDto> GetAllPostDtos()
        {
            using (var context = new TwoWheelRouteDbContext())
            {
                var result = from u in context.Users
                             join p in context.Posts
                             on u.UserId equals p.UserId
                             where u.UserId == p.UserId
                             select new AllPostDto
                             {
                                 UserId = u.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Description = p.Description,
                                 PostDate = p.PostDate,
                                 PostId = p.PostId,
                                 UserImages = ((from ui in context.UserImages
                                                where (ui.UserId == u.UserId)
                                                select new UserImage
                                                {
                                                    Id = ui.Id,
                                                    UserId = ui.UserId,
                                                    Date = ui.Date,
                                                    ImagePath = ui.ImagePath
                                                }).ToList()).Count == 0
                                                    ? new List<UserImage> { new UserImage { Id = -1, UserId = u.UserId, Date = DateTime.Now, ImagePath = "default.png" } }
                                                    : (from ui in context.UserImages
                                                       where (u.UserId == ui.UserId)
                                                       select new UserImage
                                                       {
                                                           Id = ui.Id,
                                                           UserId = ui.UserId,
                                                           Date = ui.Date,
                                                           ImagePath = ui.ImagePath
                                                       }).ToList()
                             };
                return result.ToList();
            }
        }

        public List<PostDetailDto> GetPostDetailDtos(Expression<Func<PostDetailDto, bool>> filter = null)
        {
            using (var context = new TwoWheelRouteDbContext())
            {
                var result = from u in context.Users
                             join p in context.Posts
                             on u.UserId equals p.UserId
                             where u.UserId == p.UserId
                             select new PostDetailDto
                             {
                                 UserId = u.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Description = p.Description,
                                 PostDate = p.PostDate,

                                 PostId = p.PostId,
                                 Places = ((from pl in context.Places
                                            where (pl.PostId == p.PostId)
                                            select new Place
                                            {
                                                PlaceId = pl.PlaceId,
                                                PostId = p.PostId,
                                                Latitude = pl.Latitude,
                                                Longitude = pl.Longitude
                                            }).ToList()),
                                 Photos = ((from ph in context.Photos
                                            where (ph.PostId == p.PostId)
                                            select new Photo
                                            {
                                                PhotoId = ph.PhotoId,
                                                 PostId= p.PostId,                                               
                                                PhotoPath = ph.PhotoPath
                                            }).ToList()).Count == 0
                                                    ? new List<Photo> { new Photo { PhotoId = -1, PostId = p.PostId,  PhotoPath = "default2.png" } }
                                                    : (from ph in context.Photos
                                                       where (p.PostId == ph.PostId)
                                                       select new Photo
                                                       {
                                                           PhotoId = ph.PhotoId,
                                                           PostId = p.PostId,
                                                           PhotoPath = ph.PhotoPath
                                                       }).ToList(),
                                 UserImages = ((from ui in context.UserImages
                                                where (ui.UserId == u.UserId)
                                                select new UserImage
                                                {
                                                    Id = ui.Id,
                                                    UserId = ui.UserId,
                                                    Date = ui.Date,
                                                    ImagePath = ui.ImagePath
                                                }).ToList()).Count == 0
                                                    ? new List<UserImage> { new UserImage { Id = -1, UserId = u.UserId, Date = DateTime.Now, ImagePath = "default.png" } }
                                                    : (from ui in context.UserImages
                                                       where (u.UserId == ui.UserId)
                                                       select new UserImage
                                                       {
                                                           Id = ui.Id,
                                                           UserId = ui.UserId,
                                                           Date = ui.Date,
                                                           ImagePath = ui.ImagePath
                                                       }).ToList(),
                                

                             };
                return filter == null
             ? result.ToList()
             : result.Where(filter).ToList();
            }
        }
    }
}