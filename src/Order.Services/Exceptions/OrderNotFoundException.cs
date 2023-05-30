using System;
namespace Order.Services.Exceptions;


public class OrderNotFoundException : Exception
{
	public OrderNotFoundException(Guid id) : base($"Order {id} not found")
	{
	}
}

