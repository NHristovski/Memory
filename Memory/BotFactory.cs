using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class BotFactory
    {
        public static Bot GetEasyBot() => new Bot(new EasyBotStrategy());
        public static Bot GetNormalBot() => new Bot(new NormalBotStrategy());
        public static Bot GetHardBot() => new Bot(new HardBotStrategy());
    }
}
