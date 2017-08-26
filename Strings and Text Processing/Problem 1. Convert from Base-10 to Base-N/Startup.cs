using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Convert_from_Base_10_to_Base_N
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            List<BigInteger> commands = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToList();
            BigInteger theBase = commands[0];
            BigInteger theNumber = commands[1];
            StringBuilder builder = new StringBuilder();

            while (theNumber != 0)
            {
                builder.Insert(0,(theNumber % theBase));
                theNumber /= theBase;
            }

            Console.WriteLine(builder);
        }
    }
}
