using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
    public class GameService : IGameService
    {
        public IRoom CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput()
        {

        }

        public void Go(string direction)
        {

        }

        public void Help()
        {

        }

        public void Inventory()
        {

        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Reset()
        {
        }

        public void Search()
        {

        }

        public void Setup()
        {
            Room cell = new Room("Cell");
            cell.Exits.Add("north", hallway);
            Room hallway = new Room("Hallway");
            hallway.Exits.Add("north", sewer );
            Room sewer = new Room("Sewer");
            sewer.Exits.Add("north", vestibule);
            Room vestibule = new Room("Vestibule");
            vestibule.Exits.Add("north", strayDemon);
            Room strayDemon = new Room ("Stray Demon");
            strayDemon.Exits.Add("west", gateLeft);
            strayDemon.Exits.Add("north", crow);
            Room gateLeft = new Room ("Sewer Behind Gate");
            getLeft.Exits.Add("north", archer);
            Room archer = new Room ("Archer Hallway");
            archer.Exits.Add("west", boulder);
            Room boulder = new Room ("Boulder Stairwell");
            boulder.Exits.Add("north", oscar);
            Room oscar = new Room ("Room Where You Meet Oscar");
            oscar.Exits.Add("north",dropdown);
            Room dropdown = new Room ("Dropdown to Stray Demon");
            dropdown.Exits.Add("west", strayDemon);
            dropdown.Exits.Add("east", parry);
            Room parry = new Room ("Room Where You Learn To Parry");
            parry.Exits.Add("south", dropdown);
            Room crow = new Room ("Cliffside");
            crow.Exits.Add("north", firelinkShrine);
            Room firelinkShrine = new Room ("Firelink Shrine");
            

            Item cellKey = new Item("Asylum Cell Key");
            Item shield = new Item("Knight Shield");
            Item sword = new Item ("Knight Sword");
            Item estusFlask = new Item("Estus Flask");
            Item crowKey = new Item("Cliffside Key");

            CurrentRoom = cell;
        }

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Yes, indeed, the Darksign brands the Undead. And in this land, the Undead are corralled and led to The North where they are locked away to await the end of the world. This is your fate.");
            Console.Write(@"                                                                                                                     
      ***** **                              *                 *******                             ***                
   ******  ***                            **                *       ***                            ***               
 **    *  * ***                           **               *         **                             **               
*     *  *   ***                          **               **        *                              **               
     *  *     ***            ***  ****    **                ***             ****    **   ****       **       ****    
    ** **      **    ****     **** **** * **  ***          ** ***          * ***  *  **    ***  *   **      * **** * 
    ** **      **   * ***  *   **   ****  ** * ***          *** ***       *   ****   **     ****    **     **  ****  
    ** **      **  *   ****    **         ***   *             *** ***    **    **    **      **     **    ****       
    ** **      ** **    **     **         **   *                *** ***  **    **    **      **     **      ***      
    ** **      ** **    **     **         **  *                   ** *** **    **    **      **     **        ***    
    *  **      ** **    **     **         ** **                    ** ** **    **    **      **     **          ***  
       *       *  **    **     **         ******                    * *  **    **    **      **     **     ****  **  
  *****       *   **    **     ***        **  ***         ***        *    ******      ******* **    **    * **** *   
 *   *********     ***** **     ***       **   *** *     *  *********      ****        *****   **   *** *    ****    
*       ****        ***   **               **   ***     *     *****                                  ***             
*                                                       *                                                            
 **                                                      **                                                          
                                                                                                                     
                                                                                                                     
                                                                                                                     ");
            string playerName = Console.ReadLine("");


        }

        public void TakeItem(string itemName)
        {
        }

        public void UseItem(string itemName)
        {
        }
        public void YouDied()
        {
            Console.WriteLine(@"
              .......    ......      .,,,,,.        .......      ......     ...........          .......  .............   ...........                      
                .,,.       ,.     .,.      .,,.       .,,          ,.         ,,.      .,,.        ,,.      .,,      ,.     .,,      .,,.                  
                 .,,      ,.     ,,          ,,,      .,.          ,.         ,,.        .,,.      ,,.      .,,       .     .,,         ,,.                
                  .,,    ,.    .,,.           ,,,     .,.          ..         ,,.         .,,.     ,,.      .,,             .,,          ,,.               
                   .,.  ..     ,,,            .,,.    .,.          ..         ,,.          ,,,     ,,.      .,,     ,       .,,          .,,.              
                    ,,...      ,,,            .,,.    .,.          ..         ,,.          ,,,     ,,.      .,,....,,       .,,          .,,.              
                    .,,,       ,,,             ,,.    .,.          ..         ,,.          ,,,     ,,.      .,,    .,       .,,          .,,.              
                     .,.       ,,,.           .,,.    .,.          ..         ,,.          ,,,     ,,.      .,,     .       .,,          .,,.              
                     .,.       .,,.           .,,     .,,          ,.         ,,.         .,,.     ,,.      .,,             .,,          ,,.               
                     .,.         ,,.         .,.       ,,.        ..          ,,.        .,,.      ,,.      .,,        ..   .,,         ,,.                
                     ,,.          .,,.      .,.         ,,,      ,.           ,,,      .,,.        ,,.      .,,.      ,.    .,,.      .,.                  
                   .......           .,,,,..              .,,,,..          ............          .......  ..............  ............                     
                                                                                                                                                              ");
        }
        public void VictoryAchieved()
        {
            Console.WriteLine(@"                                                                                                                                           
          /%%*  .(%/  ,%*,/%*   ,#%(.   *%%*     #%%((##*    ,%%(((%%  (%#((%% ,#%#((%#     .%   .%#(#%((#%*.#%#((%%  #%%(/#%/             
            %.   #   %.     (%   .%      *.       %,     %#   ,%    (   %*   /   %    /     #%*  /   .%    ,  %    /   #(     #%           
            ,%  #   #(       %%  .%      *.       %,      %/  .%   ,    %*       %   *     *.*%      .%       %   .    #(      ##          
             (#/    %,       *%  .%      ,.       %,      ##  .%//((    %(**/,   %(//%     #  %*     .%       %(/(#    #(      #%          
              %/    %/       *%  .%      *        %,      ##  .%   (    %*   ,   %   (    ,(((#%     .%       %   /    #(      #%          
              #/    (%       %*   %,     (        %,     ,%   .%        %*       %        #    %/    .%       %        #(      %*          
              %/     (%     #,    /%.   *,        %/    *#    ,%     /  %*      .%.    # (     *%    ,%       %,    #  ##    .%            
             ....       ,*,         .**.         ....,.      ........  ....    ........ ...    ...  .....   ........  ....,.               
                                                                                                                                           ");
        }
    }
}