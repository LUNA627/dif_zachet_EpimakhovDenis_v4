using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dif_zachet_EpimakhovDenis_v4
{
    class Item
    {
        public char Simvol { get; set; }
        public int Num { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"Буква - {Simvol}, Число - {Num}, Цвет - {Color}";
        }


    }
}
