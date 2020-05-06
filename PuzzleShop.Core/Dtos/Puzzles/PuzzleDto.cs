using PuzzleShop.Core.Dtos.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Dtos.Puzzles
{
	public class PuzzleDto : PuzzleBaseDto
	{
        //public long Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public decimal Price { get; set; }
        //public bool IsMagnetic { get; set; }
        //public double Weight { get; set; }
        public long ManufacturerId { get; set; }
        public long PuzzleTypeId { get; set; }
        public long ColorId { get; set; }
        public long MaterialTypeId { get; set; }
        //public double? Rating { get; set; }
        //public int AvailableInStock { get; set; }
        //public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
