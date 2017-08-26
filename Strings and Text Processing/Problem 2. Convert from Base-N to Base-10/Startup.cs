using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Convert_from_Base_N_to_Base_10
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            List<string> commands = Console.ReadLine().Split(' ').ToList();
            int theBase = int.Parse(commands[0]);
            string theNumber = commands[1];
            Console.WriteLine(ConvertFromBaseN(theNumber, theBase));
        }

        public static BigInteger ConvertFromBaseN(string number, int theBase)
        {
            return number.Select(digit => digit - 48).Aggregate((x, y) => x * theBase + y);
        }
    }
}
