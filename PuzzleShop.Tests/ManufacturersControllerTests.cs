using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PuzzleShop.Api.Controllers;
using PuzzleShop.Api.Dtos.Manufacturers;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Manufacturers;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.Profiles;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Tests.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleShop.Tests
{
	[TestFixture]
	public class ManufacturersControllerTests
	{
		ManufacturersController _manufacturersController;
		IImageRepository<Manufacturer> _repository;
		IMapper _mapper;

		public ManufacturersControllerTests()
		{
			_repository = new ManufacturerRepositoryFake();
		}

		[SetUp]
		public void Setup()
		{
			var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new ManufacturerProfile()));
			_mapper = mockMapper.CreateMapper();
			_manufacturersController = new ManufacturersController(_repository, _mapper);
		}

		[TestCase]
		public void GetManufacturers_Returns_OkObjectResult()
		{
			var okResult = _manufacturersController.GetManufacturers();
			Assert.IsInstanceOf<OkObjectResult>(okResult.Result);
		}

		[TestCase]
		public async Task GetManufacturers_ReturnsCollectionOfManufacturerDto_WithNonZeroSize()
		{
			var manufacturers = new List<ManufacturerDto>();
			var result = await _manufacturersController.GetManufacturers();
			var models = result as ObjectResult;
			manufacturers.AddRange((IEnumerable<ManufacturerDto>) models.Value);

			Assert.AreEqual(5, manufacturers.Count);
		}

		[TestCase]
		public async Task GetManufacturerById_ReturnSpecifiedDto()
		{
			var manufacturerDto = new ManufacturerDto();
			var result = await _manufacturersController.GetManufacturer(1);
			var model = result as ObjectResult;
			manufacturerDto = model.Value as ManufacturerDto;

			Assert.AreEqual("Gan", manufacturerDto.Name);
		}

		[TestCase]
		public void GetManufacturerById_ThrowsEntityNotFoundException_WhenDoesNotExist()
		{
			Assert.ThrowsAsync<EntityNotFoundException>(async () =>
				await _manufacturersController.GetManufacturer(7));
		}

		[TestCase]
		public async Task AddManufacturer_Returns201Created()
		{
			var creationDto = new ManufacturerForCreateDto
			{
				Name = "ShengShou",
				Description = "Test Description"
			};
			var createdResponse = await _manufacturersController.AddManufacturer(creationDto) as CreatedAtActionResult;
			var model = createdResponse.Value as ManufacturerDto;

			Assert.AreEqual(creationDto.Name, model.Name);
		}

		[TestCase]
		public async Task UpdateManufacturerTest()
		{
			var dtoForUpdate = new ManufacturerForUpdateDto
			{
				Name = "Rubics",
				Description = "Updated Description"
			};
			var response = await _manufacturersController.UpdateManufacturer(4, dtoForUpdate);
			Assert.IsInstanceOf<OkResult>(response);
		}

		[TestCase]
		public void DeleteManufacturer_ReturnsEntityNotFoundException()
		{
			Assert.ThrowsAsync<EntityNotFoundException>(async () =>
			await _manufacturersController.DeleteManufacturer(20));
		}

		[TestCase]
		public async Task DeleteManufacturerTest()
		{
			var response = await _manufacturersController.DeleteManufacturer(2);
			Assert.IsInstanceOf<NoContentResult>(response);
		}
	}
}
