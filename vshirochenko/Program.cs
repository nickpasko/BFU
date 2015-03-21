using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace OlimpCoding
{
	class Program
	{
		static void Main()
		{
			Solver solve = new Solver();
            solve.ReadInput();
            solve.CountNumberOfBoxes();
		}
	}

	class Solver
	{
		private static StreamReader _reader = new StreamReader("input.txt");
		private static StreamWriter _writer = new StreamWriter("output.txt");

		private static long _storeWidth, _storeLength, _storeHeight;
		private static long _boxWidth, _boxLength, _boxHeight;
	    private static long[] inputArray;

		public void ReadInput()
		{
			var inputString = _reader.ReadLine().Split(new char[] {',', ' '});

		    inputArray = inputString
		        .Where(i => !string.IsNullOrEmpty(i))
		        .Select(i => long.Parse(i))
		        .ToArray();
		}

	    public void CountNumberOfBoxes()
	    {
            _storeWidth = inputArray[0];
            _storeLength = inputArray[1];
            _storeHeight = inputArray[2];
            _boxWidth = inputArray[3];
            _boxLength = inputArray[4];
            _boxHeight = inputArray[5];
            long result = (_storeWidth / _boxWidth) * (_storeLength / _boxLength) * (_storeHeight / _boxHeight); // formula to count the number of boxes

            _writer.WriteLine(result);

            _reader.Close();
            _writer.Close();
	    }
	}
}
