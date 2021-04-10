using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManager
{
    class Calendar
    {
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public List<DateTime> FreeTime { get; set; }

        public IEnumerable<Meeting> Meetings { get; set; }
    }
}
