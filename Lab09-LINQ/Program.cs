using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Lab09_LINQ.Classes;

namespace Lab09_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            FeatureCollection myRoot = JsonConvert.DeserializeObject<FeatureCollection>(File.ReadAllText(@"..\..\..\..\data.json"));

            // Question 1
            var query = myRoot.features.Select(feature => feature.properties.neighborhood);

            Console.WriteLine($"Q1. Output all of the neighborhoods in this data list. Total: { query.Count() }");

            for (int i = 0; i < query.Count(); i++)
            {
                Console.WriteLine(query.ElementAt(i));
            }

            // Question 2
            var noempty = query.Where(neighborhood => !neighborhood.Equals(""));

            Console.WriteLine($"\nQ2. Filter out all the neighborhoods that do not have any names. Total: { noempty.Count() }");

            for (int i = 0; i < noempty.Count(); i++)
            {
                Console.WriteLine(noempty.ElementAt(i));
            }

            // Question 3
            var noduplicates = noempty.Select(neighborhood => neighborhood).Distinct();

            Console.WriteLine($"\nQ3. Filter out all duplicate neighborhoods. Total: { noduplicates.Count() }");

            for (int i = 0; i < noduplicates.Count(); i++)
            {
                Console.WriteLine(noduplicates.ElementAt(i));
            }

            // Question 4
            var combinedQuery = myRoot.features.Select(feature => feature.properties.neighborhood)
                                               .Where(neighborhood => !neighborhood.Equals(""))
                                               .Distinct();

            Console.WriteLine($"\nQ4. Rewrite the queries from above and consolidate all into one single query. Total: { combinedQuery.Count() }");

            for (int i = 0; i < combinedQuery.Count(); i++)
            {
                Console.WriteLine(combinedQuery.ElementAt(i));
            }

            // Question 5
            var alternateQuery = 
                (from feature in myRoot.features
                where !feature.properties.neighborhood.Equals("")
                select feature.properties.neighborhood)
                .Distinct();

            Console.WriteLine($"\nQ5. Rewrite at least one of these questions only using the opposing method. Total: { alternateQuery.Count() }");

            for (int i = 0; i < alternateQuery.Count(); i++)
            {
                Console.WriteLine(alternateQuery.ElementAt(i));
            }
        }
    }
}
