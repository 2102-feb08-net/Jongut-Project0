using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Library
{
    public class Store : Order

    {
        Dictionary<int, string> InventoryList = new Dictionary<int, string>();
        Dictionary<int, string> StoreList = new Dictionary<int, string>();
        Dictionary<int, string> SizeList = new Dictionary<int, string>();
        private int Id = 3;

        public Store()
        {
            InventoryList.Add(1, "Coke");
            InventoryList.Add(2, "Pepsi");
            InventoryList.Add(3, "Water");
            StoreList.Add(10101, "Amazon");
            StoreList.Add(10102, "Walgreens");
            StoreList.Add(10201, "7/11");
            SizeList.Add(1, "Small");
            SizeList.Add(2, "Medium");
            SizeList.Add(3, "Large");
        }

        public void AddItemToInventory()
        {
            ++Id;
            string inventoryItem = Console.ReadLine();
            try
            {
                InventoryList.Add(Id, inventoryItem);//Dictionary Item ID, Item Name
                Console.WriteLine("New Inventory: ");
                printInventory();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"int\" already exists.");
            }

        }
        public void printInventory()
        {
            foreach (KeyValuePair<int, string> kvp in InventoryList)
                Console.WriteLine("{0}. {1}", kvp.Key, kvp.Value);
        }

        public void printSize()
        {
            foreach (KeyValuePair<int, string> kvp in SizeList)
                Console.WriteLine("{0}. {1}", kvp.Key, kvp.Value);
        }

        public void AddStores()
        {
            int NewId = int.Parse(Console.ReadLine());
            string NewStoreName = Console.ReadLine();

            //StoreList[NewId] = NewStoreName;
            StoreList.Add(NewId, NewStoreName);


        }
        public void displayStores()
        {
            Console.WriteLine(StoreList.Count());
            foreach (KeyValuePair<int, string> kvp in StoreList)
                Console.WriteLine("StoreID: {0}. Store Name: {1}", kvp.Key, kvp.Value);
            Console.ReadLine();
        }

        public void findStore()
        {
            int enterId = int.Parse(Console.ReadLine());
            if (StoreList.ContainsKey(enterId))
                Console.WriteLine(StoreList[enterId]);
        }

        public void AddOrderCustomer()
        {
            AddOrder();
        }
    }
}
