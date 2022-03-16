using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace ifn563_boardgame
{
    public class Computer : Player
    {
        public Computer() { }
        public Computer(Player opponent2)
        {
            opponet = opponent2;
        }

        public override bool MakeMove(List<MoveHistory> mh, Game game)
        {
            int nXn = game.GetnXn();
            int x, y;
            Random rdn = new Random();
            int last = mh.Count();
            if (last <= 2) //first move just make a random move
            {              
                do
                {
                    x = rdn.Next(mh[last - 1].moveX - 2, mh[0].moveX + 2);
                    y = rdn.Next(mh[last - 1].moveY - 2, mh[0].moveY + 2);
                } while (game.VerifyMove(x, y, mh));
            }
            else
            {
                int fx, fy;
                int mCount = 0; // use to record how many random move the computer tried 
                do
                {//determain the defend need
                    int lastX = mh[last - 1].moveX;
                    int lastY = mh[last - 1].moveY;
                    if (game.CheckWinning(lastX, lastY, opponet.GetPlayId(), mh, 2))  //changing the last int change can the difficult of the game                  
                    {
                      

                        fx = lastX - mh[last - 3].moveX;
                        fy = lastY - mh[last - 3].moveY;
                        if (fx < -1 || fx > 1 && fx != 0)
                        {
                            fx /= fx; //only need +/- for loop direction, not the actual value, skip 0 to prevent error
                        }
                        if (fy < -1 || fy > 1 && fy != 0)
                        {
                            fy /= fy;
                        }
                        x = mh[last - 1].moveX + fx;
                        y = mh[last - 1].moveY + fy;
                        int reverser = -1;
                        fx *= reverser;
                        fy *= reverser;
                        int reveCount = 1;
                        while (game.VerifyMove(x, y, mh))
                        {
                            fx += reveCount;
                            fy += reveCount;
                            x = mh[last - 1].moveX + fx;
                            y = mh[last - 1].moveY + fy;
                            reveCount++;
                        }
                    }
                    else if (mCount == 0) //place to the right of to previous piece, if the next piece was token, mCount++
                    {
                        x = mh[last - 2].moveX + 1;
                        y = mh[last - 2].moveY;
                        mCount++;
                    }
                    else
                    { // if  right was token, random within other direction , mCount++
                        fx = rdn.Next(-1, 2);
                        fy = rdn.Next(-1, 2); ;
                        x = mh[last - 2].moveX + fx;
                        y = mh[last - 2].moveY + fy;
                        mCount++;
                    }
                    if (mCount > 3) //tried for the 3 time then random move on all available spot on board
                    {
                        x = rdn.Next(1, nXn + 1);
                        y = rdn.Next(1, nXn + 1);
                    }
                } while (game.VerifyMove(x, y, mh));

            }
            game.RegisterMove(x, y, mh, Pid);
            WriteLine("***************************************************************************************************************");
            WriteLine("Computer Player has made move X: {0} Y: {1}", x, y);

            return true;
        }
    }



}
