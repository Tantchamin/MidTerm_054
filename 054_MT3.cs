using System;
using System.Collections.Generic;

namespace _054_MT3
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareFlowerStore();
            StoreMenu();
        }

        static void StoreMenu()
        {
            string decide = "y";
            string selectFlower;

            do
            {
                SelectNumberForBuy();

                selectFlower = Console.ReadLine();

                SelectFlowerMenu(selectFlower);

                decide = decideFlower();

                Exit(decide);
                
            }
            while (decide != "exit");
        }
        
        static void SelectNumberForBuy()
        {
            Console.Clear();

            Console.WriteLine("Select number for buy flower : ");

            foreach (string i in flowerStore.flowerList)
            {
                Console.Write((flowerStore.flowerList.IndexOf(i) + 1) + " ");
                Console.WriteLine(i);
            }
        }
        static string decideFlower()
        {
            Console.WriteLine("You can stop this progress ? exit for >> exit << progress and press any key for continue");
            return Console.ReadLine();
        }

        static void Exit(string decide)
        {
            Console.Clear();

            if (decide == "exit")
            {
                Console.Write("Current my cart");
                flowerStore.showCart();
            }

        }

        static FlowerStore flowerStore;

        static void PrepareFlowerStore()
        {
            Program.flowerStore = new FlowerStore();
        }

        static void SelectFlowerMenu(string selectFlower)
        {
            switch (selectFlower)
            {
                case "1":
                    flowerStore.addToCart(flowerStore.flowerList[0]);
                    Console.WriteLine("Added " + flowerStore.flowerList[0]);
                    break;

                case "2":
                    flowerStore.addToCart(flowerStore.flowerList[1]);
                    Console.WriteLine("Added " + flowerStore.flowerList[1]);
                    break;

                default:
                    Console.WriteLine("Not Added to cart. found select number of flower");
                    break;
            }
        }
    }

    class FlowerStore
    {
        public List<string> flowerList = new List<string>();
        List<string> cart = new List<string>();

        public FlowerStore()
        {
            flowerList.Add("Rose");
            
            flowerList.Add("Lotus");
        }

        public void addToCart(string name)
        {
            cart.Add(name);
        }
    
        public void showCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                Console.WriteLine("My Cart :");
                foreach (string i in cart)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
