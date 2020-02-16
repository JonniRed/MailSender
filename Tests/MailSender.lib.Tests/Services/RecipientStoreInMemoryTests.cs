using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services.InMemory;

namespace MailSender.lib.Tests.Services
{
    [TestClass]
    public class RecipientStoreInMemoryTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Create_throw_ArgumentNullException_if_item_is_null()
        {
            var store = new RecipientStoreInMemory();
            store.Create(null);
        }
        [TestMethod]
        public void Create_throw_ArgumentNullException_if_item_is_null_2()
        {
            var store = new RecipientStoreInMemory();
            Assert.ThrowsException<ArgumentNullException>(() => store.Create(null));
        }
      
    }
}
