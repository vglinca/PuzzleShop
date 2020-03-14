﻿using System.ComponentModel.DataAnnotations;
// ReSharper disable All

namespace PuzzleShop.Api.Dtos.Manufacturers
{
    public class ManufacturerDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}