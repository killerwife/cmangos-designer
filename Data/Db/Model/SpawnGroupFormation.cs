using Microsoft.EntityFrameworkCore;

namespace Data.Model.World
{
    [PrimaryKey(nameof(Id))]
    public class SpawnGroupFormation
    {
        public int Id { get; set; }
        public int PathId { get; set; }
    }
}
