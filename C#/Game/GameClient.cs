using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class GameClient
    {
        private readonly Player _aPlayer;
        private readonly Player _bPlayer;
        private GameControl _gameControl;
        public Player CurrentPlayer { get; private set; }
        public GameClient()
        {
            _aPlayer = new Player { Id = 1, Name = "玩家A" };
            _bPlayer = new Player { Id = 2, Name = "玩家B" };
            _gameControl = new GameControl();
            CurrentPlayer = _aPlayer;
        }
        public void main(int line, int number)
        {
            if (_gameControl.Play(line, number))
            {
                if (_gameControl.IsOver())
                {
                    //重新开始游戏
                    Console.Clear();
                    Console.WriteLine($"==== 游戏结束，[{CurrentPlayer.Name}] 输了。游戏重新开始 ====");
                    _gameControl = new GameControl();
                    CurrentPlayer = _aPlayer;
                    return;
                }
                CurrentPlayer = CurrentPlayer == _aPlayer ? _bPlayer : _aPlayer;
            }
        }
        public override string ToString()
        {
            return _gameControl.ToString();
        }
    }
}
