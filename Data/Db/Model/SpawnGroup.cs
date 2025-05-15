using System.ComponentModel.DataAnnotations;

namespace Data.Model.World
{
    public class SpawnGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Type { get; set; }
    }
}
