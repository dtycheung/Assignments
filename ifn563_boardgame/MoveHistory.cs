using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;


namespace ifn563_boardgame
{
    public class MoveHistory
    {        
        private int xMov;
        private int yMov;
        private Game gId;
        private string pId;

        public MoveHistory(int moveX, int moveY, Game gameId, string player)
        {
            this.xMov  = moveX;
            this.yMov = moveY;
            this.gId = gameId;
            this.pId = player;
        }

        public Game gameId {
            get
            {
                return this.gId;
            }
            
         }
        public int moveX
        {
            get
            {
                return this.xMov;
            }
            
        }
        public int moveY
        {
            get
            {
                return this.yMov;
            }
            
        }
        public string playerId
        {
            get
            {
                return this.pId;
            }           
        }
    }


    public sealed class SingletonMoveHistory
    {
        private static List<MoveHistory> moveH;
        private static SingletonMoveHistory instance;
        private SingletonMoveHistory()
        {
            moveH = new List<MoveHistory>();
        }

        public static SingletonMoveHistory CreatHistory()
        {
            if (instance == null)
            {
                instance = new SingletonMoveHistory();
            }
            return instance;
        }

        public static List<MoveHistory> GetMH()
        {
            return moveH;
        }

    }

}
