using System;
using static System.Console;
using System.Collections.Generic;


namespace ifn563_boardgame
{
    class Manu
    {
        public Game NewGame()
        {
        GetReadLine:
            string choice;
            Game game;
            WriteLine("***************************************************************************************************************");
            WriteLine("Gomoku(G) / Othello(O) (Othello is not supported yet.)");//accept both full name or abbreviation 
                choice = ReadLine().ToUpper();
                switch (choice)
                {
                    case "O":
                    case "OTHELLO":
                        WriteLine("Othello is not supported yet, Gomoku is loaded.");
                    game = new Gomoku();
                        return game;
                    case "G":
                    case "GOMOKU":
                        WriteLine("Gomoku is loaded successfully.");
                    game = new Gomoku();
                        return game; ;
                    default:
                        WriteLine("Invalid entrance, please select between Gomoku or Othello");
                    goto GetReadLine;
                }
        }

        public Player NewPlayer(Player player)
        {
            string cOrH;
            flag2:
            WriteLine("***************************************************************************************************************");
            WriteLine("Please select your opponent: Computer player (C)/ Human Player (H)");
                cOrH = ReadLine().ToUpper();
                switch (cOrH)
                {
                    case "H":
                    case "HUMAN":
                        Player p2 = new Human(player);
                        player.SetOpponent(p2);
                        WriteLine("Player 2 activated");
                        return p2;
                    case "C":
                    case "COMPUTER":
                        Player c1 = new Computer(player);
                        player.SetOpponent(c1);                        
                        WriteLine("Computer player activated");                  
                        return c1;
                    default:
                        WriteLine("Please select between a human opponent(H) or computer opponent(C).");
                        goto flag2;
                } 
        }

        public bool Greeting()
        {
            string choice;
            MakeSave make = new MakeSave();
        Flag1:
            WriteLine("***************************************************************************************************************");
            WriteLine("{0,-40}{1}", " ", "BoardGame Player Battle Group");
            WriteLine("Welcome to BPBG, please type in one of the following number (If you need instruction, please type 3):");
            WriteLine("{0,-4}{1}", " ", "1. New Game");
            WriteLine("{0,-4}{1}", " ", "2. Load Game");
            WriteLine("{0,-4}{1}", " ", "3. Help");
            WriteLine("***************************************************************************************************************");
            choice = ReadLine();
            switch (choice)
            {
                case "1":
                    return true;
                case "2":
                    SaveManager load = make.Create("LOAD");
                    string status = load.FetchLoad();
                    switch (status)
                    {
                        case "failed":
                            goto Flag1;
                        default:
                            return load.LoadSave(status, false); ;
                    }
                case "3":
                    Help help = new StartManu();
                    help.GameInstruction();
                    Write("Press Enter to continue");
                    ReadKey();
                    goto Flag1;
                default:
                    WriteLine("Invalid option.");
                    goto Flag1;

            }

        }
    }
}
