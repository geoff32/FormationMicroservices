using System;
using Microsoft.EntityFrameworkCore;

namespace Payment.Services;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Payment> Payments { get; set; } = default!;
}

