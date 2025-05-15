using System.ComponentModel.DataAnnotations;

namespace Data.Model.World
{
    public class GameObject
    {
        [Key]
        public uint guid { get; set; }
        public uint id { get; set; }
        public uint map { get; set; }
        public decimal position_x { get; set; }
        public decimal position_y { get; set; }
        public decimal position_z { get; set; }
        public decimal orientation { get; set; }
        public decimal rotation0 { get; set; }
        public decimal rotation1 { get; set; }
        public decimal rotation2 { get; set; }
        public decimal rotation3 { get; set; }
    }
}
