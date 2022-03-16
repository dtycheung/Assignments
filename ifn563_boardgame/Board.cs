using System;
using System.Collections.Generic;
using static System.Console;


namespace ifn563_boardgame
{
    public class Board
    {
        public int nXn;
        protected string bMark = "o";
        protected string mark = " ";
        protected string cMark = "●";        

        public Board(Game game)
        {
            this.nXn = game.GetnXn();
        }

        public virtual void Display(List<MoveHistory> mh) { }
       
        
    }

    public class GUI : Board
    {
        public GUI(Game game)
            : base(game)
        {

        }
        public override void Display(List<MoveHistory> mh) { }
    }

    public class CLI: Board
    {
        public CLI(Game game)
            : base(game)
        {

        }
        public override void Display(List<MoveHistory> mh)
        {
            string underline = "───┬";
            string blank = "   ┌";
            for (int x = 0; x <= nXn + 1; x++)
            {
                if (x == 0)
                {
                    Write("{0, -20}", " ");
                    Write(blank);
                }
                else
                {
                    if (x == nXn + 1)
                    {
                        Write("───┐");
                    }
                    else
                        Write(underline);
                }
            }
            WriteLine();
            for (int y = 2 * nXn; y >= 0; y--)
            {
                if (y % 2 == 0)
                {
                    int boarderY = y / 2 + 1;
                    Write("{0, -20}", " ");
                    Write("{0, 2} |", boarderY);
                }
                else
                {
                    Write("{0, -20}", " ");
                    Write("{0, 2} ├", "  ");
                }
                for (int x = 0; x <= nXn; x++)
                {
                    if (x == nXn)
                    {
                        if (y % 2 == 0)
                        {
                            Write(" {0} |", BOW(x, y / 2, mh));
                        }
                        else
                        {
                            Write("───┤");
                        }
                    }
                    else
                    if (y % 2 == 0)
                    {
                        Write(" {0} │", BOW(x, y / 2, mh));
                    }
                    else
                    {
                        Write("───┼");
                    }
                }
                WriteLine();
            }

            for (int x = 0; x <= nXn + 1; x++)
            {
                if (x == 0)
                {
                    Write("{0, -20}", " ");
                    Write("   └");
                }
                else
                {
                    if (x == nXn + 1)
                    {
                        Write("───┘");
                    }
                    else
                        Write("───┴");
                }
            }
            WriteLine();
            for (int x = 0; x <= nXn + 1; x++)
            {

                if (x == 0)
                {
                    Write("{0, -20}", " ");
                    Write("   ");
                }
                else
                {
                    Write("{0,4}", x);
                }
            }
            WriteLine();
        }

        protected string BOW(int x, int y, List<MoveHistory> mh)
        {
            foreach (var mr in mh)
            {
                //WriteLine("{0} {1} {2} {3}", mr.moveX, mr.moveY, mr.gameId, mr.playerId);
                if (mr.moveX == x + 1 && mr.moveY == y + 1)
                {
                    if (mr.playerId.Contains("H1")) //same problem
                    {
                        return cMark;
                    }
                    else
                        return bMark;
                }
            }
            return mark;
        }

    }
}
