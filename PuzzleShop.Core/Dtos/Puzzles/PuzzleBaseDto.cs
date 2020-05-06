using PuzzleShop.Core.Dtos.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Dtos.Puzzles
{
	public abstract class PuzzleBaseDto
	{
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsMagnetic { get; set; }
        public double Weight { get; set; }
        public double? Rating { get; set; }
        public int AvailableInStock { get; set; }
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
