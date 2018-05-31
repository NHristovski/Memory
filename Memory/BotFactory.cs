﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class PlayerFactory
    {
        public static Bot GetEasyBot() => new Bot(new EasyBotStrategy());

        public static Bot GetNormalBot() => new Bot(new NormalBotStrategy());

        public static Bot GetHardBot() => new Bot(new HardBotStrategy());

        public static HumanPlayer GetHumanPlayer(String name) => new HumanPlayer(name);
    }
}
