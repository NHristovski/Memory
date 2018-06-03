using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class PlayerFactory
    {
        public static Bot GetEasyBot() => new Bot("EasyBot",new EasyBotStrategy());

        public static Bot GetNormalBot() => new Bot("NormalBot", new NormalBotStrategy());

        public static Bot GetHardBot() => new Bot("HardBot", new HardBotStrategy());

        public static PairGameHumanPlayer GetPairGameHumanPlayer(String name) => new PairGameHumanPlayer(name);
    }
}
