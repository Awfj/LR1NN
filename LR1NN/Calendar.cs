﻿namespace LR1NN
{
    public class Calendar
    {
        private List<Event> events = new List<Event>();

        public Calendar()
        {
            Console.WriteLine("Вызван конструктор по умолчанию основного класса");
        }
        public Calendar(List<Event> events)
        {
            Console.WriteLine("Вызван конструктор с параметрами основного класса");
            this.events = events;
        }

        public Calendar(Calendar calendar)
        {
            Console.WriteLine("Вызван конструктор копирования основного класса");
            events = calendar.events;
        }

        public void AddEvent(Event evnt)
        {
            events.Add(evnt);
            Console.WriteLine("Мероприятие добавлено\n");
        }
        public void AddEvent(string name, string place, string date)
        {
            events.Add(new Event(name, place, date));
            Console.WriteLine("Мероприятие добавлено\n");
        }

        public void EditEvent(int eventNumber, string name, string place, string date)
        {
            Event evnt = events[eventNumber - 1];
            evnt.SetName(name);
            evnt.SetPlace(place);
            evnt.SetDate(date);
            Console.WriteLine("Мероприятие изменено\n");
        }

        public void DeleteEvent(int eventNumber)
        {
            events.RemoveAt(eventNumber - 1);
            Console.WriteLine("Мероприятие удалено\n");
        }

        public void CopyEvent(int eventNumber, int count)
        {
            Event evnt = new Event(events[eventNumber - 1]);

            for (int i = 0; i < count; i++)
            {
                events.Add(new Event(evnt));
            }
            Console.WriteLine("Мероприятие скопировано\n");
        }

        public bool IsEmpty()
        {
            return (events.Count == 0);
        }

        public int GetEventsCount()
        {
            return events.Count;
        }

        public void ShowEvents()
        {
            for (int i = 0; i < events.Count; i++)
            {
                Console.Write($"{i + 1}: ");
                events[i].Show();
            }
            Console.WriteLine();
        }

        public void SearchEventByName(string name)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].GetName() == name)
                {
                    Console.Write($"{i + 1}: ");
                    events[i].Show();
                }
            }
            Console.WriteLine();
        }
    }
}