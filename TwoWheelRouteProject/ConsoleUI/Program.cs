using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using System;
using Entities.Concrete;
using Business.Constants;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserTest();

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            // User Add
            //userManager.Add(new User
            //{
            //    FirstName = "Melek",
            //    LastName = "Naz",
            //    UserName = "melekNaz123",
            //    Email = "nazmelek1@gmail.com",
            //    PasswordHash = "asdasdasfad",
            //    PasswordSalt = "sdfdsf",
            //    Photo = "images/profil.png",
            //    Biography = "Okuyorum Öyleyse varım"
            //}); ;
            //Console.WriteLine(Messages.UserAddedMessage);


          
        }




    }
}
