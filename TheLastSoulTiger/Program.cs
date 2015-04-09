using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] maleNames = { "Rufus", "Bear", "Dakota", "Fido", 
                                "Vanya", "Samuel", "Koani", "Volodya", 
                                "Prince", "Yiska" };
            string[] femaleNames = { "Maggie", "Penny", "Saya", "Princess", 
                                  "Abby", "Laila", "Sadie", "Olivia", 
                                  "Starlight", "Talla" };

            // Generate random indexes for pet names.
            int mIndex = rnd.Next(maleNames.Length);
            int fIndex = rnd.Next(femaleNames.Length);

            // Display the result.
            /* Console.WriteLine("Suggested pet name of the day: ");
             Console.WriteLine("   For a male:     {0}", maleNames[mIndex]);
             Console.WriteLine("   For a female:   {0}", femaleNames[fIndex]);*/
            Console.WriteLine("{0}\nlove", maleNames[mIndex]);
            //Console.WriteLine("love");
            Console.WriteLine("{0}", femaleNames[fIndex]);
        }
    }
}
