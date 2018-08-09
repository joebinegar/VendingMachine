using System;
using System.Collections.Generic;
using System.IO;
using Capstone.Classes;

namespace Capstone.Other.CLI
{
    public class PurchaseCLI
    {
        //CODE_REVIEW
        //Make comments on everything!
        #region Member Variables

        private VendingMachine _vm = null;
        //CODE_REVIEW
        //Move this list to vending machine class.
        private List<VendingItem> _transList = new List<VendingItem>();

        #endregion

        #region Constructor

        public PurchaseCLI(VendingMachine vm)
        {
            _vm = vm;
        }

        #endregion

        #region Methods

        public void DisplaySub()
        {
            bool timeToExit = false;
            while (!timeToExit)
            {
                Console.Clear();

                Console.WriteLine("Purchase Menu");
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("(R) Return to Main Menu");
                Console.WriteLine($"Current Balance: ${_vm.CurrentBalance}");

                Console.WriteLine();
                Console.Write("What option do you want to select? ");
                char input = Console.ReadKey().KeyChar;

                //CODE_REVIEW
                //Create FeedMoney() that does everything in the if statement.  Do the same for all menus.
                if (input == '1')
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine();

                         Console.Write("Enter the whole dollar amount you would like to add. $");
                         string inputAmount = Console.ReadLine();

                        try
                        {
                            _vm.FeedMoney(int.Parse(inputAmount));
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Please enter a whole dollar amount.");
                            Console.ReadKey();
                        }

                        // bool isWholeDollarAmount = int.TryParse(inputAmount, out int inputDollar);
                        //if(isWholeDollarAmount)
                        //{
                        //    _vm.FeedMoney(inputDollar);
                        //    //transactionLogList.Add($"{DateTime.Now} FEED MONEY: {inputDollar} {_vm.CurrentBalance}");
                        //}
                        //else
                        //{                          
                        //   Console.WriteLine("Please enter a whole dollar amount.");
                        //    Console.ReadKey();
                        //}
                       // inputDollar = int.Parse(inputAmount);
                       // _vm.FeedMoney(inputDollar);
                       // transactionLogList.Add($"{DateTime.Now} FEED MONEY: {inputDollar} {_vm.CurrentBalance}");

                        Console.WriteLine("(R) Return to Purchase Menu");
                    }
                    catch (Exception eMoney)
                    {
                        Console.WriteLine(eMoney.Message);
                        Console.ReadKey();
                    }
                }

                else if (input == '2')
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine();
                        Console.WriteLine("Please enter your SlotID selection:");
                        Console.WriteLine();
                        string  slotId = Console.ReadLine().ToUpper(); 
                        var invItem =  _vm.PurchaseItem(slotId);
                        _transList.Add(invItem.ItemName);                    
                        Console.WriteLine("(R) Return to Purchase Menu");
                    }
                    //CODE_REVIEW
                    //Decide which way we want to handle exceptions and refactor code. Catch generic exceptions.
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                    }
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //    Console.ReadKey();
                    //}
                    //catch (OutOfStockException)
                    //{
                    //    Console.ReadKey();
                    //}

                }
                else if (input == '3')
                {
                    //CODE_REVIEW
                    //Needs a try/catch(write message to screen)
                    Console.Clear();
                    Console.WriteLine("(3) Finish Transaction");
                    Console.WriteLine();
                    Console.WriteLine("Here is your change back.");
                    Console.WriteLine();
                    Change change = _vm.MakeChange();
                    Console.WriteLine("{0, -30}{1, -30}{2, -30}", "Nickels", "Dimes", "Quarters");
                    Console.WriteLine("{0, -30}{1, -30}{2, -30}", "-------", "-----", "--------");
                    Console.WriteLine("{0, -30}{1, -30}{2, -30}", change.Nickels, change.Dimes, change.Quarters);

                    _vm.CompletePurchase();

                    //CODE_REVIEW
                    //Use cli helper class to create a method that writes as many empty writelines as needed.
                    Console.WriteLine();
                    Console.WriteLine();              
                    if (_transList.Count > 0)
                    {
                        foreach(var item in _transList)
                        {
                            Console.WriteLine(item.Consume());
                        }
                    }
                    Console.WriteLine();                  
                    Console.WriteLine("(R) Return to Main Menu");
                    Console.ReadKey();        
                }
                else if (input == 'R' || input == 'r')
                {
                    if (_vm.CurrentBalance > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Not so fast! You need to complete your purchase first.");
                        Console.WriteLine("");
                        Console.WriteLine("Press any button to return to the previous menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        timeToExit = true; 
                        break;
                    }
                }

                else 
                {
                    Console.Clear();
                    Console.WriteLine("You have selected an invalid option.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the previous screen and make a valid selection.");
                    Console.ReadKey();
                }
            }
        }
        
        #endregion
    }
}