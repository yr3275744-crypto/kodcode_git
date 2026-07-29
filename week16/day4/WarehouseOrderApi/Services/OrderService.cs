using WarehouseOrderApi.Models;
using WarehouseOrderApi.Repositories;
using WarehouseOrderApi.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace WarehouseOrderApi.Services;

public class OrderService : IOrderService
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    public OrderService(
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }
    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }
    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }
    public async Task<Order> CreateOrderAsync(CreateOrderRequest request)
    {
        Product? product = await _productRepository.GetByIdAsync(request.ProductId);
        if (product == null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }
        if (product.QuantityInStock < request.Quantity)
        {
            throw new InsufficientInventoryException(
                product.Id,
                request.Quantity,
                product.QuantityInStock);
        }
        decimal totalPrice = product.UnitPrice * request.Quantity;

        Order order = new Order()
        {
            CustomerName = request.CustomerName,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            TotalPrice = totalPrice,
            Status = "Confirmed"
        };

        Order createdOrder = await _orderRepository.CreateAsync(order);

        await _productRepository.UpdateStockAsync(product.Id, -request.Quantity);
        return createdOrder;

    }
}
