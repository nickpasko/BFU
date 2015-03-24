using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MindTasks
{
	class Program
	{
		private static StreamReader _reader;
		private static StreamWriter _writer;

		static void Main(string[] args)
		{
			try
			{
				_reader = new StreamReader(args[0], System.Text.Encoding.Default);
				_writer = new StreamWriter(args[1]);
				SolveProblem();
			}
			catch (ArgumentNullException exception1)
			{
				Console.WriteLine(exception1.Message);
			}
			catch (FileNotFoundException exception2)
			{
				Console.WriteLine(exception2.Message);
			}
			catch (IndexOutOfRangeException exception3)
			{
				Console.WriteLine("Wrong number of arguments.");
			}
			Console.ReadKey();
		}

		static void SolveProblem()
		{
			SearchInGraph search = new SearchInGraph(_reader, _writer);
			search.BFS();
		}
	}

	class SearchInGraph
	{
		private StreamReader _reader;
		private StreamWriter _writer;

		public SearchInGraph(StreamReader _reader, StreamWriter _writer)
		{
			this._reader = _reader;
			this._writer = _writer;
		}

		private Queue<Person> queue = new Queue<Person>();
		private Dictionary<string, PersonData> graph = new Dictionary<string, PersonData>();

		public void BFS()
		{
			InputInformation information = new InputInformation();
			graph = information.ReadInput(_reader, _writer);

			Person person = new Person();
			person.Name = information.Name1;
			person.children = graph[person.Name].Friend.children;

			queue.Enqueue(person);

			graph[person.Name].Was = true;

			while (queue.Count > 0)
			{

				Person p = queue.Peek();

				//Thread.Sleep(1000);

				queue.Dequeue();

				if (!graph.ContainsKey(p.Name)) // If graph doesn't contain Key = p.Name
				{
					continue;
				}
				for (int i = 0; i < graph[p.Name].Friend.children.Count; i++)
				{
					Person to = graph[p.Name].Friend.children[i];
					if (graph.ContainsKey(to.Name))
					{
						if (graph[to.Name].Was == false)
						{
							graph[to.Name].Was = true;
							queue.Enqueue(to);
							graph[to.Name].Distance = graph[p.Name].Distance + 1;
						}
					}
					else
					{
						PersonData personData = new PersonData();
						//personData.Friend = new Person();
						personData.Was = true;
						graph.Add(to.Name, personData);

						graph[to.Name].Distance = graph[p.Name].Distance + 1;
					}
				}
			}
			Message(information.Name1, information.Name2, graph[information.Name2].Distance);


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
		private Dictionary<string, PersonData> graph = new Dictionary<string, PersonData>();

		public string Name1 { get; set; }
		public string Name2 { get; set; }

		public Dictionary<string, PersonData> ReadInput(StreamReader _reader, StreamWriter _writer)
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
					PersonData personData = new PersonData();
					personData.Friend = person;
					graph.Add(person.Name, personData);
				}
			}
			return graph;
		}
	}

	class Person
	{
		public string Name { get; set; }
		public List<Person> children = new List<Person>();
	}

	class PersonData
	{
		public bool Was { get; set; }

		public int Distance { get; set; }

		public Person Friend { get; set; }
	}
}
