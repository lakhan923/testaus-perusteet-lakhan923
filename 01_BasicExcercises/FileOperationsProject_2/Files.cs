using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationsProject_2
{
    public class Files
    {
        /// <summary>
        /// the below method take a List<string> as a parameter 
        /// and prints each item in the list to the console.
        /// </summary>
        public static void PrintFile(List<string> systemConfig)
        {
            foreach (string item in systemConfig)
            {
                Console.WriteLine(item);
            }
        }


        /// <summary>
        /// the below method reads the contents of a text file located at a specified directory 
        /// and file path.The file's content is read line by line and added to a List<string>
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="directory"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> ReadFile(List<string> fileContent, string directory, string filePath)
        {

            StreamReader reader = new StreamReader(directory + filePath);
            try
            {
                do
                {
                    fileContent.Add(reader.ReadLine());
                }
                while (reader.Peek() != -1);
            }
            catch (FileNotFoundException e)
            {
                throw;
            }

            finally
            {
                reader.Close();
            }
            return fileContent;
        }


    }
}






