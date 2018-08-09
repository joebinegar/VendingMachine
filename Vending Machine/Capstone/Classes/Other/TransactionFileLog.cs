using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
   public class TransactionFileLog
    {
        #region Member Variables

        string _directory = Environment.CurrentDirectory;
        string _filePath = "Log.txt";
        string _fullPath = " ";

        #endregion

        #region Constructor

        public TransactionFileLog(string filePath)
        {
            _filePath = filePath;
            _fullPath = Path.Combine(_directory, _filePath);
        }

        #endregion;

        #region Methods
        public void RecordGetItem(string itemName, string slotId, decimal price, decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter(_fullPath, true))
            {
                sw.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", $"{DateTime.Now}", $" {itemName} {slotId}", $" ${price}", $" ${currentBalance}");
            }
        }

        public void RecordDeposit(int depositAmount, decimal currentBalance)
        {

            using (StreamWriter sw = new StreamWriter(_fullPath, true))
            {
                sw.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", $"{DateTime.Now}", " FEED MONEY:", $" ${depositAmount}", $" ${currentBalance}");

            }
        }

        public void RecordReturnChange(decimal amtInDol)
        {
            using (StreamWriter sw = new StreamWriter(_fullPath, true))
            {
                sw.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", $"{DateTime.Now}", " GIVE CHANGE:", $" ${amtInDol}", " $0.00");
            }
        }
        #endregion

    }        
}
