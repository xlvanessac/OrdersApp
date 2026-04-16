namespace OrdersApp.Services;

using Microsoft.EntityFrameworkCore;
using OrdersApp.Data;
using OrdersApp.Models;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task CreateAsync(Order order);
}

public class OrderService : IOrderService
{
    private readonly AppDbContext _db;

    public OrderService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Order>> GetAllAsync()
        => await _db.Orders.ToListAsync();

    public async Task<Order?> GetByIdAsync(int id)
        => await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);

    public async Task CreateAsync(Order order)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
    }
}