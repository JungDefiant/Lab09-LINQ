using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09_LINQ.Classes
{
    /// <summary>
    /// Class for storing feature object of data.json
    /// </summary>
    internal class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }

    }
}
