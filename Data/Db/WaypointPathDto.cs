using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Db
{
    public class WaypointPathDto
    {
        public int PathId { get; set; }
        public int Point { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Orientation { get; set; }
        public int WaitTime { get; set; }
        public int ScriptId { get; set; }
        public string Comment { get; set; }

        public string GenerateSQL()
        {
            return "(" + PathId + "," + Point + "," + PositionX.ToString(CultureInfo.InvariantCulture) + "," + PositionY.ToString(CultureInfo.InvariantCulture) + "," + PositionZ.ToString(CultureInfo.InvariantCulture) + "," + Orientation.ToString(CultureInfo.InvariantCulture) + "," + WaitTime + "," + ScriptId + "," + Comment + ")";
        }
    }
}
