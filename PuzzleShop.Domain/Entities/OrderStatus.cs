using System;
using System.Collections.Generic;
using System.Text;
// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
	public class OrderStatus : BaseEntity
	{
		public OrderStatusId OrderStatusId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
	}
}
