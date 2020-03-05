﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// ReSharper disable All

#nullable enable
namespace PuzzleShop.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}