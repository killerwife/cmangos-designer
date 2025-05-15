namespace Data.Model.World
{
    public class CreaturePredictData
    {
        public string Name { get; set; } = string.Empty;
        public uint Entry { get; set; }
        public uint? Map { get; set; }
        public decimal? Position_x { get; set; }
        public decimal? Position_y { get; set; }
    }
}
