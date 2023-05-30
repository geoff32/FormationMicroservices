using System;
using Microsoft.EntityFrameworkCore;

namespace Payment.Services.Models;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; } = default!;
}

