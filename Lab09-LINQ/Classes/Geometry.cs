using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09_LINQ.Classes
{
    /// <summary>
    /// Class for storing geometry object of data.json
    /// </summary>
    internal class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }

    }
}
