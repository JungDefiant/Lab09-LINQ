using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09_LINQ.Classes
{
    /// <summary>
    /// Class for storing the root forr data.json object
    /// </summary>
    internal class FeatureCollection
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
}
