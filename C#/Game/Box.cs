using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    /// <summary>
    /// 维护棋子类
    /// </summary>
    public class Box
    {
        /// <summary>
        /// 棋子行数 （1—3）
        /// </summary>
        public int Line { get; set; }
        /// <summary>
        /// 当前行的棋子数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 初始化棋子布局
        /// </summary>
        /// <returns></returns>
        public static List<Box> InitBoxLayout()
        {
            return new List<Box>()
            {
                new Box() { Line = 1, Number = 3 },
                new Box { Line = 2, Number = 5 },
                new Box { Line = 3, Number = 7 }
            };
        }
    }
}
