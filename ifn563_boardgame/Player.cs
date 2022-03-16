using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace ifn563_boardgame
{
    public class Player
    {
        private string playerId;
        private static int count;
        protected Player opponet;
        protected Player()
        {
            Type playerType = this.GetType();
            string pT = playerType.Name.Substring(0, 1);
            Interlocked.Increment(ref count);
            playerId = pT + count;
        }

        public int Hcount
        {
            get
            {
                return count;
            }
        }

        public string Pid
        {
            get
            {
                return playerId;
            }
        }
        
        public string GetPlayId()
        {
            return playerId;
        }

        public virtual bool MakeMove(List<MoveHistory> mh, Game game) { return false; }

        public void SetOpponent(Player p2OrC2)
        {
            opponet = p2OrC2;
        }
        public Player GetOpponent()
        {
            return opponet;
        }
              
    }
       

    public class Human: Player
    {
        private readonly int Hnum;
        private List<MoveHistory> moveH;
        public Human()
        {
            Hnum = this.Hcount;
        }        

        public Human(Player opponent2)
        {
            Hnum = this.Hcount;
            opponet = opponent2;
        }

        private int GetMove(Game game, string what)
        {
            int move;
            string input;
            int nXn = game.GetnXn();
        GetMoveagain:
            Write("Player {0} " + what + " move: ", Hnum);
            input = ReadLine().ToUpper();
            if (int.TryParse(input, out move))
            {
                if (move > nXn + 1 || move <= 0)
                {
                    WriteLine("***************************************************************************************************************");
                    WriteLine("Invalid number ({0}), try again.", input);
                    goto GetMoveagain;
                }
                else
                {
                    return move;
                }
            }
            else if (Function(input, game))
            {
                return 624300;
            }
            else goto GetMoveagain;
        }

        public override bool MakeMove(List<MoveHistory> mh, Game game)
        {
            int x;
            int y;
            this.moveH = mh;
            game.OpposPlyer = this.opponet;
            game.Currentplyer = this;
            Board board = new CLI(game);
            board.Display(mh);
            Flag1:
            x = GetMove(game, "X");
            if (x == 624300)
            {
                return false;
            }
            y = GetMove(game, "Y");
            if (y == 624300)
            {
                return false;
            }
            if (game.VerifyMove(x, y, mh))
            {
                goto Flag1;
            }
            else
                game.RegisterMove(x, y, mh, Pid);
            return true;
        }

        private bool Function(string input, Game game)
        {
            Board board = new CLI(game);
            Help newhelp = new PauseHelp(game);
            MakeSave make = new MakeSave();           

            switch (input)
            {
                case "QUIT":
                    WriteLine("Game over, thank you for playing.");
                    return true;
                case "SAVE":
                    SaveManager save = make.Create("SAVE");
                    save.SaveGame(moveH);
                    return false;
                case "LOAD":
                    save = make.Create("LOAD");
                    bool end = save.LoadSave(save.FetchLoad(), true);                    
                    board.Display(moveH);
                    return end;
                case "HELP":
                    newhelp.GameInstruction();
                    Write("Press Enter to continue");
                    ReadLine();
                    return false;
                case "UNDO":
                    game.Undo(moveH, this.opponet);
                    board.Display(moveH);
                    return true;
                case "REDO":
                    game.Redo(moveH);
                    board.Display(moveH);
                    return false;
                default:
                    WriteLine("***************************************************************************************************************");
                    WriteLine("Invalid input ({0}), try again.", input);
                    return false;
            }
        }

        
        
    }
}
