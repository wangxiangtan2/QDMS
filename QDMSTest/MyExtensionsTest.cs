﻿// -----------------------------------------------------------------------
// <copyright file="MyExtensionsTest.cs" company="">
// Copyright 2013 Alexander Soffronow Pagonidis
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using QDMS;

namespace QDMSTest
{
    [TestFixture]
    public class MyExtensionsTest
    {
        private List<OHLCBar> _ohlcData;

        [SetUp]
        public void SetUp()
        {
            _ohlcData = new List<OHLCBar>
            {
                new OHLCBar {DT = new DateTime(2000, 1, 1), Open = 100, High = 105, Low = 95, Close = 100},
                new OHLCBar {DT = new DateTime(2000, 1, 2), Open = 99, High = 107, Low = 90, Close = 99},
                new OHLCBar {DT = new DateTime(2000, 1, 3), Open = 57, High = 95, Low = 50, Close = 50},
                new OHLCBar {DT = new DateTime(2000, 1, 4), Open = 100, High = 105, Low = 95, Close = 100},
                new OHLCBar {DT = new DateTime(2000, 1, 5), Open = 100, High = 105, Low = 95, Close = 100},
                new OHLCBar {DT = new DateTime(2000, 1, 6), Open = 100, High = 105, Low = 95, Close = 100},
                new OHLCBar {DT = new DateTime(2000, 1, 7), Open = 100, High = 105, Low = 95, Close = 100},
                new OHLCBar {DT = new DateTime(2000, 1, 8), Open = 200, High = 300, Low = 50, Close = 100}
            };
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexOfCorrectlyThrowsNullException()
        {
            var list = new List<double>();
            list.IndexOf(null);
        }

        [Test]
        public void RIndexOfeturnsMinusOneIfNotFound()
        {
            int index = _ohlcData.IndexOf(x => x.DT > new DateTime(2001, 1, 1));
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void IndexOfReturnsCorrectIndex()
        {
            int index = _ohlcData.IndexOf(x => x.Open == 100);
            Assert.AreEqual(0, index);

            index = _ohlcData.IndexOf(x => x.Open >= 200);
            Assert.AreEqual(7, index);
        }

        [Test]
        [ExpectedException]
        public void MostFrequentThrowsExceptionWhenCalledOnEmptyList()
        {
            var emptyList = new List<int>();
            emptyList.MostFrequent();
        }

        [Test]
        public void MostFrequentReturnsTheFirstEncounteredMostFrequentElement()
        {
            var data = new List<int> { 5, 6, 4, 1, 2, 5, 6, 5, 6, 9, 0, 0, 5, 6, 0, 3, 4, 7, 8 };
            Assert.AreEqual(5, data.MostFrequent());
        }
    }
}
