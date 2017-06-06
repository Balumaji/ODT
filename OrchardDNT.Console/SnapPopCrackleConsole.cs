using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardDNT.ConsoleApp
{
    public class SnapPopCrackleConsole
    {
        public static void Main()
        {
            var maxNumber = 100;
            Console.WriteLine(SnapPopCrackle.Run(maxNumber));
        }
    }

    public static class SnapPopCrackle
    {
        public static string Run(int maxNumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 1; i <= maxNumber; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                    stringBuilder.Append("POP");
                else if (i % 3 == 0)
                    stringBuilder.Append("SNAP");
                else if (i % 5 == 0)
                    stringBuilder.Append("CRACKLE");
                else
                    stringBuilder.Append(i);
            }

            return stringBuilder.ToString();
        }
        
    }
}
