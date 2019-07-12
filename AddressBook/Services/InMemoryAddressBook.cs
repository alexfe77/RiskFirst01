using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using Newtonsoft.Json;

namespace AddressBook.Services
{
    public class InMemoryAddressBook : IAddressData
    {
        public const string PATH = ".\\data\\AddressBook.json";

        public Dictionary<int, AddressItem> _AddressById = new Dictionary<int, AddressItem>();
        public Dictionary<string, List<AddressItem>> _AddressesByCity = new Dictionary<string, List<AddressItem>>();
        public Dictionary<string, string> _Cities = new Dictionary<string, string>();

        public InMemoryAddressBook()
        {
            LoadFromFile();
        }

        public AddressItem GetAddress(int id)
        {
            return _AddressById.ContainsKey(id) ? _AddressById[id] : new AddressItem { Id= -1 };
        }

        public IEnumerable<AddressItem> GetAddresses(string city)
        {
            return (!string.IsNullOrEmpty(city) && _AddressesByCity.ContainsKey(city.ToLower())) ? _AddressesByCity[city.ToLower()] : new List<AddressItem> { new AddressItem { Id = -1 } };
        }

        public IEnumerable<string> GetCities()
        {
            return _Cities.Values;
        }

        public IEnumerable<IEnumerable<AddressItem>> GetGrouped()
        {
            return _AddressesByCity.Values;
        }

        public void LoadFromFile()
        {
            var items = File.ReadAllText(PATH);
            var addresses = JsonConvert.DeserializeObject<AddressItem[]>(items);

            _AddressById.Clear();
            _AddressesByCity.Clear();
            _Cities.Clear();
            foreach (var item in addresses)
            {
                if (!_AddressById.ContainsKey(item.Id))
                {
                    _AddressById.Add(item.Id, item);
                }                
                if (!_AddressesByCity.ContainsKey(item.City.ToLower()))
                {
                    _AddressesByCity.Add(item.City.ToLower(), new List<AddressItem> { item });
                }
                else
                {
                    _AddressesByCity[item.City].Add(item);
                }
                if (!_Cities.ContainsKey(item.City.ToLower()))
                {
                    _Cities.Add(item.City.ToLower(), item.City);
                }
            }

        }

    }
}
