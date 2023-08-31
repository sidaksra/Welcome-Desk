/*
 * Name: Sidak Singh Sra (0689168), Ethan Abra (0701466), Marhella Abreu Rosario (0680538)
 * 
 * Group 11
 * 
 * Project: Creating a method to print the contents of dictionary (Key-value pairs)
 * 
 * Description: In this, the class PrintDictionaryClass is created to Print the contents of Dictionary, which we had stored in MainMenu.cs
 *				This Print is triggered, when the user choose (v) to view all the doctors list,which we have stored in Dictionary. 
 *				We have used an behavioural Design Pattern which is Iterator. 
 *				We have chose this pattern because it provides a common interface for browsing a collection of things in an aggregate object 
 *				without having to know its internal mechanism. 
 *  
 * Usage: This is used to print the key-value pairs of Dictionary. 
 * 
 * Data Structure Used: KeyValuePair: which is a fundamental data structure
 * 
 * Design Pattern Used: Behavioural Patterns => Interpreter
 * 
*/


using System;
using System.Collections;
using System.Collections.Generic;

namespace FinalProject
{
	public class PrintDictionaryClass
	{
		/*Design Pattern: Behavioural Pattern => Iterator*/
		public static void Print(Dictionary<string, string> torontoGeneral)				// Takes a string-string dictionary.
		{
			Aggregate aggregate = new Aggregate(torontoGeneral);						// Create a new aggregate.
			aggregate.ShowAll();														// Call the method to print all values.
		}
	}


	public class Aggregate : IEnumerable
	{
		private Dictionary<string, string> dict;				// This will be overwritten by the associated dictionary.

		public Aggregate(Dictionary<string, string> d)			// Constructor takes a dictionary
		{
			dict = d;											// Initialize the dictionary to dict
		}

		public IEnumerator GetEnumerator()						// Returns an IEnumerator with Iterator properties.
		{
			return new Iterator(this);							// Create a new iterator
		}

		public string this[string index] => dict[index];

		public int Count => dict.Count;							// Return the number of key-value pairs in the dictionary.

		public void ShowAll()									// Prints all contents
		{
			IEnumerator iterateAll = this.GetEnumerator();										// Creates an iterator
			Console.WriteLine();																// Skips a line

			foreach (KeyValuePair<string, string> author in dict)								// Iterate through the dictionary
			{
				Console.WriteLine("Doctor: {0}\t Detail: {1}", author.Key, author.Value);		// Print each key and value formatted.
			}
			
		}

	}

	public class Iterator : IEnumerator
	{
		private Aggregate ag;															// Associated aggregate.
		int pos;																		// Represents where the iterator is.

		object IEnumerator.Current => pos;												// Returns what is in the current position

		public Iterator(Aggregate agg)													// Initalizes with an aggregate.
		{
			ag = agg;																	// Overwrite the class's empty one.
		}

		public void Reset() { pos = 0; }												// Change the position to zero.

		public bool MoveNext()
		{
			pos++;																		// Moves the position up.
			return pos < ag.Count;														// Returns false if there are no more entries.
		}

	}
}