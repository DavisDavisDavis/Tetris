using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Block
    {
        private string Name { get; }
        private int[,] Map { get; }

        public Block(string name, int[,] map)
        {
            Name = name;
            Map = map;
        }
    }
}
