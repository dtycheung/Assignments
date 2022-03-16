using System;
using System.Collections.Generic;
using static System.Console;

namespace ifn563_boardgame
{
    public class Game
    {        
        //public string gameType { get; set; }
        protected int NxN { get; set;}
        protected string Winner = null;
        public Player Currentplyer;
        public Player OpposPlyer;

        public void RegisterMove(int inputX, int inputY, List<MoveHistory> mh, string pId) //template method
        {
            mh.Add(new MoveHistory(inputX, inputY, this, pId));

            if (CheckWinning(inputX, inputY, pId, mh, 5))
            {
                SetWinnerAs(pId);
                Board board = new CLI(this);
                board.Display(mh);
            }
        }
        public virtual bool CheckWinning(int lastX, int lastY, string playerId, List<MoveHistory> mh, int maxCount) { return false; }//template 
        protected virtual void SetWinnerAs(string winner){ }//template
        public virtual bool LoopEveryMove(int x, int y, string pid, List<MoveHistory> mh) { return false;  }
        public virtual bool VerifyMove(int inputX, int inputY, List<MoveHistory> mh) { return false; }

        public void PlayerTakingTurns(Player player, Player opponent)//core function of game
        {
            List<MoveHistory> mh = SingletonMoveHistory.GetMH();
            if (mh==null)
            {
                SingletonMoveHistory.CreatHistory();
                mh = SingletonMoveHistory.GetMH();
            }

            if(player != this.Currentplyer & OpposPlyer != null)
            {

                player = Currentplyer;
                opponent = OpposPlyer;
            }

            bool end = player.MakeMove(mh,this);
            do  //using quit game to check the player wanna end game or not, if player type "quit", bool = false while loop will be ended
            {                
                if (TheWinnerIs()) { return; }
                end = opponent.MakeMove(mh, this);
                if (end)
                {
                    if (TheWinnerIs()) { return; }
                    end = player.MakeMove(mh, this);
                }
                if (opponent.GetPlayId() != mh[1].playerId)
                {
                    string id = mh[1].playerId;
                    WriteLine("hi2" + id + id);

                    switch (id)
                    {
                        case "H2":
                            opponent = new Human();
                            break;
                        case "C2":
                            opponent = new Computer();
                            break;
                    }
                }
            } while (end);
            return;
        }

        public bool TheWinnerIs()
        {
            if (Winner != null)
            {
                switch (Winner)
                {
                    case "H1":
                        Winner = "Player1";
                        break;
                    case "H2":
                        Winner = "Player2";
                        break;
                    case "C2":
                        Winner = "Computer Player";
                        break;
                    default:
                        break;
                }
                WriteLine("Game finished, the winner is " + Winner + "!!!!!!!!!");                
                return true;
            }
            else
                return false;
        }        
       

        public int GetnXn()
        {
            return NxN;
        }

        

        public bool Undo(List<MoveHistory> mh, Player player)
        {          
            int lastMove = mh.Count;
            mh.RemoveAt(lastMove - 1);
            Currentplyer = player;
            OpposPlyer = player.GetOpponent();
            for(int i =0; i < 2; i++)
            {
                string areYouBot = player.GetType().Name;
                if (areYouBot!="Human")  
                {
                    mh.RemoveAt(lastMove - 2);
                    PlayerTakingTurns(Currentplyer, OpposPlyer);
                    return false;
                }
            }
            PlayerTakingTurns(Currentplyer, OpposPlyer);
            return false;
        }

        public void Redo(List<MoveHistory> mh)
        {
            int lastMove = mh.Count;
            WriteLine("move cancelled" + lastMove);
            mh.RemoveRange(0, lastMove);
        }
    }

    class Gomoku : Game
    {
        public Gomoku()
        {
            this.NxN = 14;
        }

        protected override void SetWinnerAs(string winner)
        {
            this.Winner = winner;
        }

        public override bool VerifyMove(int inputX, int inputY, List<MoveHistory> mh)
        {
            foreach (var move in mh)
            {
                if (move.moveX.Equals(inputX) && move.moveY.Equals(inputY) || inputX <= 0 || inputX > NxN + 1 || inputY <= 0 || inputY > NxN + 1)
                {
                    WriteLine("Move was token. Please make another move.");
                    return true;
                }
            }
            return false;
        }


        public override bool LoopEveryMove(int x, int y, string pid, List<MoveHistory> mh)
        {
            if (x > 0 || y > 0 || x <= NxN || y <= NxN)
            {
                foreach (var mr in mh)
                {
                    if (mr.moveX.Equals(x) && mr.moveY.Equals(y) && mr.playerId.Equals(pid))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }



        public override bool CheckWinning(int lastX, int lastY, string playerId, List<MoveHistory> mh, int maxCount)
        {
            
            int x, y;
            int reverser = -1;
            for (x = -1; x <= 1; x++)//eight direction checking
            {
                for (y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;                    
                    int count = 1;
                    int revCount = 0;
                    int targetX;
                    int rTargetX;
                    int targetY;
                    int rTtargetY;
                    while (count < maxCount)
                    {                        
                        targetX = lastX + count * x;
                        targetY = lastY + count * y;                       

                        if (LoopEveryMove(targetX, targetY, playerId, mh))
                        {
                           count++;
                            if (count == maxCount)
                            {
                                return true;                                
                            }
                        }
                        else
                        {
                            int count2 = 0;
                            while (revCount < maxCount)
                            {
                                revCount++;
                                
                                rTargetX = targetX + revCount * x * reverser;
                                rTtargetY = targetY + revCount * y * reverser;
                                if (LoopEveryMove(rTargetX, rTtargetY, playerId, mh))
                                {
                                    count2++;
                                    if (count2 == maxCount)
                                    {
                                        return true;
                                    }
                                }
                            }
                            
                                    break;
                            
                        }
                    }    
                    
                    
                }

            }
            return false;

        }
    }

 

    class Othello: Game
    {
        public Othello()
        {
        this.NxN = 7;
        }
        public override bool CheckWinning(int lastX, int lastY, string playerId, List<MoveHistory> mh, int maxCount)
        {
            WriteLine("not implemented");
            return false;
        }
        protected override void SetWinnerAs(string winner){}
        public override bool VerifyMove(int inputX, int inputY, List<MoveHistory> mh) {
            WriteLine("not implemented");
            return false;
        }
        public override bool LoopEveryMove(int x, int y, string pid, List<MoveHistory> mh)
        {
            WriteLine("not implemented");
            return false;
        }

    }

}
