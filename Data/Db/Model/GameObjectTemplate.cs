using System.ComponentModel.DataAnnotations;

namespace Data.Model.World
{
    public class GameObjectTemplate
    {
        [Key]
        public uint Entry { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
