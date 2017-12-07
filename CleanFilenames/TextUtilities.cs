using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanFilenames
{
	public static class TextUtilities
	{
		public static bool YearWithBraces(string stringToCheck)
		{
			Regex regex = new Regex(@"\d{4}");
			Match match = regex.Match(stringToCheck);

			if (match.Success)
			{

				foreach (var group in match.Groups)
				{
					var year = int.Parse(group.ToString());

					if (year > 1920 && year < 2040)
					{
						if (stringToCheck[match.Index - 1] == (char)'(')
						{
							return true;
						}
					}
					
				}

				
			}

			return false;
		}


		public static string AddBracesToYear(string stringToCheck)
		{
			Regex regex = new Regex(@"\d{4}");
			Match match = regex.Match(stringToCheck);

			while (match.Success)
			{			
				var year = int.Parse(match.Value.ToString());

				if (year > 1920 && year < 2040)
				{

					// when year is at the end of string
					if (match.Index + 4 == stringToCheck.Length)
					{
						stringToCheck = stringToCheck + ")";
					}
					else // when year is in the middle
					{
						if (stringToCheck[match.Index + 4] != (char) ')')
						{
							stringToCheck = stringToCheck.Insert(match.Index + 4, ")");
						}
					}

					if (stringToCheck[match.Index - 1] != (char)'(')
					{
						stringToCheck = stringToCheck.Insert(match.Index, "(");
					}
				}

				match = match.NextMatch();
			}

			return stringToCheck;
		}

	}
}
