using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services
{
    public class StoreService : IStoreService
    {
        private readonly ApplicationDbContext _context;
        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Manually adding store items to the list of store items.
        //This is because we want some default items there that would otherwise
        //not be in this project at the start of launching the project.
        //This is done purely because we didn't introduce seed data yet on Friday.
        //This however is a technique absolutely used in the book.
        public Task<StoreItem[]> GetStoreItemsAsync()
        {
            var item1 = new StoreItem
            {
                Id = Guid.NewGuid(),
                Name = "Television",
                price = 400
            };
            var item2 = new StoreItem
            {
                Id = Guid.NewGuid(),
                Name = "Microwave",
                price = 200
            };
            var item3 = new StoreItem
            {
                Id = Guid.NewGuid(),
                Name = "Lamppost",
                price = 50
            };
            return Task.FromResult(new[] { item1, item2, item3 });
        }

        public async Task<StoreItem[]> GetStoreItemsInCartAsync()
        {
            return await _context.UserCart.ToArrayAsync();
        }

        public async Task<bool> AddItemToUserCartAsync(StoreItem newItem)
        {
            _context.UserCart.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> RemoveItemFromUserCartAsync(Guid id)
        {
            var itemToBeRemoved = new StoreItem { Id = id };
            _context.UserCart.Attach(itemToBeRemoved);
            _context.UserCart.Remove(itemToBeRemoved);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }
    }
}
