using System.ComponentModel.DataAnnotations;

namespace Data.Model.World
{
    public class CreatureTemplate
    {
        [Key]
        public uint Entry { get; set; }
        public string Name { get; set; } = string.Empty;
        public sbyte MinLevel { get; set; }
        public sbyte UnitClass { get; set; }
        public sbyte Expansion { get; set; }
        public float DamageMultiplier { get; set; }
        public float DamageVariance { get; set; }
        public uint MeleeBaseAttackTime { get; set; }
    }
}
