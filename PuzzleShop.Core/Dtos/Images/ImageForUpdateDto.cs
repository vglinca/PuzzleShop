using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PuzzleShop.Core.Dtos.Images
{
	public class ImageForUpdateDto
	{
		public long? Id { get; set; }
		public string Title { get; set; }
		// [Required]
		public IFormFile File { get; set; }
	}
}
