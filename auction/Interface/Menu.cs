using auction.BLL;
using auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction.Interface
{
    class Menu
    {
        User user;
        List<Lot> lots;
        public Menu()
        {
            user = new User();
            lots = new List<Lot>();

            ConsoleKey action;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Login \n2.Register");
                action = Console.ReadKey().Key;
                switch (action)
                {
                    case ConsoleKey.D1:
                        UserServices.Login(ref user);
                        ShowUserInfo();
                        break;
                    case ConsoleKey.D2:
                        UserServices.Registration(ref user);
                        ShowUserInfo();
                        Console.ReadKey();
                        break;
                        

                }


            } while (action != ConsoleKey.Escape);


        }
        public void ShowUserInfo()
        {
            Console.Clear();
            int i = 0;
            Console.WriteLine("Hello  " + user.Name);
            Console.WriteLine("1. Buy Lots");
            Console.WriteLine("2. AddLot");
            Console.WriteLine("Esc. Exit");
            ConsoleKey action = Console.ReadKey().Key;

            switch(action)
            {
                case ConsoleKey.D1:
                    LotServices.ShowAll(ref lots);
                    i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Buy :");
                    LotServices.Buy(i, ref lots);                    
                    ShowUserInfo();
                    break;
                case ConsoleKey.D2:
                    LotServices.AddLot(ref lots);
                    ShowUserInfo();
                    break;
                

            }
            

        }

      
    }
}
