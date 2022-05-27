using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Db
{
    public class EventAIScript
    {
        public int Id { get; set; }
        public int CreatureId { get; set; }
        public int Event { get; set; }
        public string Comment { get; set; }
    }
}
