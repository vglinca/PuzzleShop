using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PuzzleShop.Core.Dtos.Reviews
{
	public class ReviewDto
	{
		public long Id { get; set; }
		public long PuzzleId { get; set; }
		public string ReviewerName { get; set; }
		public string ReviewerEmail { get; set; }
		public double? Rating { get; set; }
		public string ReviewTitle { get; set; }
		public string ReviewBody { get; set; }
	}
}
