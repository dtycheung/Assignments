using System;
using static System.Console;
using System.Collections.Generic;

namespace ifn563_boardgame
{
    class Help
    {
        public Help()
        {
            Assis = new string[]{};
        }

        public string[] Assis { get; set; }

        public void GameInstruction()
        {
            for(int i =0; i < Assis.Length; i++)
            {
                if(i == 0)
                {
                    WriteLine("{0}", Assis[i]);
                }else
                    WriteLine("{0,-3}{1}", " ", Assis[i]);
            }
        }
    }

    class StartManu : Help
    {
        public StartManu()
        {
            Assis = new string[]{
            "***************************************************************************************************************",
            "How to play:",
            "1.Player can select starting a new game by typing '1' on the command line or '2' to continue a previous game.",
            "2.If Player want to start a new game, you may first select a game mode between Gomoku(g) and Othello(o).",
            "3.Then select a opponent by typing 'H' to play with another play.",
            "4.Alternatively, player may type 'C' to play with a computer player",
            "5.If you want to continue a previous game, please type '2' and type in the corresponding save index (integer).",
            "6.You may type 'Pause' anytime during the game for more function and information.", "End of instruction"};
        }
    }
    class PauseHelp : Help
    {
        public PauseHelp(Game game)
        {
            string gameType;
            gameType = game.GetType().Name;
            switch (gameType)
            {
                case "Gomoku":
                    Assis = new string[]{
                    "***************************************************************************************************************",
                    "How to play Gomoku:",
                    "1.Players take turn alternately placing a stone of their color on an empty intersection.",
                    "2.Black plays first.",
                    "3.The winner is the first player to form an unbroken chain of five stones horizontally, vertically, or diagonally. ",
                    "Functions: ",
                    "Player can save the game by typing 'SAVE' command during the game.",
                    "Player can load previous saved game by typing 'LOAD' command during the game.",
                    "Player can cancel the previous move by typing 'UNDO' command during the game.",
                    "Player can restart the game by typing 'REDO' command during the game .",
                    "Player can quit the game without saving by typing 'QUIT' command during the game.",
                    "End of instruction"
                    };
                    break;
                case "Othello":
                    Assis = new string[]{
                    "***************************************************************************************************************",
                    "How to play Othello:",
                    "1.Othello starts with an empty board, and the first two moves made by each player are in the four central squares of the board.",
                    "2.The players place their disks alternately with their colors facing up and no captures are made.",
                    "3.A player may choose to not play both pieces on the same diagonal, different from the standard Othello opening.",
                    "4.The second player's second move may or must flip one of the opposite-colored disks ",
                    "5.The player with the most pieces on the board at the end of the game wins. ",
                    "Functions: ",
                    "Player can save the game by typing 'SAVE' command during the game ",
                    "Player can load previous saved game by typing 'LOAD' command during the game.",
                    "Player can cancel the previous move by typing 'UNDO' command during the game.",
                    "Player can restart the game by typing 'REDO' command during the game or in the Pause Manu.",
                    "Player can quit the game without saving by typing 'QUIT' command during the game .",
                    "End of instruction"};
                    break;
                default:
                    break;
            }

            
        }
    }
}
