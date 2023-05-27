﻿namespace LR1NN
{
    public abstract class Event : IEvent
    {
        private string name;
        private string place;
        private string date;

        public Event()
        {
            Console.WriteLine("Вызван конструктор по умолчанию базового класса");
            DateTime now = DateTime.Now;
            name = "неизвестно";
            place = "неизвестно";
            date = $"{now.Day}.{now.Month}";
        }
        public Event(string name, string place, string date)
        {
            Console.WriteLine("Вызван конструктор с параметрами базового класса");
            this.name = name;
            this.place = place;
            this.date = date;
        }
        public Event(Event evnt)
        {
            Console.WriteLine("Вызван конструктор копирования базового класса");
            name = evnt.GetName();
            place = evnt.GetPlace();
            date = evnt.GetDate();
        }
        ~Event()
        {
            Console.WriteLine("Вызван деструктор базового класса");
        }

        public static bool operator <(Event a, Event b)
        {
            int cmp = string.Compare(a.GetName(), b.GetName());
            return cmp < 0;
        }
        public static bool operator >(Event a, Event b)
        {
            int cmp = string.Compare(a.GetName(), b.GetName());
            return cmp > 0;
        }
        public static bool operator ==(Event a, Event b)
        {
            return a.GetName().Equals(b.GetName());
        }
        public static bool operator !=(Event a, Event b)
        {
            return a.GetName().Equals(b.GetName()) == false;
        }

        public abstract void Show();

        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetPlace(string place)
        {
            this.place = place;
        }
        public void SetDate(string date)
        {
            this.date = date;
        }
        public string GetName()
        {
            return name;
        }
        public string GetPlace()
        {
            return place;
        }
        public string GetDate()
        {
            return date;
        }
        public int CompareTo(IEvent evnt)
        {
            return GetName().CompareTo(evnt.GetName());
        }
    }
}
