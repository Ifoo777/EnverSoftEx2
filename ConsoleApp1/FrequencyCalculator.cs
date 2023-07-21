using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVProgram
{
    
    // The FrequencyCalculator class contains methods for calculating frequency and sorting names.
    public static class FrequencyCalculator
    {
        public static Dictionary<string, int> CalculateFrequencies(List<(string Name, string Address)> data, Func<string, string> extractNameFunc)
        {
            var frequencies = new Dictionary<string, int>();
            // Iterate over each item in the data list
            foreach (var item in data)
            {
                // Extract the name using the provided extractNameFunc
                var name = extractNameFunc(item.Name);
                
                // If the name already exists in the frequencies dictionary, increment its count
                if (frequencies.ContainsKey(name))
                    frequencies[name]++;
                else
                    frequencies[name] = 1;
            }

            return frequencies;
        }
        // This method sorts the frequencies dictionary by descending frequency and ascending name.
        // It returns an IEnumerable of strings in the format "name, frequency".
        public static IEnumerable<string> SortByNameAndFrequency(Dictionary<string, int> frequencies)
        {
            return frequencies.OrderByDescending(entry => entry.Value)
                             .ThenBy(entry => entry.Key)
                             .Select(entry => $"{entry.Key}, {entry.Value}");
        }
    }
}
