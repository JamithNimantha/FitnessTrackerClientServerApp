using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerClientApp.Utility
{
    public class Util
    {
        public Util() { }

        public static List<string> GetIntensityTypes()
        {
            var intensities = new List<string>();
            intensities.Add("Low");
            intensities.Add("Moderate");
            intensities.Add("High");
            intensities.Add("Intense");
            return intensities;
        }
    }
}
