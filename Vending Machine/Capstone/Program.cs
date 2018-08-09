using Capstone.Classes;
using Capstone.CLI;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();
            VendingMachineCLI mainmenu = new VendingMachineCLI(vm);
            mainmenu.Display();
        }
    }
}