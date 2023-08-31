/*
 * Name: Ethan Abra (0701466), Sidak Singh Sra (0689168), Marhella Abreu Rosario (0680538)
 * 
 * Group 11
 * 
 * Description: This is used to book the appointment with the doctor which is stores in our directory using particular key which is passed by the user.
 *              
 * Data Structure used: Queues
 * 
 * Design Pattern: Creational Design Pattern - > Singleton (because booking appointment is unique)
 *  
 * Usage: To book the appointment with the doctor 
 * 
*/




using System;
using System.Collections;
using System.Collections.Generic;


namespace FinalProject {
    public class Handler
    {                                                                                               // This class will be instanced to handle everything else in this file.
        private ArrayList confCode = new ArrayList();                                               // Holds the numbers assigned to names with booking
        private ArrayList docQueues = new ArrayList();                                              // Holds all of the doctor queues.
        private Dictionary<string, object> currentDict = new Dictionary<string, object>();          // Holds the current dictionary of queues and names.
        private Dictionary<string, string> handlingDictionary = new Dictionary<string, string>();
        public Handler(Dictionary<string, string> handlingDict) { 
            handlingDictionary = handlingDict;
            Dictionary<string, object> dict = new Dictionary<string, object>();                     // Defines the dictionary that we'll return
            DoctorQueue dummy = new DoctorQueue();                                                  // Does not appear in the arraylist, just exists to be cloned.
            DoctorQueue[] temp = new DoctorQueue[handlingDict.Count];                                                       // Create a temporary arraylist.
            int i = 0;                                                                              // Create an iterator.
            foreach (KeyValuePair<string, string> item in handlingDict)
            {
                temp[i] = new DoctorQueue();                                                       // Add the queue to the list of queues.
                currentDict.Add(item.Key, temp[i]);                                               // Add an entry to the dictionary.
                i++;                                                                               // Increase the iterator.
            }

        }

        public Dictionary<string, object> GetCurrentDictionary()                               // Public getter for the dictionary.
        {
            return currentDict;                                                                     // Return the dictionary.
        }

        public Object GetDoc(string docName)                                                        // Gets the queue for that doctor.
        {
            if (currentDict.GetValueOrDefault(docName) != null)                                     // Makes sure the value isn't null.
                return currentDict.GetValueOrDefault(docName);                                      // Returns the value if so.
            else throw new Exception();                                                             // This will be caught by the caller.
        }

        public int GenerateConf(string name, DoctorQueue doc)                                       // Generates a confirmation code and enqueues.
        {
            int size = confCode.Count;                                                              // Save the size of the arraylist before operating.
            confCode.Add(name);                                                                     // Add the current name.
            doc.Book(size, name);                                                                         // Book with the size as the identifier.
            return size;                                                                            // Give the size of the arraylist as a confirmation code.
        }

        public string GetName(int confirm)                                                          // Input the confirmation code to get the name on the doctor's end.
        {
            return (string)confCode[confirm];                                                               // Return the integer's place in the arraylist.
        }

    }

    public class DoctorQueue
    {
        public DoctorQueue() { }                                                                    // Default constructor.
        private Queue<int> list = new Queue<int>();                                                                    // List of patients, shown sequentially.

        public DoctorQueue Clone()                                                                  // Method to clone, used by the iterator.
        {
            return (DoctorQueue)MemberwiseClone();                                                  // Return a clone of the instance this method was called on.
        }

        public string GetNext(Handler h)                                                            // Used by the doctor to see who their next patient is.
        {
            int number = list.Dequeue();                                                            // Take the confirmation code from the front of the queue
            return h.GetName(number);                                                               // Call the handler and return the name.
        }

        public void Book(int confirmation, string name)                                                          // Booking asks for the confirmation number, generated by the handler.
        {
            Console.WriteLine( name +", your appointment with doctor has been confirmed");
            list.Enqueue(confirmation);                                                             // Enqueue the number passed to the method.
        }
    }
}