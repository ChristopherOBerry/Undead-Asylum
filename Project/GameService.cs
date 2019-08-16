using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
    public class GameService
    {
        IRoom CurrentRoom { get; set; }
        Player CurrentPlayer { get; set; }

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

        }

        public void Reset()
        {
        }

        public void Search()
        {
        }

        public void Setup()
        {
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