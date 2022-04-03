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
        public int[,] Map { get; set; }

        public Block(string name, int[,] map)
        {
            Name = name;
            Map = map;
        }
    }
}
