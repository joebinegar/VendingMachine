using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class InvalidSlotIDException : SystemException
    {

        //Delete this entire class if new way of throwing exceptions works.
        public InvalidSlotIDException(string message)
        {
            //CODE_REVIEW
            //This should not write to the console
            Console.WriteLine(message);
        }
    }
}
