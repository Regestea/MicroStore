﻿using Microsoft.EntityFrameworkCore;
using UserAccount.Application.Common.Interfaces;
using UserAccount.Application.Common.Models.User;
using UserAccount.Domain.Entities;
using UserAccount.Infrastructure.Persistence;

namespace UserAccount.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserAccountContext _context;

        public UserRepository(UserAccountContext context)
        {
            _context = context;
        }


        public async Task<User?> GetUserAsync(Guid userId)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<bool> IsEmailExist(string email)
        {
            bool exist = await _context.Users.AnyAsync(x => x.Email == email.Trim().ToLower());

            return exist;
        }

        public async Task<bool> AddUserImage(string userId, string imagePath)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(userId));

            if (user == null)
            {
                return false;
            }
            user.Image = imagePath;

            _context.Users.Update(user);

            var result = await _context.SaveChangesAsync();

            return (result >= 1);
        }

        public async Task<bool> EditUserImage(string userId, string newImagePath)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(userId));

            user.Image = newImagePath;

            _context.Users.Update(user);

            var result = await _context.SaveChangesAsync();

            return (result >= 1);
        }

        public async Task<bool> IsUserExist(string userId)
        {
            Guid userGuid = Guid.Parse(userId);
            return await _context.Users.AnyAsync(x => x.Id == userGuid);
        }

        public async Task<Guid> CreateUserAsync(CreateUserModel userModel)
        {
            var user = new User()
            {
                Name = userModel.Name.Trim().ToLower(),
                Email = userModel.Email.Trim().ToLower()
            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
