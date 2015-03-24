using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve tmp = new Solve();
            tmp.ReadText();
            tmp.Text1();
        }
    }

    class Solve
    {

        private static StreamReader fileInput = new StreamReader("input.txt", System.Text.Encoding.Default);
        private static StreamWriter fileOutput = new StreamWriter("output.txt");
        public static string Text;

        public void ReadText()
        {
            Text = fileInput.ReadToEnd();

        }

        public void Text1()
        {
            string[] words = Text.Split(new[] { ' ', ',', ':', '?', '!', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                fileOutput.WriteLine(word);
            }
            fileOutput.Close();
        }
    }
}
