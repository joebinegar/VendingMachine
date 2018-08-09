using System;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{   
    [TestClass]
    public class VMClassTests
    {
        VendingMachine vm = new VendingMachine();

        [TestMethod]
        public void FeedMoney()
        {
            vm.FeedMoney(25);
            Assert.AreEqual(25, vm.CurrentBalance, "Input: FeedMoney(25).");
            try
            {
                vm.FeedMoney(-1);
                Assert.Fail();
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Please enter a dollar amount greater than 0.", ex.Message, "Input: vm.FeedMoney(-1)");
            }        
        }

        [TestMethod]
        public void ReturnChange()
        {
            Change changeReturned = new Change(5.55M);
            Assert.AreEqual(1, changeReturned.Nickels, "Input: changeReturned.Nickels.");
            Assert.AreEqual(0, changeReturned.Dimes, "Input: changeReturned.Dimes.");
            Assert.AreEqual(22, changeReturned.Quarters, "Input: changeReturned.Quarters.");
        }

        [TestMethod]
        public void GetItem()
        {
            vm.ReadFile();
            Assert.AreEqual("Potato Crisps", vm._inventory["A1"].ItemName.Name, "Input: vm._inventory[A1].ItemName.Name");
            Assert.AreEqual(5, vm._inventory["A1"].Quantity);
            vm.FeedMoney(25);
            vm.PurchaseItem("A1");
            Assert.AreEqual(4, vm._inventory["A1"].Quantity);
            Assert.AreEqual(21.95M, vm.CurrentBalance);
        }
        [TestMethod]
        public void CompletePurchase()
        {
            Assert.AreEqual(0.00M, vm.CurrentBalance);
        }
        
      
   
    // [TestMethod]
    //public InventoryItem GetItem(string slotId)
    //{
    //    Assert.AreEqual()
    //}

}
}
