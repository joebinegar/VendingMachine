using System;
using System.Collections.Generic;
using System.Threading;
using Capstone.Classes;
using Capstone.Other.CLI;

namespace Capstone.CLI
{
    public class VendingMachineCLI
    {
        //CODE_REVIEW
        //Combine stuff into methods.
        #region Member Variables

        private VendingMachine _mainVM = null;

        #endregion

        #region Constructor

        public VendingMachineCLI(VendingMachine vm)
        {
            _mainVM = vm;
        }

        #endregion

        #region Methods

        /// <summary>
       /// Writes the dictionary to the console with formatting.
       /// </summary>
        public void WriteDictionaryToConsole()
        {
            string vmName = "Vendo-Matic 500";
            Console.SetCursorPosition((Console.WindowWidth - vmName.Length) / 2, Console.CursorTop);
            Console.WriteLine(vmName);

            Console.WriteLine();

            Console.WriteLine("{0, -28}{1, -28}{2, -28}{3, -28}", "SlotID", "Product Name", "Price", "Inventory");
            Console.WriteLine("{0, -28}{1, -28}{2, -28}{3, -28}", "------", "------------", "-----", "---------");

            Console.WriteLine();

            foreach (KeyValuePair<string, InventoryItem> item in _mainVM._inventory)
            {
                if (item.Value.Quantity == 0)
                {
                    Console.WriteLine("{0, -28}{1, -28}{2, -28}{3, -28}", item.Key, item.Value.ItemName.Name, "$" + item.Value.ItemName.Price, "Sold Out!");
                }
                else
                {
                    Console.WriteLine("{0, -28}{1, -28}{2, -28}{3, -28}", item.Key, item.Value.ItemName.Name, "$" + item.Value.ItemName.Price, item.Value.Quantity + " available");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Select any key to return to the main menu");
        }

        /// <summary>
/// Display the Main Menu
/// </summary>
        public void Display()
        {
            bool timeToExit = false;
            while (!timeToExit)
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(Q) Quit");
                Console.WriteLine();
                Console.Write("What option do you want to select? ");
                char input = Console.ReadKey().KeyChar;

                if (input == '1')
                {
                    WriteDictionaryToConsole(); 
                    Console.ReadKey();
                }              
                else if (input == '2')
                {
                    PurchaseCLI submenu = new PurchaseCLI(_mainVM);
                    submenu.DisplaySub();
                }
                else if (input == 'Q' || input == 'q')
                {
                    if(_mainVM.CurrentBalance > 0)
                    {                       
                        Console.WriteLine("Not so fast! You need to complete your purchase first.");
                        Console.ReadKey();
                    }
                    else
                    {
                    timeToExit = true;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"{input} is not a valid option. Please select a valid option from the menu.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();                   
                }
            }
        }

        #endregion
    }
}