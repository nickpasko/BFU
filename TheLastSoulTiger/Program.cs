using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random1
{
    class Program
    { //придумать ввод и передачу значений через arqs 
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] maleNames = { "Rufus", "Bear", "Dakota", "Fido", 
                                "Vanya", "Samuel", "Koani", "Volodya", 
                                "Prince", "Yiska" };
            string[] femaleNames = { "Maggie", "Penny", "Saya", "Princess", 
                                  "Abby", "Laila", "Sadie", "Olivia", 
                                  "Starlight", "Talla" };

            // Generate random indexes for names 
            int mIndex = rnd.Next(maleNames.Length);
            int fIndex = rnd.Next(femaleNames.Length);

            // Display the result 
            Console.WriteLine("{0}\nlove", maleNames[mIndex]);
            //Console.WriteLine("love");
            Console.WriteLine("{0}", femaleNames[fIndex]);
        }
    }
}
