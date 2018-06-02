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

        public static readonly string pathToMemoryIcon = pathToResources + "memory_icon.ico";

       
            

          
    }
}
