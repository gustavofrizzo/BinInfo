using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinInfo;

namespace BinInfoUnitTest
{
    [TestClass]
    public class BinInfoUnitTest
    {
        [TestMethod]
        public void Find_BinListTest()
        {
            IssuerInformation info = BinList.Find("431940");

            Assert.AreEqual("431940", info.Bin);
            Assert.AreEqual("VISA", info.Brand);
            Assert.AreEqual("IE", info.CountryCode);
            Assert.AreEqual("Ireland", info.CountryName);
            Assert.AreEqual("BANK OF IRELAND", info.Bank);
            Assert.AreEqual("DEBIT", info.CardType);
            Assert.AreEqual("53", info.Latitude);
            Assert.AreEqual("-8", info.Longitude);
            Assert.AreEqual("", info.SubBrand);
            Assert.AreEqual("", info.CardCategory);
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
