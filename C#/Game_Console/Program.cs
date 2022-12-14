using System;
using Game;

namespace Game.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            GameClient gameClient = new GameClient();
            Console.WriteLine("==== 游戏开始! ====");
            Console.WriteLine("==== 输入走棋命令：line-number。比如3-4 将在第3行拿走4个棋子(*) ====");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(gameClient.ToString());
                Console.WriteLine($"->[{gameClient.CurrentPlayer.Name}]，开始走棋，输入命令拿走棋子(line-number)：");
                var readStr = Console.ReadLine();
                var comm = readStr.Split('-');
                int line = 0;
                int number = 0;
                if (string.IsNullOrWhiteSpace(readStr) || comm.Length != 2 || !int.TryParse(comm[0], out line) || !int.TryParse(comm[1], out number))
                {
                    Console.WriteLine("输入格式不正式，请参考格式 line-number");
                    continue;
                }
                gameClient.main(line, number);
            }
        }
    }
}
