using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetingManager;
using System;
using System.Globalization;
using System.Collections.ObjectModel;
using Calendar = MeetingManager.Calendar;

namespace MeetingManagerUnitTest
{
    [TestClass]
    public class MeetingManagerTest
    {


        // Test na innym przyk³adzie
        [TestMethod]
        public void TestScheduleOfMeetings()
        {
            TimeSpan meetingDuration = new TimeSpan(0, 30, 0);

            var calendar1 = new Calendar
            {
                WorkStart = DateTime.ParseExact("08:00", "HH:mm", CultureInfo.InvariantCulture),
                WorkEnd = DateTime.ParseExact("18:00", "HH:mm", CultureInfo.InvariantCulture),

                Meetings = new ObservableCollection<Meeting>
                {
                    new Meeting {
                        Id = 0,
                        Start = DateTime.ParseExact("10:00", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("10:30", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 1,
                        Start = DateTime.ParseExact("11:00", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("12:00", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 2,
                        Start = DateTime.ParseExact("12:30", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("15:00", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 3,
                        Start = DateTime.ParseExact("15:00", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("17:30", "HH:mm", CultureInfo.InvariantCulture)
                        },
                }

            };

            var calendar2 = new Calendar
            {
                WorkStart = DateTime.ParseExact("09:00", "HH:mm", CultureInfo.InvariantCulture),
                WorkEnd = DateTime.ParseExact("18:00", "HH:mm", CultureInfo.InvariantCulture),

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
                        End = DateTime.ParseExact("14:00", "HH:mm", CultureInfo.InvariantCulture)
                        },
                    new Meeting {
                        Id = 2,
                        Start = DateTime.ParseExact("14:30", "HH:mm", CultureInfo.InvariantCulture),
                        End = DateTime.ParseExact("15:00", "HH:mm", CultureInfo.InvariantCulture)
                        },
                }

            };

            var scheduleOfMeetings = new ScheduleOfMeetings();

            Assert.AreEqual("[[09:00, 10:00], [12:00, 12:30], [17:30, 18:00]]", scheduleOfMeetings.GetPossibleDatesOfMeetings(calendar1, calendar2, meetingDuration));
            Console.WriteLine(scheduleOfMeetings.GetPossibleDatesOfMeetings(calendar1, calendar2, meetingDuration));


        }
    }
}
