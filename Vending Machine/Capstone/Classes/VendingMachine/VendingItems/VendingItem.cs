using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingItem
    {
        #region Properties
       
        public string Name { get;  }
        public decimal Price { get; }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="price"></param>
        public VendingItem(string itemName, decimal price)
        {
            Name = itemName;
            Price = price;

        }


        #endregion

        #region Methods

        public abstract string Consume();

        #endregion

    }
}
