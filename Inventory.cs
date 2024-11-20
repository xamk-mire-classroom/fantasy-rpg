using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_World
{
    public class Inventory
    {
        private readonly List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            Console.WriteLine($"{item.Name} has been added to the inventory.");
        }

        public void RemoveItem(string itemName)
        {
            Item itemToRemove = _items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                Console.WriteLine($"{itemName} has been removed from the inventory.");
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in the inventory.");
            }
        }

        public void ListItems()
        {
            Console.WriteLine("\nCurrent Inventory:");
            if (_items.Count == 0)
            {
                Console.WriteLine("The inventory is empty.");
                return;
            }

            foreach (var item in _items)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}

