using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PuzzleShop.Core.Dtos.Reviews
{
	public class ReviewForCreationDto
	{
		[Required]
		public string ReviewerName { get; set; }
		[EmailAddress]
		public string ReviewerEmail { get; set; }
		public double? Rating { get; set; }
		[MaxLength(100)]
		public string ReviewTitle { get; set; }
		[MaxLength(1500)]
		public string ReviewBody { get; set; }
	}
}
