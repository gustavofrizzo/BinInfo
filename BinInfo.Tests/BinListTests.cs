using BinInfo.Models;
using System;
using Xunit;

namespace BinInfo.Tests
{
    public class BinListTests
    {
        [Fact]
        public void Find_BinListTest()
        {
            IssuerInformation info = BinList.Find("431940");

            Assert.Equal("visa", info.Scheme);
            Assert.Equal("IE", info.Country.Alpha2);
            Assert.Equal("Ireland", info.Country.Name);
            Assert.Equal("BANK OF IRELAND", info.Bank.Name);
            Assert.Equal("debit", info.CardType);
            Assert.Equal("53", info.Country.Latitude);
            Assert.Equal("-8", info.Country.Longitude);
            Assert.Equal("Traditional", info.Brand);
            Assert.False(info.Prepaid);
        }

        [Fact]
        public async void Find_BinListTestAsync()
        {
            IssuerInformation info = await BinList.FindAsync("431940");

            Assert.Equal("visa", info.Scheme);
            Assert.Equal("IE", info.Country.Alpha2);
            Assert.Equal("Ireland", info.Country.Name);
            Assert.Equal("BANK OF IRELAND", info.Bank.Name);
            Assert.Equal("debit", info.CardType);
            Assert.Equal("53", info.Country.Latitude);
            Assert.Equal("-8", info.Country.Longitude);
            Assert.Equal("Traditional", info.Brand);
            Assert.False(info.Prepaid);
        }

        [Fact]
        public void ArgumentNullException_BinListTest()
        {
            Assert.Throws<ArgumentNullException>(() => BinList.Find(null));
        }

        [Fact]
        public void ArgumentException_BinListTest()
        {
            Assert.Throws<ArgumentException>(() => BinList.Find("333g12"));
        }
    }
}
