using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace SoftUni_Coffee_Orders
{
    public class Startup
    {
        public static void Main()
        {
            int numOrders = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;
            for (int i = 0; i < numOrders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string theDate = Console.ReadLine();
                DateTime orderDate = DateTime.ParseExact(theDate,"d/M/yyyy",CultureInfo.InvariantCulture);
                long capsuleCount = long.Parse(Console.ReadLine());
                int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                decimal price = (daysInMonth * capsuleCount) * pricePerCapsule;
                totalPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
            Console.WriteLine(int.MaxValue);
        }
    }
}
