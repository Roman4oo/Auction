using auction.DAL.Entities;
using auction.DAL.Operations;
using auction.DAL.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction.BLL
{
    static class UserServices
    {
       static public void Registration(ref User user)
        {
            Console.WriteLine("Enter email :\n");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter username :\n");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter password:\n");
            user.Password = Console.ReadLine();

            UserDAL userOperations = new UserDAL();
            userOperations.Insert(user);


        }
        static public bool Login(ref User user)
        {
            Console.WriteLine("Enter email :\n");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter Password :\n");
            user.Password = Console.ReadLine();

            UserDAL userOperations = new UserDAL();
            User userCheck = userOperations.GetByPassword(user.Email, user.Password);

            if (userCheck != null)
            {
                user = userCheck;
                return true;
            }

            return false;

        }

        
    }
}
