using System;
using System.Threading.Tasks;
using Confab.Modules.Users.Core.DTO;
using Confab.Modules.Users.Core.Entities;
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
        private readonly IMessageBroker _messageBroker;
        public Task<AccountDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SignUpAsync(SingUpDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<JsonWebToken> SignInAsync(SignInDto dto)
        {
            throw new NotImplementedException();
        }
    }
}