using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanFilenames
{
	class Program
	{
		static void Main(string[] args)
		{
			string directoryPath = "X:\\";
			List<string> directories = new List<string>();

			directories = DiskUtilities.GetDirectories(directoryPath);
			
			directories.Sort();

			foreach (var directory in directories)
			{
				Console.WriteLine(directory);
			}


			Console.WriteLine("\nPress any key to exit...");
			Console.ReadKey();
		}


		

	}
}
