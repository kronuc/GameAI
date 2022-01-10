using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.Game.Models
{
    public class TickEvent
    {
        public int Tick { get; set; }
        public string Target { get; set; }
        public TickEventType Type { get; set; }
        public double Value { get; set; }
    }

    public enum TickEventType
    {
        Heal,
        Hit
    }
}
