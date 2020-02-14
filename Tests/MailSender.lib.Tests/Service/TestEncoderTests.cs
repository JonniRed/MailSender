using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Service;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class TestEncoderTests
    {
        [TestMethod]
        public void Encode_ABC_to_BCD_with_key_1()
        {
            const string str = "ABC";
            const int key = 1;
            const string expected_str = "BCD";

            var actual_str = TextEncoder.Encode(str, key);

            Assert.AreEqual(expected_str, actual_str);
        }
    }
}
