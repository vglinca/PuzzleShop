﻿using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.Manufacturers
{
    public class ManufacturerForCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}