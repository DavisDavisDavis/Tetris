using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Block
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int[,] Map { get; set; }

        public Block(string name, string icon, int[,] map)
        {
            Name = name;
            Icon = icon;
            Map = map;
        }
    }
}
