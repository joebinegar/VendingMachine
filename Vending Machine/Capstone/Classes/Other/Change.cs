using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class Change
    {
        #region Properties

        public int Dimes { get; private set; } = 0;
        public int Nickels { get; private set; } = 0;
        public int Quarters { get; private set; } = 0;
        
        #endregion

        #region Constructors

        public Change(decimal amountInDollars)
        {
            int amountInCents = (int)(amountInDollars * 100);
            Quarters = amountInCents / 25;
            Dimes = (amountInCents % 25) / 10;
            Nickels = ((amountInCents % 25) % 10) / 5;
        }

        #endregion
    }
}
