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
    public class EfUserDal : EfEntityRepositoryBase<User, TwoWheelRouteDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new TwoWheelRouteDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserDetailDto> GetUserDetails(Expression<Func<UserDetailDto, bool>> filter= null)
        {
            using (var context = new TwoWheelRouteDbContext())
            {
                var result = from u in context.Users
                             select new UserDetailDto
                             {
                                 UserId=u.UserId,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 Biography=u.Biography,
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
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
            }
        }
      
    }
}
