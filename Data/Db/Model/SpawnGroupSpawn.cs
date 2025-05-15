using Microsoft.EntityFrameworkCore;

namespace Data.Model.World
{
    [PrimaryKey(nameof(Id), nameof(Guid))]
    public class SpawnGroupSpawn
    {
        public int Id { get; set; }
        public int Guid { get; set; }
        public sbyte SlotId { get; set; }
        public uint Chance { get; set; }
    }
}
