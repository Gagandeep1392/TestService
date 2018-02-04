
using ConsoleClient.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceClient objServiceClient = new ServiceClient("TcpEndPoint");

            objServiceClient.OpenConnection();

            Console.WriteLine("Enter Record: ");
            objServiceClient.AddCountry(new Country() { Id = int.Parse(Console.ReadLine()), CountryName = Console.ReadLine().ToString() });

            Console.WriteLine("--------------------------------------");
            List<Country> lst = objServiceClient.GetCountriesAdded();
            foreach (Country item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.CountryName);
            }
          

            Console.WriteLine("Enter Record: ");
            objServiceClient.AddCountry(new Country() { Id = int.Parse(Console.ReadLine()), CountryName = Console.ReadLine().ToString() });

            Console.WriteLine("--------------------------------------");
            List<Country> lsts = objServiceClient.GetCountriesAdded();
            foreach (Country item in lsts)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.CountryName);
            }
            

            objServiceClient.CloseConnection();

            Console.ReadKey();

        }
    }
}
