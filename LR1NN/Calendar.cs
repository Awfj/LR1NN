﻿using System.Globalization;

namespace LR1NN
{
    public class Calendar
    {
        private readonly List<Event> events = new();

        public void AddEvent(Event evnt)
        {
            events.Add(evnt);
            SortEvents(events);
        }

        public void AddEvent(string name, string place, string date)
        {
            Event evnt = new(name, place, date);
            events.Add(evnt);
            SortEvents(events);
        }

        public void EditEvent(int eventNumber, string name, string place, string date)
        {
            Event evnt = events[eventNumber - 1];
            evnt.Name = name;
            evnt.Place = place;
            evnt.Date = date;
        }

        public void DeleteEvent(int eventNumber)
        {
            events.RemoveAt(eventNumber - 1);
        }

        public void CopyEvent(int eventNumber, int count)
        {
            Event evnt = new Event(events[eventNumber - 1]);

            for (int i = 0; i < count; i++)
            {
                events.Add(new Event(evnt));
            }
        }

        public bool IsEmpty()
        {
            return (events.Count == 0);
        }

        public int GetEventsCount()
        {
            return events.Count;
        }

        public string GetEventsInfo()
        {
            string result = "";

            for (int i = 0; i < events.Count; i++)
            {
                result += $"{i + 1}: ";
                result += events[i].GetInfo();
                result += "\n";
            }

            return result;
        }

        public void SearchEventByName(string name)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Name == name)
                {
                    Console.Write($"{i + 1}: ");
                    Console.WriteLine(events[i].GetInfo());
                }
            }
            Console.WriteLine();
        }

        private static void SortEvents(List<Event> events)
        {
            events.Sort((x, y) =>
            {
                DateTime xDate = DateTime.ParseExact(x.Date, "d.M", CultureInfo.InvariantCulture);
                DateTime yDate = DateTime.ParseExact(y.Date, "d.M", CultureInfo.InvariantCulture);
                int cmp = xDate.CompareTo(yDate);
                if (cmp == 0)
                    cmp = string.Compare(x.Name, y.Name);
                if (cmp == 0)
                    cmp = string.Compare(x.Place, y.Place);
                return cmp;
            });
        }
    }
}
