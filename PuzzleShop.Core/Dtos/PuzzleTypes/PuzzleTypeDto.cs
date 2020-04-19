using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Dtos.PuzzleTypes
{
	public class PuzzleTypeDto
	{
		public long Id { get; set; }
		public bool IsRubicsCube { get; set; }
		public bool IsWca { get; set; }
		public string Title { get; set; }
		public long DifficultyLevelId { get; set; }
	}
}
