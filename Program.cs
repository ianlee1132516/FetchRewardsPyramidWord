using System;
using System.Collections.Generic;
					
public class Program
{
	/// <summary>
	/// Determines whether a given word is a pyramid word.
	/// A word is a ‘pyramid’ word if the letters can be arranged in increasing frequency, 
	/// starting with 1 and continuing without gaps and without duplicates.
	/// </summary>
	/// <param name="word">The word for which to determine pyramid-ness</param>
	/// <returns>True if the word is a pyramid word, false otherwise</returns>
	public static bool isPyramidWord(string word)
	{
		bool isPyramidWord = false;
		// Must have at least one character to be a pyramid word
		if (!string.IsNullOrWhiteSpace(word))
		{
			// Case insensitive
			word = word.ToLower();
			
			// Bucket the letters and how often they appear in the word
			Dictionary<char, int> letterCounts = new Dictionary<char, int>();
			foreach (char letter in word.ToCharArray())
			{
				if (letterCounts.ContainsKey(letter))
				{
					letterCounts[letter] = letterCounts[letter] + 1;
				}
				else
				{
					letterCounts.Add(letter, 1);
				}
			}
			
			// Obtain and sort the counts of each letter
			List<int> counts = new List<int>();
			counts.AddRange(letterCounts.Values);
			counts.Sort();
			
			// Determine if letter counts begin at 1 and increment from there
			int expectedPyramidWordLetterCount = 1;
			isPyramidWord = true;
			for(int i = 0; i < counts.Count; i++)
			{
				if (counts[i] != expectedPyramidWordLetterCount)
				{
					isPyramidWord = false;
					break;
				}
				else
				{
					expectedPyramidWordLetterCount++;
				}
			}
		}
		return isPyramidWord;
	}
	
	public static void Main()
	{
		if (!isPyramidWord("banana"))
		{
			throw new Exception("banana is a pyramid word but the method says it isn't");
		}
		if (isPyramidWord("bandana"))
		{
			throw new Exception("bandana isn't a pyramid word but the method says it is");
		}
		Console.WriteLine("Happy New Year!");
	}
}
