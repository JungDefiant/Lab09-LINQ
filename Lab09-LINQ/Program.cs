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
            //Rewrite at least one of these questions only using the opposing method(example: Use LINQ Query statements instead of LINQ method calls and vice versa.)

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

            var query = myRoot.features.Select(feature => feature.properties.neighborhood);

            Console.WriteLine($"Q1. Output all of the neighborhoods in this data list. Total: { query.Count() }");

            for (int i = 0; i < query.Count(); i++)
            {
                Console.WriteLine(query.ElementAt(i));
            }

            var noempty = query.Where(neighborhood => !neighborhood.Equals(""))
                               .Select(neighborhood => neighborhood);

            Console.WriteLine($"\nFilter out all the neighborhoods that do not have any names. Total: { noempty.Count() }");

            for (int i = 0; i < noempty.Count(); i++)
            {
                Console.WriteLine(noempty.ElementAt(i));
            }

            var noempty = query.Where(neighborhood => !neighborhood.Equals(""))
                               .Select(neighborhood => neighborhood);

            Console.WriteLine($"\nFilter out all the neighborhoods that do not have any names. Total: { noempty.Count() }");

            for (int i = 0; i < noempty.Count(); i++)
            {
                Console.WriteLine(noempty.ElementAt(i));
            }
        }
    }
}
