using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;

namespace BookStore.Domain.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly  IInventoryRepository _inventoryRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        public InventoryService(IInventoryRepository inventoryRepository, 
            IBookRepository bookRepository, 
            IOrderRepository orderRepository)
        {
            _inventoryRepository = inventoryRepository;
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Inventory> GetById(int id, CancellationToken cancellationToken)
        {
            return await _inventoryRepository.GetById(id, cancellationToken);
        }

        public async Task<Inventory> Add(Inventory inventory, CancellationToken cancellationToken)
        {
            if (_inventoryRepository.Search(b => b.Id == inventory.Id, cancellationToken).Result.Any())
                return null;

            if (await _bookRepository.GetById(inventory.Id, cancellationToken) is null)
                return null;

            await _inventoryRepository.Add(inventory, cancellationToken);
            return inventory;
        }

        public async Task<Inventory> Update(Inventory inventory, CancellationToken cancellationToken)
        {
            if (_inventoryRepository.Search(b => b.Id != inventory.Id, cancellationToken).Result.Any())
                return null;

            await _inventoryRepository.Update(inventory, cancellationToken);
            return inventory;
        }

        public async Task<bool> Remove(Inventory inventory, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByBookId(inventory.Id, cancellationToken);
            
            if (orders.Any(x => !x.IsAlreadyCancelled()))
                return false;

            await _inventoryRepository.Remove(inventory, cancellationToken);
            return true;
        }


        public async Task<IEnumerable<Inventory>> SearchInventoryForBook(string bookName, CancellationToken cancellationToken)
        {
            return await _inventoryRepository.SearchInventoryForBook(bookName, cancellationToken);
        }
    }
}
