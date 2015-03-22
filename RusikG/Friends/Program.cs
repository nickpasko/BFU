using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Friends
{
    struct Friends
    {
        public string name;
        public int numberOfFriends;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Friends> friendses = new List<Friends>();
            List<string> existingFriends;
            string[] lines = File.ReadAllLines(
                    "Friends.tsv");

            for (int i = 0; i < lines.Length; i++)
            {
                existingFriends = new List<string>();
                string[] names = lines[i].Split('\t').Select(X => X.ToLower()).ToArray();
                for (int j = 1; j < names.Length; j++)
                {
                    existingFriends.Add(names[j]);
                }
                for (int k = 0; k < lines.Length; k++)
                {
                    if (lines[k].Split('\t').Select(X => X.ToLower()).Contains(names[0]))
                    {
                        existingFriends.Add(lines[k].Split('\t').Select(X => X.ToLower()).ToArray()[0]);
                    }
                }
                existingFriends.Remove(names[0]);
                var uniq = existingFriends.Distinct().ToList();
                friendses.Add(new Friends()
                {
                    name = names[0],
                    numberOfFriends = uniq.Count
                });
            }

            using (StreamWriter file = new StreamWriter(@"Result.txt"))
            {
                foreach (var friend in friendses)
                {
                    file.WriteLine(friend.name+" - "+friend.numberOfFriends);
                }
            }
        }
    }
}
