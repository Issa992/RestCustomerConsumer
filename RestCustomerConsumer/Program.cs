using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestCustomerConsumer
{
    class Program
    {
        private static string CustomerUri = "https://localhost:44316/api/Customers";

        static void Main(string[] args)
        {
            try
            {
                RunAsync().GetAwaiter().GetResult();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Console.ReadKey();



        }

        static async Task RunAsync()
        {
            IList<Customer> CustomerList;
            CustomerList = await GetCustomerAsync();
            ShowCustomer(CustomerList);
        }
        static async Task ShowCustomer(IList<Customer> CustomerList)
        {

            foreach (var List in CustomerList)
            {
                Console.WriteLine($"Id:{List.Id}//////Name:{List.FirstName}{List.LastName}//////Year{List.Year}");

            }
        }

        public static async Task<IList<Customer>> GetCustomerAsync()
        {
            using (HttpClient client =new HttpClient())
            {
                string content = await client.GetStringAsync(CustomerUri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }
    }
}
