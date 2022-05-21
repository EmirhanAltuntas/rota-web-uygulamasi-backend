using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();

            builder.RegisterType<CommunityManager>().As<ICommunityService>();
            builder.RegisterType<EfCommunityDal>().As<ICommunityDal>();

            builder.RegisterType<FriendManager>().As<IFriendService>();
            builder.RegisterType<EfFriendDal>().As<IFriendDal>();

            builder.RegisterType<MemberManager>().As<IMemberService>();
            builder.RegisterType<EfMemberDal>().As<IMemberDal>();

            builder.RegisterType<PhotoManager>().As<IPhotoService>();
            builder.RegisterType<EfPhotoDal>().As<IPhotoDal>();

            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<EfPostDal>().As<IPostDal>();

            builder.RegisterType<RouteManager>().As<IRouteService>();
            builder.RegisterType<EfRouteDal>().As<IRouteDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserImageManager>().As<IUserImageService>();
            builder.RegisterType<EfUserImageDal>().As<IUserImageDal>();

            builder.RegisterType<PlaceManager>().As<IPlaceService>();
            builder.RegisterType<EfPlaceDal>().As<IPlaceDal>();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
