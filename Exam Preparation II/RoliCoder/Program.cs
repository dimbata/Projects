using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoliTheCoder
{
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Event> events = new List<Event>();
            string pattern = @"\d+\s+#\w+(\s+@\w+)*";
            // fix regex to match events without contestants
            while (input != "Time for Code")
            {
                Match result = Regex.Match(input, pattern);
                if (result.Success)
                {
                    List<string> commands = input.Split(' ').Where(x => x != string.Empty).Select(x => x.TrimStart('#')).ToList();
                    int eventID = int.Parse(commands[0]);
                    string eventName = commands[1];
                    List<string> participants = commands.GetRange(2, commands.Count - 2);
                    bool broken = false;
                    foreach (var item in events)
                    {
                        if (item.ID == eventID)
                        {
                            if (item.name == eventName)
                            {
                                item.participants.AddRange(participants);
                                broken = true;
                                break;
                            }
                            else
                            {
                                broken = true;
                                break;
                            }
                        }

                    }
                    if (events.Count == 0 || !broken)
                    {
                        events.Add(new Event(eventID, eventName, participants));
                    }

                }
                input = Console.ReadLine();
            }

            var orderedEvents = events.OrderByDescending(x => x.participants.Count).ThenBy(x => x.name);
            foreach (var theEvent in orderedEvents)
            {
                theEvent.Printer();
            }
        }
    }

    public class Event
    {
        public int ID;
        public string name;
        public List<string> participants;

        public Event(int ID, string name, List<string> participants)
        {
            this.ID = ID;
            this.name = name;
            this.participants = participants;
        }

        public void Printer()
        {
            participants = participants.Distinct().ToList();
            participants.Sort();
            Console.WriteLine($"{name} - {participants.Count}");
            foreach (var participant in participants)
            {
                Console.WriteLine(participant);
            }
        }
    }
}
