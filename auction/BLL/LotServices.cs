using auction.DAL.Entities;
using auction.DAL.Operations.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction.BLL
{
    static class LotServices
    {


        static public void Buy(int i, ref List<Lot> lots)
        {
            LotDAL lotOperations = new LotDAL();
            lotOperations.Delete(lots[i].ID);
            lots.Remove(lots[i]);


        }
        static public void AddLot(ref List<Lot> lots)
        {
            LotDAL lotOperations = new LotDAL();
            Lot lot = new Lot();

            Console.WriteLine("Enter name of Lot \n");
            lot.Name = Console.ReadLine();
            Console.WriteLine("Enter price");
            lot.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter TimeTo");
            lot.TimeTo = Convert.ToDouble(Console.ReadLine());

            lotOperations.Insert(lot);
            lots.Add(lot);
        }
        static public void ShowAll(ref List<Lot> lots)
        {
            int i = 0;
            LotDAL lotOperations = new LotDAL();
            lots = lotOperations.GetAll();
            foreach (var lot in lots)
            {
                Console.WriteLine(i+"\nName - " + lots[i].Name + "\n" + "Price - " + lots[i].Price + "\n" + "Time To - " + lots[i].TimeTo);
                i++;
            }

        }
    }
}
