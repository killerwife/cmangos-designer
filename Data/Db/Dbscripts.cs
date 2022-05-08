namespace Data
{
    public class Dbscripts
    {
        public ushort Id { get; set; }
        public uint Delay { get; set; } 
        public uint Priority { get; set; }
        public ushort Command { get; set; }
        public uint Datalong { get; set; }
        public uint Datalong2 { get; set; }
        public uint Datalong3 { get; set; }
        public ushort Buddy_entry { get; set; }
        public ushort Search_radius { get; set; }
        public uint Data_Flags { get; set; }
        public int Dataint { get; set; }
        public int Dataint2 { get; set; }
        public int Dataint3 { get; set; }
        public int Dataint4 { get; set; }
        public float Datafloat { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float O { get; set; }
        public float Speed { get; set; }
        public ushort Condition_id { get; set; }
        public string? Comments { get; set; }
    }
}