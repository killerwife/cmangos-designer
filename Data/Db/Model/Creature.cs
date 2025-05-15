using System.ComponentModel.DataAnnotations;

namespace Data.Model.World
{
    public class Creature
    {
        [Key]
        public uint guid { get; set; }
        public uint id { get; set; }
        public uint map { get; set; }
        public decimal position_x { get; set; }
        public decimal position_y { get; set; }
        public decimal position_z { get; set; }
    }
}
