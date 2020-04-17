using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PuzzleShop.Api.Controllers;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Core.Profiles;
using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleShop.Tests
{
	[TestFixture]
	public class ColorsControllerTests
	{
		private ColorsController _colorsController;
		private IMapper _mapper;
		private Mock<IImageRepository<Color>> _mock;

		public ColorsControllerTests()
		{
			_mock = new Mock<IImageRepository<Color>>();
		}

		[SetUp]
		public void Setup()
		{
			var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new ColorProfile()));
			_mapper = mockMapper.CreateMapper();
			_mock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Color>
			{
				new Color{Id = 1, Title = "Red"},
				new Color{Id = 2, Title = "White"},
				new Color{Id = 3, Title = "Blue"},
				new Color{Id = 4, Title = "Black"},
			});
			_colorsController = new ColorsController(_mock.Object, _mapper);
		}

		[TestCase]
		public async Task GetColorsTest()
		{
			var colors = new List<ColorDto>();
			var result = await _colorsController.GetColors();
			var models = result as ObjectResult;
			colors.AddRange((IEnumerable<ColorDto>) models.Value);
			Assert.AreEqual(4, colors.Count);
		}
	}
}
