using System.Collections.Generic;
using Confab.Shared.Abstractions.Auth;

namespace Confab.Shared.Infrastructure.Auth
{
    public sealed class AuthManager: IAuthManager
    {
        public JsonWebToken CreateToken(string userId, string role = null, string audience = null, IDictionary<string, IEnumerable<string>> claims = null)
        {
            throw new System.NotImplementedException();
        }
    }
}