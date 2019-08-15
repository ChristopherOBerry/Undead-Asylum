using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Room : IRoom
    {
        string IRoom.Name { get; set; }
        string IRoom.Description { get; set; }
        List<Item> IRoom.Items { get; set; }
        Dictionary<string, IRoom> IRoom.Exits { get; set; }
    }
}