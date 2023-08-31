/*
*   Main Program
* 
*   Name: Sidak Singh Sra (0689168), Ethan Abra (0701466), Marhella Abreu Rosario (0680538)
*  
*   Group 11
*
*   Project: Menu Interface and creating the dictionary
*
*   Description: Provides an interface for the menu selection before searching for the contents in dictionary.
*             We have used Facade design pattern to make it easier to access functionality in subsystems that are complicated. 
*             The facade class offers a basic, single-class interface that hides the underlying code's implementation details.
*             Each class has a method that is executed from within the single facade method, and the results are supplied to the 
*             subsystem's other methods.
*
*   Data Structure used: Dictionary and HashTable
*
*   What we implemented: Menu Items is added to the concolse using hashtables. Whereas, Dictionary is used to add the details of each doctor (using key-value pairs for both)
*
*   Design Pattern Used: Structural Design Pattern => Facade
*
*   Usage: To load the appropriate method after the user defines what they want to do.
*
*/
using System;
using System.Collections;


namespace FinalProject
{
    // 'MainMenu' is where Main() will be stored, and thus what will actually be run.
    class MainMenu     
    {
        // This is where all the code will be run from.
        public static void Main()                                             
        {
            Facade facade = new Facade();    // Defines a facade, which contains the navigation tools and messages.
            facade.PerformAction();          // Calls both of facade's functions in one go.

        }
    }
    public class Facade
    {
        public void PerformAction()
        {
            //Creating a dictionary = > using a dictionary DS -> A dictionary is a data structure that will store the data of doctor as a key–value pair.
            Dictionary<string, string> torontoGeneral = new Dictionary<string, string>();


            CreateDictionary AddDictionaryClass = new CreateDictionary();                            // Defines a class 'CreateDictionary'
            Welcome WelcomeClass = new Welcome();                                                    // Defines a variable of type 'Welcome'
            SelectCommand CommandClass = new SelectCommand();                                        // This variable acts as the caller for the facade function.
            
            AddDictionaryClass.AddDictionary(torontoGeneral);                                        // Call the AddDictionary to add contents to Dictionary torontoGeneral

            Handler h = new Handler(torontoGeneral);                                                 // Declare a handler for the hospital.

            WelcomeClass.WelcomeDesk();                                                              // Call WelcomeDesk() to print the welcome message
            CommandClass.CommandDesk(torontoGeneral, h);                                             // Call CommandDesk() to make a selection
        }
    }

    //Class: CreateDictionary -> It will add the doctor details as a key-value pair in dictionary DS
    public class CreateDictionary
    {
        //Using Dictionary DS
        public void AddDictionary(Dictionary<string, string> torontoGeneral)
        {
            //Adding each data about the doctor in dictionary (this will stores in sequence as we have defined)
            torontoGeneral.Add("kosalka", "Dr. Ted Kosalka, Gynacology & Obstetrics, Room:54, 5th Floor, East - ext: 89765");
            torontoGeneral.Add("moore", "Dr. Mandy Moore, Neurology, Room: 112, 7th Floor, West - ext: 39203");
            torontoGeneral.Add("perkins", "Dr. Pierce Perkins, Plastics, Room:87 5th Floor, East - ext: 64536");
            torontoGeneral.Add("jones", "Dr. Jim Jones, Ortho Clinics, Room: 108, 7th Floor, West - ext: 09873");
            
        }
    }
    // Stores the welcome message, and prints when requested.
    public class Welcome                                                                    
    {
        // A function that prints the welcome message
        public void WelcomeDesk()                                                          
        {
           
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("Welcome to Toronto General Hospital Automated Desk Area");
            Console.WriteLine("--------------------------------------------------------------\n");
            Console.WriteLine("\n\t----------SERVICES----------");


            //Using HashTable DS: This will provide fast inertion
            //Creating a hashtable with default Capacity
            Hashtable hashtable = new Hashtable();

            //Adding key-value pairs to hashtable. Storing Key-Value pairs, where the hash code produced from the key is used to store the data
            hashtable.Add("\tPress (S)", "Search Doctor");
            hashtable.Add("\tPress (V)", "View All Doctors List");
            hashtable.Add("\tPress (B)", "Book Appointment with the doctor");
            hashtable.Add("\tPress (Q)", "To Exit the Automated Desk Area");

            //retriving a value based on key: Printing the Key-value pairs on the console.
            foreach (Object key in hashtable.Keys)
            {
                Console.WriteLine(key.ToString() + ": " + hashtable[key].ToString());
            }
            Console.WriteLine("\t-----------------------------");
        }
    }

    //Object type for selection variables.
    public class SelectCommand                                                              
    {
        //This is where the selection will be made.(passing the Dictionary torontoGeneral)
        public int CommandDesk(Dictionary<string, string> torontoGeneral, Handler h)                   
        {
            bool validInput = true;
            //using the while loop (it will run)
            while (validInput)
            {

                Console.Write("\r\nPlease Select Your Service: ");
                string choose = Console.ReadLine();                                                             // Take a string to compare.
                choose = choose.ToLower();                                                                      // Convert the string to a lowercase letter (If the user enters an uppercase "Q", they probably still intend to quit the program)

                if (choose != "q")                                                                              // Checks first if the user wants to quit the program.
                {
                    switch (choose)                                                                             // A switch statement for each possible input.
                    {
                        case "s":                                                                               // If the number entered is equal to the String "s"
                            SearchDictionaryClass.SearchDic(torontoGeneral);
                            break;                                                                              // Exit the switch statement (answer has been found)
                        case "v":                                                                               // To be executed if "v" is entered.
                            PrintDictionaryClass.Print(torontoGeneral);
                            break;                                                                              
                        case "b":
                            Console.Write("Enter doctor's name: ");
                            DoctorQueue d;
                            try
                            {
                                d = (DoctorQueue)h.GetDoc(Console.ReadLine());                                  // Get the doctor's queue based on user input.
                                Console.Write("Enter your name: ");                                             // Prompt user for name.
                                int confirm = h.GenerateConf(Console.ReadLine(), d);                            // The confirmation adds the user to the list, and spits out a number.
                                Console.WriteLine("Confirmation code: {0}", confirm);                           // The number is relayed back to the user.
                            } catch (Exception e) {                                                             // Triggers if the doctor can't be found.

                                Console.WriteLine("Doctor Name not recognized. Please Check the spelling and try again.");    // Skip the name prompt, tell the user to try again.
                            }
                            
                            break;
                        default:
                            Console.WriteLine("You Have entered a wrong input! Please enter a valid input");    // If the user tries anything other than. It will again run, as we have used the while loop 
                            break;                                                                              // Exit the switch statement (answer has been found)
                    }
                }
                //if the user entered the q (to exit)
                else
                {
                    Console.WriteLine("\n--------------------------------------------------");
                    Console.WriteLine("\tThank You for using our service!");
                    Console.WriteLine("\tHave a nice day!");
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("\tExiting Welcome Desk Area");
                    Console.WriteLine("--------------------------------------------------");
                    Thread.Sleep(1900);                                                                         // Wait for around 2 seconds (using thread)
                    Environment.Exit(0);                                                                        // Exit the program.

                }
            }
            return 0;
        }
    }

}

