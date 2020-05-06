using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Helpers
{
	public class RoleAuthorizeAttribute : AuthorizeAttribute
	{
		public RoleAuthorizeAttribute(params string[] roles)
		{
			Roles = string.Join(',', roles);
		}
	}
}
