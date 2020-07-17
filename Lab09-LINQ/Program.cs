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
            //--SPECIFICATIONS--
            //Each query builds off of the prior query. You should be chaining.

            //Output all of the neighborhoods in this data list(Final Total: 147 neighborhoods)
            //Filter out all the neighborhoods that do not have any names(Final Total: 143)
            //Remove the duplicates(Final Total: 39 neighborhoods)
            //Rewrite the queries from above and consolidate all into one single query.
            //Rewrite at least one of these questions only using the opposing method (example: Use LINQ Query statements instead of LINQ method calls and vice versa.)

            //You should have a total of 5 outputs.

            //--SUGGESTIONS--
            //Use LINQ queries and Lambda statements(when appropriate) to find the answers.
            //Use a combination of both to answer the questions.
            //Explore the NuGet packages and install NewtonSoftJson
            //Do some self research and find out how to read in JSON file(hint: JsonConvert.DeserializedOject is part of it)
            //You will need to break up each section of the JSON file up into different classes, use your resources - ask the TA’s if your stuck. (Maybe find a converter of some sort ??)

            // ATTRIBUTIONS:
            // https://json2csharp.com
            // https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
            // https://www.newtonsoft.com/json/help/html/ReadJson.htm

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
