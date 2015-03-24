using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program {
        static void Main(string[] args) {
            StreamReader _reader = new StreamReader(args[0], System.Text.Encoding.Default);
            StreamWriter _writer = new StreamWriter(args[1]);
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            var sourseName = _reader.ReadLine().Split('\t');

            while (!_reader.EndOfStream) {
                var inputString = _reader.ReadLine().Split('\t');
                for (int i = 1; i < inputString.Length; i++) {
                    if (graph.ContainsKey(inputString[0]) == false)
                        graph.Add(inputString[0],new List<string>());
                    graph[inputString[0]].Add(inputString[i]);
                }
            }

            List<string> fakeList = new List<string>();
            foreach (var t in graph[sourseName[0]])
            {
                fakeList.Add(t); 
            }
            List<string> su = new List<string>();
            HashSet<string> newFeature = new HashSet<string>();
            int level = 1;
            while (fakeList.Count!=0)
            {
                    foreach (var o in fakeList)
                    {
                        if (!newFeature.Contains(o) == true)
                        {
                            if (o == sourseName[1])
                            {
                                Console.WriteLine(level);
                                Environment.Exit(0);
                            }
                            
                            su.Add(o);
                            newFeature.Add(o);
                        }

                    }

                fakeList.Clear();

                foreach (var k in su)
                {
                    if (graph.ContainsKey(k) == true) 
                        foreach (var t in graph[k]) 
                            fakeList.Add(t);
                }
                level++;
                su.Clear();
            }
           

        }

    }
}
