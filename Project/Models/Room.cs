using System.Collections.Generic;
using System;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Room : IRoom
    {
        string IRoom.Name { get; set; }
        string IRoom.Description { get; set; }
        List<Item> IRoom.Items { get; set; }
        Dictionary<string, IRoom> IRoom.Exits { get; set; }

        public void Exits (string direction, Room roomObject)
        {
            IRoom.Exits.Add(direction, roomObject);
        }
        public Room Go(string direction){
            if(Exits.ContainsKey(direction)){
                Console.WriteLine("Opening Door");
                Thread.Sleep(1000);
                Console.Clear();
                return Directions[direction];
            }
            Console.WriteLine("Can't go that way");
            return this;
        }
        public Room(string name)
        {
            Name = name;
            Directions = new Dictionary<string, Room>();        
        }
        public void PrintDirections(){
            foreach(var room in Directions)
            {
                Console.Write(room.Key + ", ");

            }
            Console.WriteLine("");
        }
        
    }
}