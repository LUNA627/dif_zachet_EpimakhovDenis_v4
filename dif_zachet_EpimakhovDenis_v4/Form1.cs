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

        private List<Item> GenDek(char[] simvols, int[] nums, string[] colors)
        {
            var ff = from s in simvols
                     from n in nums
                     from c in colors
                     select new Item { Simvol = s, Num = n, Color = c };
            return ff.ToList();
        }

        private bool IsSimvol(List<Item> items, char simvol)
        {
            return !items.Any(i => i.Simvol == simvol);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            char[] simvols = { 'A', 'B' };
            int[] nums = { 1, 2, 3 };
            string[] colors = { "зеленый", "оранжевый" };

            Items = GenDek(simvols, nums, colors);

            listBox1.Items.Clear();
            listBox1.Items.Add("Декатдное произведение");
            foreach (var item in Items)
            {
                listBox1.Items.Add(item.ToString());
            }
            GroupDisplay();
        }

        private void GroupDisplay()
        {
            listBox1.Items.Clear();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        var groupIsLatter = Items.GroupBy(i => i.Simvol);
                        foreach (var group in groupIsLatter)
                        {
                            listBox1.Items.Add($"Группа: буква = {group.Key}");
                            foreach (var item in group)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (Items == null)
            {
                MessageBox.Show("Сначала нужно сгенерировать", "Ошибка");
                return;
            }
            char simbol;

            if(!char.TryParse(textBox1.Text.Trim(), out simbol))
            {
                MessageBox.Show("Корректный символ", "Ошибка");
                return;
            }

            int num;
            if (!int.TryParse(textBox2.Text.Trim(), out num))
            {
                MessageBox.Show("Корректное число", "Ошибка");
                return;
            }

            string color = comboBox2.SelectedItem.ToString();

            if (IsSimvol(Items, simbol)) 
            {
                Items.Add(new Item { Simvol = simbol, Num = num, Color = color });

                listBox1.Items.Clear();
                listBox1.Items.Add("Обновленный список");
                foreach (var item in Items )
                {
                    listBox1.Items.Add(item.ToString());
                }
            }
            else
            {
                MessageBox.Show($"Символ {simbol} уже есть");
            }

        }
    }
}
