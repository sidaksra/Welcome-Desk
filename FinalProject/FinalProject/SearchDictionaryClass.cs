/*
 * Name: Ethan Abra (0701466), Sidak Singh Sra (0689168), Marhella Abreu Rosario (0680538)
 * 
 * Group 11
 * 
 * Description: This is used to Search the value of dictionary using particular key which is passed by the user.
 *              
 * Dictionary DS
 *  
 * Usage: To search the value of a key entered by the user in MainMenu.cs
 * 
 * Simple Class
*/



using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    //internal class to search the dictionary values 
    internal class SearchDictionaryClass
    {
        //Param: Dictionary of torontoGeneral
        public static void SearchDic(Dictionary<string, string> torontoGeneral)
        {
            //Prompt the user to enter doctor name that he want to get the details about phn, location, office
            Console.Write("\n\tPlease Enter the Doctor Name: ");
            string searchDirectory = Console.ReadLine().ToLower();


            //If string searchDirectory(key) entered by the user contains in the dictionary torontoGeneral , it will print the value of that key 
            if (torontoGeneral.ContainsKey(searchDirectory))
            {
                //it's value is stored in value variable
                string value = torontoGeneral[searchDirectory];
                //printing
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine("\t" + value);
                Console.WriteLine("-----------------------------------------------------------------------------------------------");

            }
            //if dictionary does not contain the key entered by the user
            else
            {
                Console.WriteLine("Sorry we could not find what you are looking for! Please check again");
            }

        }
    }
}
