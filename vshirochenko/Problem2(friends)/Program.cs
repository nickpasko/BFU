using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpToSP
{
	class Program
	{
		static void Main()
		{
			SolveProblem();
		}

		static void SolveProblem()
		{
			SearchInGraph search = new SearchInGraph();
			search.BFS();
		}
	}

	class SearchInGraph
	{
		private static StreamReader _reader = new StreamReader("input.txt", System.Text.Encoding.Default);
		private static StreamWriter _writer = new StreamWriter("output.txt");

		private Queue<Person> queue = new Queue<Person>();
		private Dictionary<string, bool> was = new Dictionary<string, bool>();
		private Dictionary<string, int> distance = new Dictionary<string, int>();
		private Dictionary<string, Person> graph = new Dictionary<string, Person>();
		
		public void BFS()
		{
			InputInformation information = new InputInformation();
			information.ReadInput(_reader, _writer);
			graph = information.GetGraph();

			Person person = new Person();
			person.Name = information.Name1;
			person.children = graph[person.Name].children;

			queue.Enqueue(person);

			foreach (var g in graph.Keys)
			{
				was.Add(g, false);
				distance.Add(g, 0);
			}
			was[person.Name] = true;

			while (queue.Count > 0)
			{
				Person p = queue.Peek();
				//Console.WriteLine(p.Name);

				queue.Dequeue();
				if (!graph.ContainsKey(p.Name)) // If graph doesn't contain Key = p.Name
				{
					continue;
				}
				for (int i = 0; i < graph[p.Name].children.Count; i++)
				{
					Person to = graph[p.Name].children[i];
					if (was.ContainsKey(to.Name))
					{
						if (was[to.Name] == false)
						{
							was[to.Name] = true;
							queue.Enqueue(to);
							distance[to.Name] = distance[p.Name] + 1;
						}
					}
					else
					{
						was.Add(to.Name, true);
						queue.Enqueue(to);
						distance[to.Name] = distance[p.Name] + 1;
					}
				}
			}
			Message(information.Name1, information.Name2, distance[information.Name2]);

			_reader.Close();
			_writer.Close();
		}

		public void Message(string name1, string name2, int dist)
		{
			if (dist != 0)
			{
				_writer.WriteLine("{0}, your friendship level to {1} = {2}", name1, name2, dist);
			}
			else if (name1 != name2)
			{
				_writer.WriteLine("Sorry {0}, but {1} isn't your friend :(", name1, name2);
			}
			else
			{
				_writer.WriteLine("You wrote two identical names!");
			}
		}
	}


	class InputInformation
	{

		public string Name1 { get; set; }
		public string Name2 { get; set; }

		private Dictionary<string, Person> graph = new Dictionary<string, Person>();

		public void ReadInput(StreamReader _reader, StreamWriter _writer)
		{
			var inputString = _reader.ReadLine().Split('\t');
			string[] meAndMyFriends;
			

			Name1 = inputString[0];
			Name2 = inputString[1];

			while (!_reader.EndOfStream)
			{
				meAndMyFriends = _reader.ReadLine().Split('\t');
				int size = meAndMyFriends.Length;
				if (size > 1) // There are some friends
				{
					Person person = new Person();
					person.Name = meAndMyFriends[0];

					List<Person> friends = new List<Person>();
					for (int i = 1; i < size; i++)
					{
						if (string.IsNullOrEmpty(meAndMyFriends[i]))
						{
							continue;
						}

						Person friend = new Person();
						friend.Name = meAndMyFriends[i];
						friends.Add(friend);
					}

					person.children = friends;
					graph.Add(person.Name, person);
				}
			}
		}
		

		public Dictionary<string, Person> GetGraph()
		{
			return graph;
		}
	}

	class Person
	{
		public string Name { get; set; }
		public List<Person> children = new List<Person>();
	}
}
