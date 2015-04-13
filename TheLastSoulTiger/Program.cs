using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random1
{
    class Program
    { //придумать ввод и передачу значений через arqs 
        static void Main(string (string (Char[]argsmale); string (Char[] argsfemale)) // Не знаю синтаксис
        {
            for (int i = 0; i <= 10; ++i)
            Random rnd = new Random();
            Char argsmale = new argsmale { "Rufus", "Bear", "Dakota", "Fido", 
                                "Vanya", "Samuel", "Koani", "Volodya", 
                                "Prince", "Yiska" }; // поле, но используется как тип
            Char argsfema = new argsfemale { "Maggie", "Penny", "Saya", "Princess", 
                                  "Abby", "Laila", "Sadie", "Olivia", 
                                  "Starlight", "Talla" };

            // Generate random indexes for names 
            char mIndex = rnd.Next(maleNames.Length); // ошибка, что-то другое должно быть?
            char fIndex = rnd.Next(femaleNames.Length);

            // Display the result 
            Console.Line("{0}\nlove", maleNames[mIndex]);
            //Console.WriteLine("love");
            Console.Line("{0}", femaleNames[fIndex]);
        }
    }
}
