
using Bbsm_Garage_Son.Models;
using Bbsm_Garage_Son.Entity;

namespace Bbsm_Garage_Son.Interfaces
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(GenerateTokenRequest request);
        
    }
}
