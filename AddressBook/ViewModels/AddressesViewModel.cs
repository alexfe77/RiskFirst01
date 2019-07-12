using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.ViewModels
{
    public class AddressesViewModel
    {
        public IEnumerable<AddressItem> Addresses { get; set; }
    }
}
