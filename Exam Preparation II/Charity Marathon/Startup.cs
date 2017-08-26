using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Charity_Marathon
{
    public class Startup
    {
        public static void Main()
        {
            int daysLength = int.Parse(Console.ReadLine());
            int participants = int.Parse(Console.ReadLine());
            int avgNumOfLapsPerRunner = int.Parse(Console.ReadLine());
            int lapLength = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            if (daysLength * trackCapacity < participants)
            {
                participants = daysLength * trackCapacity;
            }

            long totalKM = ((long)participants * avgNumOfLapsPerRunner * lapLength) / 1000;
            double totalRaised = (totalKM * moneyPerKm);

            Console.WriteLine($"Money raised: {totalRaised:F2}");
        }
    }
}
