using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _storeService.GetStoreItemsAsync();
            var itemsInCart = await _storeService.GetStoreItemsInCartAsync();

            var model = new StoreItemListViewModel()
            {
                StoreItems = items,
                StoreItemsInCart = itemsInCart
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItemToCart(StoreItem storeItem)
        {
            var successful = await _storeService.AddItemToUserCartAsync(storeItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItemFromCart(Guid id)
        {
            var successful = await _storeService.RemoveItemFromUserCartAsync(id);
            if (!successful)
            {
                return BadRequest("Could not remove item.");
            }
            return RedirectToAction("Index");
        }
    }
}
