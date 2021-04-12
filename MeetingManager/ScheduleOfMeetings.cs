using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManager
{
    public class ScheduleOfMeetings
    {
        static TimeSpan oneMinute = new TimeSpan(0, 1, 0);
        public string GetPossibleDatesOfMeetings(Calendar calendar1, Calendar calendar2, TimeSpan meetingDuration)
        {

            var calendar1AvailableTime = FreeTimeCounter(calendar1, meetingDuration);
            var calendar2AvailableTime = FreeTimeCounter(calendar2, meetingDuration);

            var availableTime = new List<DateTime>();

            //Znajdowanie wspólnych przerw między spotkaniami
            foreach (var availableTime1 in calendar1AvailableTime)
            {
                foreach (var availableTime2 in calendar2AvailableTime)
                {
                    if (availableTime1 == availableTime2)
                    {
                        availableTime.Add(availableTime1);
                    }
                }
            }


            var tablica = availableTime.ToArray();
            var correctTime = $"[[{tablica[0].ToString("HH:mm")}, ";
            for (int i = 1; i < tablica.Length; i++)
            {
                if (!(tablica[i] - oneMinute == tablica[i - 1]))
                {
                    correctTime += $"{ tablica[i - 1].ToString("HH:mm")}], ";
                    correctTime += $"[{ tablica[i].ToString("HH:mm")}, ";
                }
            }
            
            correctTime += $"{ tablica[tablica.Length - 1].ToString("HH:mm")}]]";

            return correctTime;
        }

        //Znajdowanie przerw między spotkaniami 
        private List<DateTime> FreeTimeCounter(Calendar calendar, TimeSpan meetingDuration)
        {
            var freeTime = new List<DateTime>();

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
                while (timeBetween<= calendar.WorkEnd)
                {
                    freeTime.Add(timeBetween);
                    timeBetween += oneMinute;
                }
            }

            return freeTime;
        }
    }
}
