using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dif_zachet_EpimakhovDenis_v4
{
    public partial class Form1 : Form
    {
        private List<Item> Items;

        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            var letters = new List<string> { "A", "B" };
            var nums = new List<int> { 1, 2, 3 };
            var colors = new List<string> { "зеленый", "оранжевый" };

            var ff = from l in letters
                     from n in nums
                     from c in colors
                     select new Item { Bukva = l, Num = n, Color = c };
            Items = ff.ToList();
            GroupDisplay();
        }

        private void GroupDisplay()
        {
            listBox1.Items.Clear();

            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        var groupIsLatter = Items.GroupBy(i => i.Bukva);
                        foreach (var group in groupIsLatter)
                        {
                            listBox1.Items.Add($"Группа: буква = {group.Key}");
                            foreach(var item in group)
                            {
                                listBox1.Items.Add(item.ToString());
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        var groupIsNums = Items.GroupBy(i => i.Num);
                        foreach (var group in groupIsNums)
                        {
                            listBox1.Items.Add($"Группа: цифра = {group.Key}");
                            foreach (var item in group)
                            {
                                listBox1.Items.Add(item.ToString());
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        var groupIsColor = Items.GroupBy(i => i.Color);
                        foreach (var group in groupIsColor)
                        {
                            listBox1.Items.Add($"Группа: цвет = {group.Key}");
                            foreach (var item in group)
                            {
                                listBox1.Items.Add(item.ToString());
                            }
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Неверно формат ввода", "Ошибка");
                        break;
                    }
            }
        }
    }
}
