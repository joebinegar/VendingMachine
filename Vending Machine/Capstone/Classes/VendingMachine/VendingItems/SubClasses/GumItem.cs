using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    class GumItem : VendingItem
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="price"></param>
        public GumItem(string itemName, decimal price) : base(itemName, price)
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
            return "Chew Chew, Yum!";
        }

        #endregion
    }
}
