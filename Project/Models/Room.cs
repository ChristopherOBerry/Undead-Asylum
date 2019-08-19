using System.Collections.Generic;
using System;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, IRoom> Exits { get; set; }


        public IRoom Movement(string option)
        {
            if (Exits.ContainsKey(option))
            {
                return Exits[option];
            }
            Console.WriteLine("You can't go that way.");
            return this;
        }

        //constructor
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Exits = new Dictionary<string, IRoom>();


        }


    }
}