using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Db
{
    public class Creature
    {
        public int Guid { get; set; }
        public int Id { get; set; }
        public int Map { get; set; }
        public int SpawnMask { get; set; }
        public int PhaseMask { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Orientation { get; set; }
        public int SpawnTimeSecsMin { get; set; }
        public int SpawnTimeSecsMax { get; set; }
        public float SpawnDist { get; set; }
        public int MovementType { get; set; }

        public string GenerateSQL(bool phaseMask)
        {
            string output = "(" + Guid + "," + Id + "," + Map + "," + SpawnMask + (phaseMask ? ("," + PhaseMask) : "") + "," + PositionX.ToString(CultureInfo.InvariantCulture) + "," + PositionY.ToString(CultureInfo.InvariantCulture) + "," + PositionZ.ToString(CultureInfo.InvariantCulture) + "," + Orientation.ToString(CultureInfo.InvariantCulture) + "," + SpawnTimeSecsMin + "," + SpawnTimeSecsMax + "," + SpawnDist + "," + MovementType + ")";
            return output;
        }
    }
}
