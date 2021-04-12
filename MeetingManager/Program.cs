using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MeetingManager
{
    class Program
    {   
        static void Main(string[] args)
        {
            TimeSpan meetingDuration = new TimeSpan(0, 30, 0);

            var calendar1 = new Calendar
            {
                
                WorkStart = DateTime.ParseExact("09:00", "HH:mm", CultureInfo.InvariantCulture),
                WorkEnd = DateTime.ParseExact("19:55", "HH:mm", CultureInfo.InvariantCulture),

                Meetings = new ObservableCollection<Meeting>
                {
                    new Meeting {
                        Id = 0,
                        Start = DateTime.ParseExact("09:00", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("10:30", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 1,
                        Start = DateTime.ParseExact("12:00", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("13:00", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 2,
                        Start = DateTime.ParseExact("16:00", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("18:00", "HH:mm", CultureInfo.InvariantCulture)
                        },
                }

            };

            var calendar2 = new Calendar
            {
                WorkStart = DateTime.ParseExact("10:00", "HH:mm", CultureInfo.InvariantCulture),
                WorkEnd = DateTime.ParseExact("18:30", "HH:mm", CultureInfo.InvariantCulture),

                Meetings = new ObservableCollection<Meeting>
                {
                    new Meeting {
                        Id = 0,
                        Start = DateTime.ParseExact("10:00", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("11:30", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 1,
                        Start = DateTime.ParseExact("12:30", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("14:30", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 2,
                        Start = DateTime.ParseExact("14:30", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("15:00", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 3,
                        Start = DateTime.ParseExact("16:00", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("17:00", "HH:mm", CultureInfo.InvariantCulture)
                        },
                }

            };

            var scheduleOfMeetings = new ScheduleOfMeetings();

            Console.WriteLine(scheduleOfMeetings.GetPossibleDatesOfMeetings(calendar1, calendar2, meetingDuration));

        }
    }
}

