using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Db
{
    public class EventAIScript
    {
        public uint Id { get; set; }
        public uint Creature_id { get; set; }
        public uint Event_type { get; set; }
        public int Event_inverse_phase_mask { get; set; }
        public uint Event_chance { get; set; }
        public uint Event_flags { get; set; }
        public int Event_param1 { get; set; }
        public int Event_param2 { get; set; }
        public int Event_param3 { get; set; }
        public int Event_param4 { get; set; }
        public int Event_param5 { get; set; }
        public int Event_param6 { get; set; }
        public uint Action1_type { get; set; }
        public int Action1_param1 { get; set; }
        public int Action1_param2 { get; set; }
        public int Action1_param3 { get; set; }
        public uint Action2_type { get; set; }
        public int Action2_param1 { get; set; }
        public int Action2_param2 { get; set; }
        public int Action2_param3 { get; set; }
        public uint Action3_type { get; set; }
        public int Action3_param1 { get; set; }
        public int Action3_param2 { get; set; }
        public int Action3_param3 { get; set; }
        public string Comment { get; set; }
    }
}
