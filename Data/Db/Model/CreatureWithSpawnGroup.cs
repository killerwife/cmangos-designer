namespace Data.Model.World
{
    public class CreatureWithSpawnGroup
    {
        public uint guid { get; set; }
        public uint id { get; set; }
        public uint map { get; set; }
        public decimal position_x { get; set; }
        public decimal position_y { get; set; }
        public decimal position_z { get; set; }
        public int? spawn_group_id { get; set; }

        public CreatureWithSpawnGroup()
        {

        }

        public CreatureWithSpawnGroup(Creature go)
        {
            guid = go.guid;
            id = go.id;
            map = go.map;
            position_x = go.position_x;
            position_y = go.position_y;
            position_z = go.position_z;
        }
    }
}
