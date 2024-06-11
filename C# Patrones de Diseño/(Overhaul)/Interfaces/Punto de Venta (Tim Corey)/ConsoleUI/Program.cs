using DemoLibrary;

using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            List<IProductModel> cart = AddSampleData();
            CustomerModel customer = GetCustomer();

            foreach (IProductModel prod in cart)
            {
                prod.ShipItem(customer);

                if (prod is IDigitalProductModel digital)
                {
                    Console.WriteLine($"For the { digital.Title } you have { digital.TotalDownloadsLeft } downloads left.");
                }
            }

            Console.ReadLine();
        }

        private static CustomerModel GetCustomer()
        {
            return new CustomerModel
            {
                FirstName = "Tim",
                LastName = "Corey",
                City = "Scranton",
                EmailAddress = "tim@IAmTimCorey.com",
                PhoneNumber = "555-1212"
            };
        }

        private static List<IProductModel> AddSampleData()
        {
            List<IProductModel> output = new List<IProductModel>
            {
                new PhysicalProductModel { Title = "Nerf Football" },
                new PhysicalProductModel { Title = "IAmTimCorey T-Shirt" },
                new PhysicalProductModel { Title = "Hard Drive" },
                new DigitalProductModel { Title = "Lesson Source Code" },
                new CourseProductModel { Title = ".NET Core Start to Finish" }
            };

            return output;
        }
    }
}
