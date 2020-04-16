using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PuzzleShop.Core.Dtos.Images
{
	public class ImageForUpdateDto
	{
		public long? Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public byte[] Bytes { get; set; }
	}
}
