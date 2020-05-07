using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PuzzleShop.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BaseController : ControllerBase
	{
		protected readonly IMapper _mapper;

		public BaseController(){}
		public BaseController(IMapper mapper)
		{
			_mapper = mapper;
		}
	}
}
