using System.Text;
using System;

namespace Core
{
	public static class PhonewordTranslator
	{
		public static string ToNumber(string raw)
		{
			if (raw.Length == 0)
			{
				return ("");
			}
			else
			{
				raw = raw.ToUpperInvariant();
				raw = raw.Trim();
			}
			var newNumber = new StringBuilder();
			foreach (char c in raw)
			{
				if (" -0123456789".Contains(Char.ToString(c)))
				{
					newNumber.Append(c);
				}
				else
				{
					var whatAmI = Translator(c);
					if (whatAmI != null)
					{
						newNumber.Append(whatAmI);
					}
				}
			}
			return (newNumber.ToString());
		}
		public static int? Translator(char characterToBeTranslated)
		{
			if (inRangeOf(Convert.ToInt32(characterToBeTranslated), 65, 67))
			{
				return (2);
			}
			if (inRangeOf(Convert.ToInt32(characterToBeTranslated), 68, 70))
			{
				return (3);
			}
			if (inRangeOf(Convert.ToInt32(characterToBeTranslated), 71, 73))
			{
				return (4);
			}
			if (inRangeOf(Convert.ToInt32(characterToBeTranslated), 74, 76))
			{
				return (5);
			}
			if (inRangeOf(Convert.ToInt32(characterToBeTranslated), 77, 79))
			{
				return (6);
			}
			if (inRangeOf(Convert.ToInt32(characterToBeTranslated), 80, 83))
			{
				return (7);
			}
			if (inRangeOf(Convert.ToInt32(characterToBeTranslated), 84, 86))
			{
				return (8);
			}
			if (inRangeOf(Convert.ToInt32(characterToBeTranslated), 87, 90))
			{
				return (9);
			}
			System.Console.WriteLine("Nothing to be printed");
			return (null);

		}
		public static bool inRangeOf(int characterToBeTranslated, int lowerBound, int higherBound)
		{
			if (characterToBeTranslated >= lowerBound && characterToBeTranslated <= higherBound)
			{
				return (true);
			}
			else
			{
				return (false);
			}

		}
	}
}