using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public static class Paths
    {
        private static string fullPath = AppDomain.CurrentDomain.BaseDirectory;

        // unix or windows 
        public static readonly string pathToResources =
            fullPath.Contains(@"bin\Debug") ? 
            fullPath.Replace(@"bin\Debug", @"Resources") : fullPath.Replace(@"bin/Debug", @"Resources");

        public static Image closedCard = Image.FromFile(pathToResources + "closed_card.jpg");

        public static Image readyToOpenImage = Image.FromFile(pathToResources + "ready_to_open.gif");

        public static readonly string pathToMemoryIcon = pathToResources + "memory_icon.ico";

        public static readonly string pathTo2xImage = pathToResources + "2x.png";

        public static readonly string pathToFindNextImage = pathToResources + "find_next.jpg";

        public static readonly string pathToOpenCardsImage = pathToResources + "open_cards.jpg";

        public static readonly string pathToSecondChanceImage = pathToResources + "second_chance.jpg";




    }
}
