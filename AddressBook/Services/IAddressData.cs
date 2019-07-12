using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public interface IAddressData
    {
        IEnumerable<IEnumerable<AddressItem>> GetGrouped();

        IEnumerable<string> GetCities();

        IEnumerable<AddressItem> GetAddresses(string city);

        AddressItem GetAddress(int id);

    }
}
