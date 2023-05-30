using System;
using Microsoft.EntityFrameworkCore;

namespace Order.Services.Models;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; } = default!;
}

