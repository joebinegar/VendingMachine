using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
   public class InventoryItem
    {
        #region Properties
       
        public VendingItem ItemName { get; }
        public int Quantity { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="quantity"></param>
        public InventoryItem(VendingItem itemName, int quantity)
        {
            ItemName = itemName;
            Quantity = quantity;
        }

        #endregion
    }
}
