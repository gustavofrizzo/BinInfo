using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinInfo;
using BinInfo.Models;

namespace BinInfoUnitTest
{
    [TestClass]
    public class BinInfoUnitTest
    {
        [TestMethod]
        public void Find_BinListTest()
        {
            IssuerInformation info = BinList.Find("431940");
            
            Assert.AreEqual("visa", info.Scheme);
            Assert.AreEqual("IE", info.Country.Alpha2);
            Assert.AreEqual("Ireland", info.Country.Name);
            Assert.AreEqual("BANK OF IRELAND", info.Bank.Name);
            Assert.AreEqual("debit", info.CardType);
            Assert.AreEqual("53", info.Country.Latitude);
            Assert.AreEqual("-8", info.Country.Longitude);
            Assert.AreEqual("Traditional", info.Brand);
            Assert.AreEqual(false, info.Prepaid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullException_BinListTest()
        {
            var info = BinList.Find(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentException_BinListTest()
        {
            var info = BinList.Find("333g12");
        }
    }
}
