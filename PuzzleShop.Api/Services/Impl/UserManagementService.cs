﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Api.Services.Impl
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserManagementService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserWithRolesDto> GetUser(long userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new EntityNotFoundException($"User with Id {userId} not found.");
            }
            
            var userRoles = await _userManager.GetRolesAsync(user);
            var userWithRolesDto = _mapper.Map<UserWithRolesDto>(user);
            userWithRolesDto.Roles = userRoles;

            return userWithRolesDto;
        }

        public async Task EditUserRoles(long userId, IEnumerable<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new EntityNotFoundException($"User with Id {userId} not found.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var enumerable = roles as string[] ?? roles.ToArray();
            var addedRoles = enumerable.Except(userRoles);
            var removedRoles = userRoles.Except(enumerable);

            await _userManager.AddToRolesAsync(user, addedRoles);
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
        }

        public async Task BanUser(long userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new EntityNotFoundException($"User with Id {userId} not found.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRoleAsync(user, "banished");
        }

        public async Task UnbanUser(long userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new EntityNotFoundException($"User with Id {userId} not found.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRoleAsync(user, "user");
        }

        public async Task DeleteUser(long userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new EntityNotFoundException($"User with Id {userId} not found.");
            }

            await _userManager.DeleteAsync(user);
        }
    }
}