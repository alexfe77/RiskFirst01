using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.ViewModels
{
    public class GroupViewModel
    {
        public IEnumerable<IEnumerable<AddressItem>> Cities { get; set; }
    }
}
