using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmangos_designer.Helpers
{
    public class PositionHelpers
    {
        public static bool FloatComparison(double x, double y, double precision)
        {
            return Math.Abs(x - y) < precision;
        }

        public static bool FloatComparison(decimal x, string y, decimal precision)
        {
            return Math.Abs(x - decimal.Parse(y)) < precision;
        }

        public static double NormalizeOrientation(double originalOri)
        {
            if (originalOri > Math.PI) // later expansions used 0-2PI interval, whereas earlier used -PI-PI interval
                return (originalOri - 2 * Math.PI);

            return originalOri;
        }

        public static double DeNormalizeOrientation(double originalOri)
        {
            if (originalOri < 0) // later expansions used 0-2PI interval, whereas earlier used -PI-PI interval
                return (originalOri + 2 * Math.PI);

            return originalOri;
        }
    }
}
