using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_3_JTEmerson
{
    public struct Desk
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public Material Material { get; set; }
        public int NumberOfDrawers { get; set; }

        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 17;
        public const int MAXDEPTH = 48;
    }

    public enum Material
    {
        pine = 50,
        laminate = 100,
        oak = 200,
        rosewood = 300,
        veneer = 150
    };
}
