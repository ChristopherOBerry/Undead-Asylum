using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
    public class GameService : IGameService
    {

        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public bool Running = true;
        public bool usedCellKey = false;
        public bool usedSword = false;
        public bool usedBossKey = false;

        public void GetUserInput()
        {
            if (CurrentRoom.Name == "Cliffside" && CurrentPlayer.Inventory.Count < 2)
            {
                YouDied();
            }
            Console.WriteLine($@"{CurrentRoom.Name} - {CurrentRoom.Description}");
            if (CurrentRoom.Name == "Cliffside")
            {
                VictoryAchieved();
            }
            if (CurrentRoom.Name == "Firelink Shrine")
            {
                GameEnd();
            }
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("");
            string input = Console.ReadLine().ToLower();
            string[] inputs = input.Split(" ");
            string command = inputs[0];
            string option = "";

            if (inputs.Length > 1)
            {
                option = inputs[1];

            }
            switch (command)
            {
                case "go":
                    Go(option);

                    break;

                case "inventory":
                    Inventory();
                    break;

                case "help":
                    Help();
                    break;

                case "search":
                    Search();
                    break;

                case "quit":
                    Quit();
                    break;

                case "exit":
                    Quit();
                    break;

                case "reset":
                    Reset();
                    break;

                case "take":
                    TakeItem(option);
                    break;

                case "use":
                    UseItem(option);
                    break;

                default:
                    Console.WriteLine("Not a valid option. Please try another command, or type Help for a list of options.");
                    Console.WriteLine("");
                    break;

            }
        }

        public void Go(string option)
        {
            //TODO: Add in other room booleans for progress gating
            Console.Clear();
            if (usedCellKey == false)
            {
                CurrentRoom = (Room)CurrentRoom.Movement("Cell");
                Console.WriteLine("The door is locked");
            }
            else
            {
                CurrentRoom = (Room)CurrentRoom.Movement(option);

            }


        }

        public void Help()
        {
            Console.WriteLine("");
            Console.WriteLine("Actions:");
            Console.WriteLine("GO DIRECTION: You may type go and a cardinal direction to move through the rooms.");
            Console.WriteLine("TAKE ITEM: If there is an item in the room, you may pick it up by typing take and the item name");
            Console.WriteLine("INVENTORY: You may view your inventory by typing inventory");
            Console.WriteLine("USE ITEM: You may use an item in your inventory by typing use and the item name.");
            Console.WriteLine("If you would like to search the room, type search.");
            Console.WriteLine("You may quit at any time by typing quit.");
            Console.WriteLine("");

        }

        public void Inventory()
        {
            if (CurrentPlayer.Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("Inventory: ");
                int count = 1;
                foreach (var item in CurrentPlayer.Inventory)
                {
                    Console.WriteLine($"{count} {item.Name} - {item.Description}");
                    count++;
                }
            }
        }

        public void Quit()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        public void Reset()
        {
            Console.Clear();
            GameService game = new GameService();
            string playerName = Console.ReadLine();
            Player newPlayer = new Player(playerName);
            Running = true;
            game.Setup();
            game.StartGame();
        }

        public void Search()
        {
            Console.Clear();
            if (CurrentRoom.Items.Count == 0)
            {
                Console.WriteLine("You didn't find anything.");
            }
            else
            {
                Console.WriteLine("Items in this room");
                foreach (var item in CurrentRoom.Items)
                {




                    Console.WriteLine(item.Name);
                    Console.WriteLine("");

                }

            }

        }

        public void Setup()
        {
            Room cell = new Room("Cell", @"
For who knows how long, you've been sitting in this cell. 
            
Four walls, bugs, and rats have been your only companionship during this time. Well into the process of becoming Hollow, the memories of your life as a knight have faded, and the details of your homeland are muddled in your mind. 
            
What you do remember is this when you were first afflicted with the curse of the Undead, you were sent to an Asylum in Lordran, to be quarantined from the rest of Humanity. Weeks, months, years may have gone by. You've lost track of time. Or perhaps, time has lost track of you. 
            
A small skylight in your cell has been the only source of light to indicate time of day. There is a locked door of metal bars to the front of your cell, through which you can see a long, torch-lit hallway and several other cells. They're populated with fellow Undead just like you, only they have gone Hollow, their minds and Humanity forever lost. Several of them cling to the bars of their cell doors, mindlessly (and fruitlessly) wrestling to dislodge the locks or hinges. Your fate will likely be the same. 
            
You look above to the skylight, noticing an overcast day. Suddenly, a knight appears above, dropping a corpse down into your cell. You attempt to speak to him, but he leaves before a word can leave your lips. You notice a glimmer of light from the waist of the corpse.");
            Room hallway = new Room("Hallway", @"
You unlocked the door and move into the Hallway.
A Hollow Undead stands before you, slumped against a wall. You see a series of barred windows on your right, revealing a chamber below. A stairwell lies straight ahead.");
            Room sewer = new Room("Sewer", @"
You find yourself in a Sewer section. A ladder is visible straight ahead.");
            Room vestibule = new Room("Vestibule", @"
Upon climbing the ladder, you see an unlit bonfire straight ahead. You light the bonfire and rest for a moment. Straight ahead is a large gate. There are rusted gates to your left and right among the walls, but appear to be irrelevant.");
            Room strayDemon = new Room("Stray Demon", @"
CRASH! A large Demon, several dozen feet tall descends from the sky wielding an appropriately massive club.
You notice a gate ahead in the distance, with a giant lock barring the way forward.
To the west, a gate begins to open.");
            Room gateLeft = new Room("Sewer Behind Gate", @"
You book it past the demon and enter another sewer area, several Hollows litter the spillway.
A small set of stone stairs lay straight ahead.");
            Room archer = new Room("Archer Hallway", @"
You shove past the Hollows to enter a long hallway. The sound of an arrowhead meeting stone is heard not too far from where your head just was.
A Hollowed archer stands at the end of the hallway, knocking another arrow.
You see the glimmer of steel ahead, on the corpse of a fallen knight. ");
            Room boulder = new Room("Boulder Stairwell", @"
After deftly dealing with the Hollow archer, you move towards a landing, overlooking the demon. It does not spot you.
Suddenly, a large boulder rolls past you, breaking a hole in the wall to your right. You hear a groan of mortal pain.
");
            Room oscar = new Room("Room Where You Meet Oscar", @"
Oh, you. You're no Hollow, eh? Thank goodness. I'm done for, I'm afraid.
I'll die soon, then lose my sanity. I wish to ask something of you. You and I, we're both Undead. Hear me out, will you?
Regrettably, I have failed in my mission. But perhaps you can keep the torch lit.
There is an old saying in my family:

...Thou who art Undead, art chosen, In thine exodus from the Undead Asylum, 
maketh pilgrimage to the land of Ancient Lords.
When thou ringeth the Bell of Awakening, the fate of the Undead thou shalt know...

Well, now you know. And I can die with hope in my heart. Oh, one more thing. Here, take this.
An Estus Flask, an Undead favourite. Oh, and this. Now I must bid farewell. 
I would hate to harm you after death. So, go now... And thank you.");
            Room dropdown = new Room("Dropdown to Stray Demon", @"
A few Hollows attempt to ambush you, but you swipe through them with your sword.
Ahead lies a gate of fog. You reach out through it, and suddenly, the fog disappates. Below to your left is the room with the giant demon from before.
");
            Room crow = new Room("Cliffside", @"
You suddenly feel stronger. Where the corpse once lay, you see a key glimmering on the ground. You put the key in the giant lock.
With a great heave, you open the large door to reveal a cliffside, wind whipping against stone ruins long destroyed. A path of cobblestones leads to the edge of the cliff.
you see a murder of giant crows off in the distance.");

            Room firelinkShrine = new Room("Firelink Shrine", @"
Standing at the cliffside, a giant Crow carries you off in its talons to the skies. 
When the crow decides to be done with you, you pick yourself up to see an unlit bonfire, and a rather crestfallen looking warrior sat upon a stone bench.
");


            cell.Exits.Add("north", hallway);
            if (usedCellKey == false)
            {
                CurrentRoom = cell;
                Console.WriteLine("The door is locked.");
            }

            hallway.Exits.Add("north", sewer);
            sewer.Exits.Add("north", vestibule);
            vestibule.Exits.Add("north", strayDemon);
            strayDemon.Exits.Add("west", gateLeft);
            strayDemon.Exits.Add("north", crow);
            gateLeft.Exits.Add("north", archer);
            archer.Exits.Add("north", boulder);
            boulder.Exits.Add("east", oscar);
            oscar.Exits.Add("south", boulder);
            boulder.Exits.Add("north", dropdown);
            dropdown.Exits.Add("west", strayDemon);
            crow.Exits.Add("north", firelinkShrine); // you win


            Item cellKey = new Item("Key", "Opens the door to your cell.");
            Item shield = new Item("Shield", "A simple steel shield.");
            Item sword = new Item("Sword", "A simple steel sword. Can slay demons.");
            Item estusFlask = new Item("Estus", "An Undead favorite. Restores health. Looks like orange juice.");
            Item crowKey = new Item("CliffKey", "Opens the giant door.");

            cell.Items.Add(cellKey);
            archer.Items.Add(sword);
            archer.Items.Add(shield);
            oscar.Items.Add(estusFlask);
            strayDemon.Items.Add(crowKey);


            CurrentRoom = cell;

        }

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("");
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
            Console.WriteLine("Enter your name:");
            string playerName = Console.ReadLine();
            CurrentPlayer = new Player(playerName);
            Console.Clear();
            Console.WriteLine(playerName);
            Console.WriteLine("Yes, indeed, the Darksign brands the Undead. And in this land, the Undead are corralled and led to The North where they are locked away to await the end of the world. This is your fate.");
            Console.WriteLine(" ");


            while (Running == true)
            {

                GetUserInput();

            }

        }

        public void TakeItem(string option)
        {
            Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == option.ToLower());
            if (item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
                Console.WriteLine($"You picked up the {item.Name}: {item.Description}");


            }
            else
            {
                Console.WriteLine($"{CurrentRoom.Name} does not have anymore items to pick up.");
            }
        }

        public void UseItem(string option)
        {

            if (option == "key")
            {
                Console.WriteLine("The door to your cell opened.");
                usedCellKey = true;
            }
            if (option == "sword")
            {

                usedSword = true;
            }
            if (option == "bosskey")
            {
                Console.WriteLine("The giant lock opened.");
                usedBossKey = true;
            }
            Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == option.ToLower());
            Console.WriteLine($"You used the {item.Name}");

        }

        public void GameEnd()
        {
            Console.WriteLine(@"
Only, in the ancient legends it is stated, that one day an undead shall be chosen to leave the undead asylum, 
in pilgrimage, to the land of ancient lords, Lordran.");
            Console.WriteLine(" ");
            Console.WriteLine(@"
Well, what do we have here? You must be a new arrival. Let me guess, fate of the undead, right?
That is why you came, isn't it? To this accursed land of the Undead. Well, you're not the first, heheh.");
            Console.WriteLine("");
            Console.WriteLine($"Congratulations, {CurrentPlayer.PlayerName}, you win!");
            Running = false;
            Console.WriteLine("Would you like to play again?");
            string yn = Console.ReadLine();
            if (yn == "yes")
            {
                Running = true;
                Setup();
                StartGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public void YouDied()
        {
            Console.Beep(500, 750);
            Console.Beep(488, 750);
            Console.Beep(476, 1000);

            Console.WriteLine("The Stray Demon clubbed you to death. Try looking for a sword first.");
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
            Console.WriteLine("Would you like to play again?");
            string yn = Console.ReadLine();
            if (yn == "yes")
            {
                Setup();
                StartGame();
            }
            else
            {
                Environment.Exit(0);
            }
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
            Console.WriteLine(" ");


        }
    }
}