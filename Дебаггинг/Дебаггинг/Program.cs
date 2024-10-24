using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дебаггинг
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
    }
    public class Inventory
    {
        private List<Item> _items;

        private int _maxWeight;
        private int _weight;

        public int MaxWeight => _maxWeight; //исправлено: maxWeight на _maxWeight

        public int Weight => _weight;

        public Inventory(int maxWeight)
        {
            _items = new List<Item>(); //исправлено: добавлен инициализатор списка в конструкторе класса
            _maxWeight = maxWeight;
        }

        public bool AddItem(Item item, int count)
        {
            if (_weight + item.Weight * count > _maxWeight)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                _items.Add(item);
            }

            _weight += item.Weight * count;

            return true;
        }

        public bool RemoveItem(Item item)
        {
            bool removed = _items.Remove(item);
            if (removed)
            {
                _weight -= item.Weight;
            }
            return removed;
        }

        public int CountItem(Item countItem)
        {
            int c = 0;
            for (int i = 0; i < _items.Count; i++) //исправлено: i <= _items.Count на i < _items.Count потому что иначе цикл выходил за пределы индексации списка
            {
                var item = _items[i];
                if(item == countItem) //исправлено: добавлено условие для подсчета конкретного предмета
                {
                    c++;
                }
                
            }

            return c;
        }

    }

    class Program
    {
        static void Main()
        {
            Inventory inventory = new Inventory(100);
            Item sword = new Item { Name = "Sword", Weight = 23 };
            Item bow = new Item { Name = "Bow", Weight = 20 };

            inventory.AddItem(sword, 2);
            inventory.AddItem(bow, 1);

            Console.WriteLine("Вес инвентаря: " + inventory.Weight);
            Console.WriteLine("Количество мечей: " + inventory.CountItem(sword));
            Console.WriteLine("Количество луков: " + inventory.CountItem(bow));

            inventory.RemoveItem(sword);
            Console.WriteLine("Вес инвентаря после удаления меча: " + inventory.Weight);
            Console.WriteLine("Количество мечей после удаления: " + inventory.CountItem(sword));
            
        }
    }
}