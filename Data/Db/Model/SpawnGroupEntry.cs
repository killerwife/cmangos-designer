using Microsoft.EntityFrameworkCore;

namespace Data.Model.World
{
    [PrimaryKey(nameof(Id), nameof(Entry))]
    public class SpawnGroupEntry
    {
        public int Id { get; set; }
        public int Entry {  get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public int Chance { get; set; }
    }
}
