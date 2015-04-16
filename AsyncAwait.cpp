using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleAsyncApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var tmp = Files.AllScan(new List<string> { "%TEMP%" });
			Console.WriteLine("I was printed first, but I'm the second operator.");
			foreach (var t in tmp.Result)
			{
				Console.WriteLine(t);
			}
		}

		private static class Files
		{
			private static List<string> FindFilesInTree(string path)
			{
				Console.WriteLine("Still working");
				List<string> Result = new List<string>();
				string dir = Environment.ExpandEnvironmentVariables(path);
				string[] files = Directory.GetFiles(dir);
				foreach (string f in files)
				{
					FileInfo fi = new FileInfo(f);
					Result.Add(fi.FullName);
				}
				string[] dirs = Directory.GetDirectories(dir);
				foreach (string d in dirs)
				{
					Result.AddRange(FindFilesInTree(d));
				}
				return Result;
			}

			public static async Task<List<string>> AllScan(List<string> paths)
			{
				await Task.Delay(1000);
				List<string> Result = new List<string>();
				foreach (string path in paths)
				{
					var slow = Task.Factory.StartNew(() => FindFilesInTree(path));
					await slow;
					Result.AddRange(slow.Result);
				}
				return Result;
			}
		}
	}
}
