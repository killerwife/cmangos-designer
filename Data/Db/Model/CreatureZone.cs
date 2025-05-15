using System.ComponentModel.DataAnnotations;

namespace Data.Model.World
{
    public class CreatureZone
    {
        [Key]
        public uint Guid { get; set; }
        public uint ZoneId { get; set; }
        public uint AreaId { get; set; }
    }
}
