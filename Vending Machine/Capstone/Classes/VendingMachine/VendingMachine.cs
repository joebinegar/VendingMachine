using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
    //CODE_REVIEW
        //Fix names with _.

    #region Member Variables

        decimal _totalSales = 0;
        string _directory = Environment.CurrentDirectory;
        string _filePath = @"..\..\..\etc\vendingmachine.csv";
        string _logFullPath = " ";
        List<string> _salesReport = new List<string>();
        public Dictionary<string, InventoryItem> _inventory = new Dictionary<string, InventoryItem>();
        public TransactionFileLog _transactionFileLogger = new TransactionFileLog("Log.txt");
        string _salesDirectory = Environment.CurrentDirectory;
        string _salesFilePath = "SalesReport.txt";
        string _salesFullPath = " ";
        
    #endregion

    #region Properties
   
        public decimal CurrentBalance { get; set; }
        
       //There are currently no references to the Inventory Item Lists "Items" or "_items".
        //public List<InventoryItem>Items
        //{
        //    get
        //    {
        //        return _items;
        //    }
        //}
        //private List<InventoryItem> _items = new List<InventoryItem>();
        #endregion

    #region Constructor

        public VendingMachine()
        {
            
            CurrentBalance = 0;
            _logFullPath = Path.Combine(_directory, _filePath);
            _salesFullPath = Path.Combine(_salesDirectory, _salesFilePath);
            ReadFile();
        }

        #endregion

    #region Methods

        /// <summary>
        /// Reads in from the given file and creates a new string array split on the pipes ('|').
        /// Item type is determined by the value of the array at the last index position.
        /// Couples the slot position (slotId, ex. "A1") and inventory item by adding them to the 
        /// _inventory dictionary where slotId = key, inventory item = value.
        /// </summary>
        public void ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_logFullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] itemArray = line.Split('|');
                        if (itemArray[itemArray.Length - 1] == "Chip")
                        {
                            ChipItem chipsItem = new ChipItem(itemArray[1], decimal.Parse(itemArray[2]));
                            InventoryItem invItem = new InventoryItem(chipsItem, 5);
                            _inventory.Add(itemArray[0], invItem);
                        }
                        else if (itemArray[itemArray.Length - 1] == "Candy")
                        {
                            CandyItem candyItem = new CandyItem(itemArray[1], decimal.Parse(itemArray[2]));
                            InventoryItem invItem = new InventoryItem(candyItem, 5);
                            _inventory.Add(itemArray[0], invItem);
                        }
                        else if (itemArray[itemArray.Length - 1] == "Drink")
                        {
                            BeverageItem drinkItem = new BeverageItem(itemArray[1], decimal.Parse(itemArray[2]));
                            InventoryItem invItem = new InventoryItem(drinkItem, 5);
                            _inventory.Add(itemArray[0], invItem);
                        }
                        else if (itemArray[itemArray.Length - 1] == "Gum")
                        {
                            GumItem gumItem = new GumItem(itemArray[1], decimal.Parse(itemArray[2]));
                            InventoryItem invItem = new InventoryItem(gumItem, 5);
                            _inventory.Add(itemArray[0], invItem);
                        }
                    }
                }
            }
            catch (IOException ie) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(ie.Message);
            }
            catch (Exception e) //catch a specific type of Exception
            {
                Console.WriteLine("Unknown Error");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// -Asks the user to input a whole dollar amount (int dollars).
        /// -Then adds that integer input to CurrentBalance(VendingMachine Class property).
        /// </summary>
        /// <param name="dollars"></param>
        public void FeedMoney(int dollars)
        {
            if (dollars > 0)
            {
                CurrentBalance += dollars;
            }
            else
            {
                throw new Exception("Please enter a dollar amount greater than 0.");
            }
            _transactionFileLogger.RecordDeposit(dollars, CurrentBalance);
        }

        /// <summary>
        /// Checks to see that valid product code was entered, makes sure user has entered enough money, 
        /// and makes sure the product is not sold out.
        /// This method then "purchases" the item selected by reducing quantity by 1 in inventory, 
        /// reducing current balance by the cost of the item, records the transaction to the transaction file logger, 
        /// adds the transaction to the sales report, and adds the cost of the item to total sales.
        /// </summary>
        /// <param name="slotId"></param>
        /// <returns></returns>
        public InventoryItem PurchaseItem(string slotId)
        {
            var invItem = _inventory[slotId];
            if (_inventory.ContainsKey(slotId) == false)
            {
                throw new Exception("Invalid product code. Please try again.");
            }
            else if (_inventory[slotId].ItemName.Price > CurrentBalance)
            {
                throw new Exception("Insufficient Funds.Please add more money.");
            }
            else if (_inventory[slotId].Quantity > 0 && _inventory[slotId].ItemName.Price <= CurrentBalance)
            {
                invItem.Quantity--;
                CurrentBalance -= invItem.ItemName.Price;
                _totalSales += invItem.ItemName.Price;
                _transactionFileLogger.RecordGetItem(invItem.ItemName.Name, slotId,
                                                     invItem.ItemName.Price, CurrentBalance);
                _salesReport.Add($"{invItem.ItemName.Name}|{ 5 - invItem.Quantity}");
                
            }
            else if (invItem.Quantity <= 0)
            {               
                throw new Exception("Sold Out! Make another selection.");
            }
            else
            {
                throw new Exception("Something went wrong. Please try again");
            }
            return invItem;
        }

        /// <summary>
        /// Creates new change object and returns it.  Records to transaction file logger.
        /// </summary>
        /// <returns></returns>
        public Change MakeChange()
        {          
            Change changeReturned = new Change(CurrentBalance);
            _transactionFileLogger.RecordReturnChange(CurrentBalance);
            return changeReturned;
        }

        public void CompletePurchase()
        {
            //CODE_REVIEW
            //Move this to the report class.
            CurrentBalance = 0;
            _salesFullPath = Path.Combine(_salesDirectory, _salesFilePath);
            using (StreamWriter sw = new StreamWriter(_salesFullPath, false))
            {
                for(int i = 0; i<_salesReport.Count; i++)
                {
                    sw.WriteLine(_salesReport[i]);
                }
                sw.WriteLine($"**TOTAL SALES** ${_totalSales}");
            }
        }
        #endregion
    }
}