﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0154 : MidTester
    {
        [TestMethod]
        public void Mid0154Revision1()
        {
            string package = "00200154            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0154), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
