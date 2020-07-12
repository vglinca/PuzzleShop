using System.Collections.Generic;
using PuzzleShop.Core.Domain;

// ReSharper disable All

namespace PuzzleShop.Core.Entities
{
	public class OrderStatus : BaseEntity
	{
		public OrderStatusId OrderStatusId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
	}
}
