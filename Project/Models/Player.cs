using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Player : IPlayer
    {
        string IPlayer.PlayerName { get; set; }
        List<Item> IPlayer.Inventory { get; set; }
    }
}