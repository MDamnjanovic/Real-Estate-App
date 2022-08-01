using Realty.Business;
using Realty.Entities;
using System;
using System.Collections.Generic;

namespace Realty.UI.Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CityBsn cityBsn = new CityBsn();
            //string id = Console.ReadLine();
            //CityEntities city = cityBsn.getCityById(Convert.ToInt32(id));
            //Console.WriteLine(city.CityName);

            RealtyBsn realtyBsn = new RealtyBsn();
            string id = Console.ReadLine();
            List<RealtyEntities> realties = realtyBsn.GetAllRealtiesFromArea(Convert.ToInt32(id));
            foreach (RealtyEntities realty in realties)
            {
                Console.WriteLine(realty.ToString());

            }
            string i = Console.ReadLine();

            List<RealtyEntities> realtiesFromAgent = realtyBsn.GetAllRealtiesFromAgent(Convert.ToInt32(i));
            foreach (RealtyEntities realty in realtiesFromAgent)
            {
                Console.WriteLine($"Address Id: {realty.RealtyAddress.Id}, Square meters: {realty.SquareMeters}, Price : {realty.Price}, Object Type: {realty.ObjectType}, Sale or Rent: {realty.SaleOrRent}");

            }
            int realtyId = 9;
            Console.WriteLine("Update realty \nInsert sq meters: ");
            short squareMeters = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Insert price: ");
            //Int16.TryParse
            decimal price = Convert.ToDecimal(Console.ReadLine());
            realtyBsn.UpdateRealty(realtyId, squareMeters, price, "Apartment", "Rent", DateTime.Now, null, false);
            Console.ReadKey();
        }
    }
}
