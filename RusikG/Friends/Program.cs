using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Friends
{
    struct Friends
    {
        public string name;
        public int numberOfFriends;
    }

    class Program
    {
        private static StreamReader reader; 
        private static StreamWriter writer;

        static void Main(string[] args)
        {
            reader = new StreamReader(args[0]);
            writer = new StreamWriter(args[1]);

            List<Friends> friendses = new List<Friends>();
            Dictionary<string, List<string>> existingFriends = new Dictionary<string, List<string>>();
            string linesOfFile = reader.ReadToEnd();
            string[] namesOfLines = linesOfFile.Split(new string[]{"\r\n"},StringSplitOptions.None).ToArray();

            foreach (var s in namesOfLines)
            {
                List<string> splitedLines = s.Split('\t').ToList();
                string firtsName = splitedLines[0];
                splitedLines.Remove(splitedLines[0]);
                existingFriends.Add(firtsName,splitedLines);
            }

            foreach (var friend in existingFriends)
            {
                List<string> existingFriendsList = new List<string>();

                foreach (var ff in friend.Value)
                {
                    existingFriendsList.Add(ff);
                }

                foreach (var existingFriend in existingFriends)
                {

                    if (existingFriend.Value.Contains(friend.Key))
                    {
                        existingFriendsList.Add(existingFriend.Key);
                    }
                }

                var uniqList = existingFriendsList.Distinct().ToList();

                friendses.Add(new Friends()
                {
                    name = friend.Key,
                    numberOfFriends = uniqList.Count
                });
            }

            using (writer)
            {
                foreach (var friend in friendses)
                {
                    writer.WriteLine(friend.name+" - "+friend.numberOfFriends);
                }
            }
            
        }
    }
}
