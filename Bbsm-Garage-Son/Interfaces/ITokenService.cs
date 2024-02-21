using Bbsm_Garage_Son.Models;

namespace Bbsm_Garage_Son.Interfaces
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
