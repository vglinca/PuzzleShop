using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Domain.Entities
{
	public class Review : BaseEntity
	{
		public long PuzzleId { get; set; }
		public virtual Puzzle Puzzle { get; set; }
		public string ReviewerName { get; set; }
		public string ReviewerEmail { get; set; }
		public double? Rating { get; set; }
		public string ReviewTitle { get; set; }
		public string ReviewBody { get; set; }
	}
}
