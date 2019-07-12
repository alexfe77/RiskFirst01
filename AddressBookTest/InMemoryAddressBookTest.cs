using AddressBook.Models;
using AddressBook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace AddressBookTest
{
    [TestClass]
    public class InMemoryAddressBookTest
    {
        private static IAddressData _AddressData;

        [ClassInitialize]
        public static void OneTimeSetUp(TestContext context)
        {
            _AddressData = new InMemoryAddressBook();
        }

        [TestMethod]
        public void Test_GetAddress()
        {
            var v = _AddressData.GetAddress(1);
            Assert.AreNotEqual(v, null, "GetAddress(1) returns null!");
            Assert.AreEqual(v.Id, 1, "GetAddress(1) returns address with different Id!");
        }

        [TestMethod]
        public void Test_GetAddresses()
        {
            var v = _AddressData.GetAddresses("London");
            Assert.AreNotEqual(v, null, "GetAddresses('London') returns null!");
            var vl = new List<AddressItem>(v);
            Assert.AreNotEqual(vl.Count, 0, "GetAddresses('London') returns empty collection!");
            foreach (var item in vl)
            {
                Assert.AreEqual(item.City?.ToLower(), "london", "GetAddresses('London') return not London address!");
            }
        }

        [TestMethod]
        public void Test_GetCities()
        {
            var v = _AddressData.GetCities();
            Assert.AreNotEqual(v, null, "GetCities() returns null!");
            var vl = new List<string>(v);
            Assert.AreNotEqual(vl.Count, 0, "GetCities() returns empty collection!");
        }

        [TestMethod]
        public void Test_GetGrouped()
        {
            var v = _AddressData.GetGrouped();
            Assert.AreNotEqual(v, null, "GetGrouped() returns null!");
            foreach (var list in v)
            {
                var vl = new List<AddressItem>(list);
                Assert.AreNotEqual(vl.Count, 0, "GetGrouped() returns empty collection!");
            }
        }

    }
}
