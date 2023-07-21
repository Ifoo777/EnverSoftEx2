using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CSVProgram

{
    class Program
    {
        static void Main(string[] args)
        {
            //Provide the path to your csv file
            string csvFilePath = "C:/Users/Irfaan Osman/source/repos/ConsoleApp1/ConsoleApp1/Data.csv";

            if (!File.Exists(csvFilePath))
            {
                // If the CSV file doesn't exist, show an error message and return.
                Console.WriteLine($"CSV file not found at '{csvFilePath}'");
                return;
            }
            try
            {
                // Read the CSV file and retrieve the data as a list of (name, address) tuples.
                var csvData = ReadCSVFile(csvFilePath);

                // Calculate the frequencies of first names and last names using the FrequencyCalculator class.
                var firstNameFrequencies = FrequencyCalculator.CalculateFrequencies(csvData, name => name.Split(' ').First());
                var lastNameFrequencies = FrequencyCalculator.CalculateFrequencies(csvData, name => name.Split(' ').Last());

                // Sort the first name frequencies by decsending frequency and acsending name
                var sortedFirstNames = FrequencyCalculator.SortByNameAndFrequency(firstNameFrequencies);

                //Step4: Sort the last name frequencies by decsending frequency and acsending name
                var sortedLastName = FrequencyCalculator.SortByNameAndFrequency(lastNameFrequencies);

                //Step5:Save the sorted first name frequencies to a text file
                SaveToFile("FirstNameFrequecies.txt", sortedFirstNames);

                //Step6: Save the last name frequencies to a text file
                SaveToFile("LastNameFrequencies.txt", sortedLastName);

                //Step7: Sort the addresses alphabetically by street name
                var addresses = csvData.Select(row => row.Address).OrderBy(address => address);

                //Step8: Save the sorted addresses to a text file
                SaveToFile("SortedAddresses.txt", addresses);


            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message.
                Console.WriteLine($"An Error occurred: {ex.Message}");
            }
        }

        // Read the CSV file and retrieve the data
        static List<(string Name , string Address)> ReadCSVFile(string filepath)
        {
            var csvData = new List<(string Name , string Address)> ();

            using (var reader = new StreamReader(filepath))
            {
                //Skip the reader line
                reader.ReadLine();

                //Read each line of the CSV File 
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var name = values[0].Trim();
                    var address = values[1].Trim();

                    //Store the name and address to the csv file list

                    csvData.Add((name, address));

                }

            }
            return csvData;

        }

        // Save the lines to a text file
        static void SaveToFile(string filePath , IEnumerable<string> lines) 
        { 
            File.WriteAllLines(filePath, lines);
        }
    }
}