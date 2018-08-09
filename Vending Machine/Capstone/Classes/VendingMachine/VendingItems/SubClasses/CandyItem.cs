using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class CandyItem : VendingItem
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="price"></param>
        public CandyItem(string itemName, decimal price) : base(itemName, price)
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
           return "Munch Munch, Yum!";
        }

        #endregion
    }
}
