using AspNetCoreTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services
{
    public interface IStoreService
    {
        Task<StoreItem[]> GetStoreItemsAsync();

        Task<bool> AddItemToUserCartAsync(StoreItem newItem);

        Task<bool> RemoveItemFromUserCartAsync(Guid id);

        Task<StoreItem[]> GetStoreItemsInCartAsync();
    }
}
