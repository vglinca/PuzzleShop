using System.ComponentModel.DataAnnotations;
// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Manufacturers
{
    public class ManufacturerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}