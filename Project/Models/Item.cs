using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Item : IItem
    {
        string IItem.Name { get; set; }
        string IItem.Description { get; set; }
    }
}