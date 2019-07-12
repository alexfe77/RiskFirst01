using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddressBook.Services;
using AddressBook.ViewModels;

namespace AddressBook.Controllers
{
    //[Authorize]
    public class AddressController : Controller
    {
        private IAddressData _AddressData;

        public AddressController(IAddressData data)
        {
            _AddressData = data;
        }


        [Route("/")]
        public IActionResult GetGrouped()
        {
            var model = new GroupViewModel();
            model.Cities = _AddressData.GetGrouped();
            return View(model);
        }

        [Route("cities")]
        public IActionResult GetCities()
        {
            var model = new CitiesViewModel();
            model.Cities = _AddressData.GetCities();
            return View(model);
        }

        [Route("city/{name?}")]
        public IActionResult GetAddresses(string name)
        {
            var model = new AddressesViewModel();
            model.Addresses = _AddressData.GetAddresses(name);
            return View(model);
        }

        [Route("address/{id?}")]
        public IActionResult GetAddress(int id)
        {
            var model = new AddressViewModel();
            model.Address = _AddressData.GetAddress(id);
            return View(model);
        }

    }
}
