using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    class ChipItem : VendingItem
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="price"></param>
        public ChipItem(string itemName, decimal price) : base(itemName, price)
        {

        }

        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string Consume()
        {
            return "Crunch Crunch, Yum!";
        }

        #endregion
    }
}
