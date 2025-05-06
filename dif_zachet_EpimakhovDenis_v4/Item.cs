using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dif_zachet_EpimakhovDenis_v4
{
    class Item
    {
        public string Bukva { get; set; }
        public int Num { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"Буква - {Bukva}, Число - {Num}, Цвет - {Color}";
        }


    }
}
