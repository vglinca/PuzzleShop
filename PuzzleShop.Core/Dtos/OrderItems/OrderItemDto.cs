﻿using PuzzleShop.Core.Dtos.Puzzles;

namespace PuzzleShop.Core.Dtos.OrderItems
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public PuzzleTableRowDto Puzzle { get; set; }
    }
}