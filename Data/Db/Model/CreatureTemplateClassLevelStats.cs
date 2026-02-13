using System.ComponentModel.DataAnnotations;

namespace Data.Db.Model
{
    public class CreatureTemplateClassLevelStats
    {
        [Key]
        public sbyte Level { get; set; }
        [Key]
        public sbyte Class { get; set; }
        public float BaseMeleeAttackPower { get; set; }
        public UInt16 BaseDamageExp0 { get; set; }
        public UInt16 BaseDamageExp1 { get; set; }
        public UInt16 BaseDamageExp0OLD { get; set; }
        public UInt16 BaseDamageExp1OLD { get; set; }
    }
}
