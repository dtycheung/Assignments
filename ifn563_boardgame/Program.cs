using System;
using static System.Console;
using System.Collections.Generic;


namespace ifn563_boardgame
{

    class Program
    {               
        static void Main(string[] args)
        {
            Manu startManu = new Manu();            
            if (startManu.Greeting())
            {
                Player player = new Human(); //there's always be at lease one human player
                Game game = startManu.NewGame();
                Player opponent = startManu.NewPlayer(player);
                WriteLine("Game Started. Player can type 'HELP' at anytime for instruction");
                game.PlayerTakingTurns(player, opponent);
            }
            
        }
    }

} 
