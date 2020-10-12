﻿using BinInfo.Models;
using System;
using Xunit;

namespace BinInfo.Tests
{
    public class BinListTests
    {
        [Fact]
        public void Find_BinList_Test()
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
            Assert.Equal(16, info.Number.Length);
            Assert.True(info.Number.Luhn);
            Assert.False(info.Prepaid);
        }

        [Fact]
        public async void Find_BinList_Async_Test()
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
            Assert.Equal(16, info.Number.Length);
            Assert.True(info.Number.Luhn);
            Assert.False(info.Prepaid);
        }

        [Fact]
        public void ArgumentNullException_BinList_Test()
        {
            Assert.Throws<ArgumentNullException>(() => BinList.Find(null));
        }

        [Fact]
        public void ArgumentException_BinList_Test()
        {
            Assert.Throws<ArgumentException>(() => BinList.Find("333g12"));
        }

        [Fact]
        public void ArgumentException_BinList_Empty_Test()
        {
            Assert.Throws<ArgumentException>(() => BinList.Find(""));
        }

        [Fact]
        public async void ArgumentNullException_BinList_Async_Test()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => BinList.FindAsync(null));
        }

        [Fact]
        public async void ArgumentException_BinList_Async_Test()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => BinList.FindAsync("333g12"));
        }

        [Fact]
        public async void ArgumentException_BinList_Empty_Async_Test()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => BinList.FindAsync(""));
        }

        [Fact]
        public void Find_BinList_LuhnIsNull_Test()
        {
            IssuerInformation info = BinList.Find("429650");

            Assert.Equal("visa", info.Scheme);
            Assert.Equal("US", info.Country.Alpha2);
            Assert.Equal("United States of America", info.Country.Name);
            Assert.Equal("TWINSTAR C.U.", info.Bank.Name);
            Assert.Equal("credit", info.CardType);
            Assert.Equal("38", info.Country.Latitude);
            Assert.Equal("-97", info.Country.Longitude);
            Assert.Equal("Traditional", info.Brand);
            Assert.Equal(16, info.Number.Length);
            Assert.Null(info.Number.Luhn);
        }
    }
}
