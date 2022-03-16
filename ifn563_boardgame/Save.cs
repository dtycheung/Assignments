using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ifn563_boardgame
{
    public abstract class SaveManager
    {
  
        protected char DELIM = ',';
        protected string savingPath;
        public SaveManager() 
        {
            string path = Directory.GetCurrentDirectory();
            this.savingPath = path + @"\Save\";
        }

        public virtual string FetchLoad()
        {
            return "failed";
        }
        public virtual bool LoadSave(string filename, bool status) { return false; }

        public virtual void SaveGame(List<MoveHistory> mh) { }

    }

    public class MakeSave
    {
        public SaveManager Create(string type)
        {
            switch (type)
            {
                case "LOAD":
                    return new Load();
                case "SAVE":
                    return new Save();
                default:
                    return new Save();
            }
        }
    }

    class Save: SaveManager
    {        
        public Save()
        {
            string path = Directory.GetCurrentDirectory();
            this.savingPath = path + @"\Save\";
        }

        public override void SaveGame(List<MoveHistory> mh)
        {
            DateTime date = DateTime.Now;
            string directory = this.savingPath;
            try
            {
                if (!Directory.Exists(directory))
                {
                    DirectoryInfo di = Directory.CreateDirectory(directory);
                    Console.WriteLine("The directory was created successfully.");
                }
            }
            finally { }
                      
            if (!mh.Any()) 
            {
                WriteLine("No move have been made, save failed.");
                return;
            }
            else
            {
                string fileName = directory + @"Savefile" + date.ToString("yyMMddHHmmss") + ".txt";
                FileStream outFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);
                writer.WriteLine(mh[0].gameId.GetType().Name);
                foreach (var mr in mh)
                {
                    writer.WriteLine("{0}{1}{2}{3}{4}", mr.moveX, DELIM, mr.moveY, DELIM, mr.playerId);
                }

                writer.Close();
                outFile.Close();
                WriteLine("***************************************************************************************************************");
                WriteLine("Game Saved.");
            }           
        }
    }

    class Load : SaveManager
    {  
        private static string tempGame { get; set; }

        public override string FetchLoad()
        {
            string directory = savingPath;
            string[] files;
            string[] fields;
            string locaSplit = @"\";
            int x;
            //fetch all save file
            if (Directory.Exists(directory))
                {
                    
                files = Directory.GetFiles(directory);
                    if (files.Length == 0)
                    {
                        WriteLine("There are no files in the directory, please select 'New Game'");                        
                    return "failed";
                }
                    else
                    {
                        WriteLine("***************************************************************************************************************");
                        WriteLine("Index:   File Name:");
                        for (x = 0; x < files.Length; ++x)
                        {
                            fields = files[x].Split(locaSplit);
                            int last = fields.Length-1;
                            int index = x + 1;
                            WriteLine("    "+ index + ":   " + fields[last]);
                        }
                        WriteLine("***************************************************************************************************************");

                    //Ask user to select one save file
                    string filename;
                        int choice;
                        WriteLine("Please select one of the previous game by typing the file index.");
                        filename = ReadLine();
                    WriteLine("***************************************************************************************************************");

                    while (!int.TryParse(filename, out choice) || choice< 0 || choice > files.Length)
                        {
                            WriteLine("Invalid input, try again.");
                            filename = ReadLine();
                        WriteLine("***************************************************************************************************************");
                    }
                    filename = files[choice-1];
                    return filename;                          
                    }
                }
                else
                {
                    WriteLine("Directory " + directory + " does not exist");
                return "failed";
                }
        }

        public override bool LoadSave(string filename, bool duringGame)
        {
            SingletonMoveHistory.CreatHistory();
            List<MoveHistory> mh = SingletonMoveHistory.GetMH();
            if (mh != null&& duringGame)
            {
                int lastMove = mh.Count;
                mh.RemoveRange(0, lastMove);
            }
            FileStream inFile = new FileStream(filename, FileMode.Open,FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            string recordIn;
            string[] fields;
            int x, y;
            Game game;
            tempGame = reader.ReadLine();          
            switch (tempGame)
            {
                case "Gomoku":
                    game = new Gomoku();
                    break;
                case "Othello":
                    game = new Othello();
                    break;
                default:
                    game = new Gomoku();
                    break;
            }
            recordIn = reader.ReadLine();
            while (recordIn != null) 
            {
                fields = recordIn.Split(this.DELIM);
                x = Convert.ToInt32(fields[0]);
                y = Convert.ToInt32(fields[1]);
                string pid = fields[2];                

                mh.Add(new MoveHistory(x, y, game, pid));
                recordIn = reader.ReadLine();
            } 

            WriteLine("Game Loaded.");
            WriteLine("***************************************************************************************************************");
            reader.Close();
            inFile.Close();

            if (duringGame)
            {
                return false;                
            }
            else
            {
                Player opponent;
                Player player = new Human();
                if (mh[1].playerId.Equals("C2"))
                    opponent = new Computer(player);
                else
                    opponent = new Human(player);
                player.SetOpponent(opponent);
                game.PlayerTakingTurns(player, opponent);
                return false;
            }
            
        }
    }
}
