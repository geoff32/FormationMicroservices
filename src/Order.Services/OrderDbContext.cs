using System;
using Microsoft.EntityFrameworkCore;

namespace Order.Services;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Order> Orders { get; set; } = default!;
}

