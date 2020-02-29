/* Uken-QAEngineerChallenge1
 * Name: Frank Yang
 */ 
using System;
using System.Collections.Generic;
using System.IO;

namespace csharpchallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = Directory.GetCurrentDirectory(); //Get the relative path
            foreach (string fileName in Directory.GetFiles(path, "*.txt"))//Use loop to read all required files
            {
                /* Create a dictionary to store number as a key, the repeated time as a value
                 * If the key is already existed, increase the value
                 * No need to parse all number into int, becasue no need to compare the num if the repeated times are all different
                 */
                Dictionary<String, int> textDict = new Dictionary<String, int>();
                foreach (var line in File.ReadLines(fileName))
                {
                    if (!textDict.ContainsKey(line))
                    {
                        textDict.Add(line, 1);
                    }
                    else
                    {
                        textDict[line]++;
                    }
                }

                int repeatedTime = 0;
                String textNum = "";

                /* Compare the repeated time and put the least repeated time into "repeatedTime"
                 * If there exists equal repeated time, parse the num into int and compare them. Put the smaller number into "textNum"
                 */
                foreach (var pair in textDict)
                {
                    if (repeatedTime == 0 || pair.Value < repeatedTime)
                    {
                        repeatedTime = pair.Value;
                        textNum = pair.Key;
                    }
                    if (pair.Value == repeatedTime)
                    {
                        if (int.Parse(pair.Key) < int.Parse(textNum))
                        {
                            textNum = pair.Key;
                        }
                    }
                }
                Console.WriteLine("File: " + Path.GetFileName(fileName) +","+ "Number: " + textNum+","+ "Repeated: " + repeatedTime +"times");
            }

            Console.ReadKey();
        }
    }
}
