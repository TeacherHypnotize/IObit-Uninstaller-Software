using System;
using System.Collections.Generic;

namespace MeetingPlanner
{
    class Meeting
    {
        public string Title { get; }
        public string Room { get; }
        public TimeSpan StartTime { get; }

        public Meeting(string title, string room, TimeSpan startTime)
        {
            Title = title;
            Room = room;
            StartTime = startTime;
        }
    }

    class Schedule
    {
        private readonly List<Meeting> meetings = new List<Meeting>();

        public void AddMeeting(string title, string room, TimeSpan startTime)
        {
            meetings.Add(new Meeting(title, room, startTime));
        }

        public void PrintSchedule()
        {
            meetings.Sort((a, b) => a.StartTime.CompareTo(b.StartTime));

            Console.WriteLine("Meeting Schedule");
            Console.WriteLine("================");

            foreach (Meeting meeting in meetings)
            {
                Console.WriteLine($"{meeting.StartTime:hh\\:mm} | {meeting.Title} | {meeting.Room}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Schedule schedule = new Schedule();

            schedule.AddMeeting("Sprint Review", "Room A", new TimeSpan(9, 0, 0));
            schedule.AddMeeting("Design Session", "Room C", new TimeSpan(13, 30, 0));
            schedule.AddMeeting("Project Update", "Room B", new TimeSpan(11, 15, 0));
            schedule.AddMeeting("Planning", "Room D", new TimeSpan(15, 45, 0));

            schedule.PrintSchedule();
        }
    }
}
