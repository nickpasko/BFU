using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrasesList = new List<string>();
            phrasesList.Add("Привет, ");
            phrasesList.Add("Давай досвидания, ");
            phrasesList.Add("Олалэй, ");
            phrasesList.Add("Я люблю курсы, ");
            var rnd = new Random();
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(phrasesList[rnd.Next(0, phrasesList.Count)]+args[i].ToString()+".");
            }




        }
    }
}
