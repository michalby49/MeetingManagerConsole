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
        static TimeSpan oneMinute = new TimeSpan(0, 1, 0);
        static TimeSpan meetingDuration = new TimeSpan(0, 30, 0);

        private static List<DateTime> FreeTimeCounter(Calendar calendar)
        {
            var freeTime = new List<DateTime>();


            calendar.FreeTime = new List<DateTime>();

            if (calendar.Meetings.First(x => x.Id == 0).Start - calendar.WorkStart >= meetingDuration)
            {
                var timeBetween = calendar.WorkStart;
                while (timeBetween <= calendar.Meetings.First(x => x.Id == 0).Start)
                {
                    freeTime.Add(timeBetween);
                    timeBetween += oneMinute;
                }
            }
            for (int i = 0; i < calendar.Meetings.Count() - 1; i++)
            {

                if (calendar.Meetings.First(x => x.Id == i + 1).Start - calendar.Meetings.First(x => x.Id == i).End >= meetingDuration)
                {
                    var timeBetween = calendar.Meetings.First(x => x.Id == i).End;
                    while (timeBetween <= calendar.Meetings.First(x => x.Id == i + 1).Start)
                    {
                        freeTime.Add(timeBetween);
                        timeBetween += oneMinute;
                    }
                }
            }
            if (calendar.WorkEnd - calendar.Meetings.Last().End >= meetingDuration)
            {
                var timeBetween = calendar.Meetings.Last().End;
                while (timeBetween <= calendar.WorkEnd)
                {
                    freeTime.Add(timeBetween);
                    timeBetween += oneMinute;
                }
            }

            return freeTime;
        }
        static void Main(string[] args)
        {

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

            calendar1.FreeTime = new List<DateTime>();
            calendar2.FreeTime = new List<DateTime>();

            calendar1.FreeTime = FreeTimeCounter(calendar1);
            calendar2.FreeTime = FreeTimeCounter(calendar2);

            var freeTime = new List<DateTime>();

            foreach (var aFreeTime1 in calendar1.FreeTime)
            {
                foreach (var aFreeTime2 in calendar2.FreeTime)
                {
                    if (aFreeTime1 == aFreeTime2)
                    {
                        freeTime.Add(aFreeTime2);
                    }
                }
            }

            var tablica = freeTime.ToArray();

            Console.Write(tablica[0].ToString("HH:mm") + "-");
            for (int i = 1; i < tablica.Length; i++)
            {
                if (!(tablica[i] - oneMinute == tablica[i - 1]))
                {
                    Console.WriteLine(tablica[i - 1].ToString("HH:mm"));
                    Console.Write(tablica[i].ToString("HH:mm") + "-");
                }
            }
            Console.WriteLine(tablica[tablica.Length - 1].ToString("HH:mm"));

        }
    }
}

