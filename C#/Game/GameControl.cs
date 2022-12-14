using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Game
{
    public class GameControl
    {
        private readonly List<Box> _layout;

        public GameControl()
        {
            _layout = Box.InitBoxLayout();
        }
        /// <summary>
        /// 玩游戏
        /// </summary>
        public bool Play(int line, int number)
        {
            var matchRecord = _layout.FirstOrDefault(m => m.Line == line);
            if (matchRecord == null)
            {
                Console.WriteLine("对不起，请输入正确的行数（1-3）");
                return false;
            }

            if (matchRecord.Number < number)
            {
                Console.WriteLine($"对不起，第{line}行只剩下{matchRecord.Number}个棋子，请重新输入");
                return false;
            }
            matchRecord.Number -= number;
            return true;
        }
        /// <summary>
        /// 判断游戏是否结束
        /// </summary>
        public bool IsOver()
        {
            return !_layout.Any(m => m.Number > 0);
        }
        /// <summary>
        /// 渲染棋子布局
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in _layout)
            {
                if (item.Number > 0)
                {
                    builder.Append($"第{item.Line}行：");
                    for (int i = 0; i < item.Number; i++)
                    {
                        builder.Append("*");
                    }
                    builder.Append("\n");
                }
            }
            return builder.ToString();
        }
    }
}
