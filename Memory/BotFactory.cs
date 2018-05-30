using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class BotFactory
    {
        public Bot GetEasyBot() => new Bot(new EasyBotStrategy());
        public Bot GetNormalBot() => new Bot(new NormalBotStrategy());
        public Bot GetHardBot() => new Bot(new HardBotStrategy());
    }
}
