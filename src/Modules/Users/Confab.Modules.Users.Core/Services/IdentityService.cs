using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Users.Core.DTO;
using Confab.Modules.Users.Core.Entities;
using Confab.Modules.Users.Core.Exceptions;
using Confab.Modules.Users.Core.Repositories;
using Confab.Shared.Abstractions.Auth;
using Confab.Shared.Abstractions.Messaging;
using Confab.Shared.Abstractions.Time;
using Microsoft.AspNetCore.Identity;

namespace Confab.Modules.Users.Core.Services
{
    internal class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAuthManager _authManager;
        private readonly IClock _clock;
        //private readonly IMessageBroker _messageBroker;

        public IdentityService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IAuthManager authManager, IClock clock)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _authManager = authManager;
            _clock = clock;
        }
        public async Task<AccountDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return user is null
                ? null
                : new AccountDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = user.Claims,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt
                };
        }

        public async Task SignUpAsync(SingUpDto dto)
        {
            dto.Id = Guid.NewGuid();
            var email = dto.Email.ToLowerInvariant();
            var user = await _userRepository.GetAsync(email);
            
            if (user is not null)
            {
                throw new EmailInUseException();
            }

            var password = _passwordHasher.HashPassword(default, dto.Password);

            user = new User
            {
                Id = dto.Id,
                Email = email,
                Claims = dto.Claims ?? new Dictionary<string, IEnumerable<string>>(),
                Password = password,
                Role = dto.Role?.ToLowerInvariant() ?? "user",
                CreatedAt = _clock.CurrentDate(),
                IsActive = true
            };

            await _userRepository.AddAsync(user);
        }

        public Task<JsonWebToken> SignInAsync(SignInDto dto)
        {
            throw new NotImplementedException();
        }
    }
}