using Bbsm_Garage_Son.Interfaces;
using Bbsm_Garage_Son.Models;
using Bbsm_Garage_Son.Entity;

namespace Bbsm_Garage_Son.Services
{
    public class AuthService : IAuthService
    {
        
        readonly ITokenService tokenService;

        private readonly UserService _UserService;

        public AuthService(ITokenService tokenService,UserService userService)
        {
            this.tokenService = tokenService;
            this._UserService = userService;
        }


        public async Task<UserLoginResponse?> ?LoginUserAsync(GenerateTokenRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<UserEntity> list = _UserService.GetAllUsers();
            Console.WriteLine(list);
            for (int i = 0; i < list.Count; i++)
            {
                bool v = list[i].username == request.Username;
                bool v1 = list[i].Password == request.Password;
                Console.WriteLine(list[i].username == request.Username);
                Console.WriteLine(list[i].Password == request.Password);
                Console.WriteLine(list[i].username);
                Console.WriteLine( request.Username);
                if (v && v1)
                {
                    request.id = list[i].Id;
                    var generatedTokenInformation = await tokenService.GenerateToken(new GenerateTokenRequest{id=list[i].Id,Username=list[i].username,Password=list[i].Password});
                    response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
                    response.AuthenticateResult = true;
                    response.AuthToken = generatedTokenInformation.Token;
                    response.id = list[i].Id;
                    return response;
                }
            }
            Console.WriteLine("aaaaaaaaaaa\n");
            Console.WriteLine("aaaaaaaaaaa\n");
            Console.WriteLine("aaaaaaaaaaa\n");
            Console.WriteLine("aaaaaaaaaaa\n");
            Console.WriteLine("aaaaaaaaaaa\n");
            return null;
        }
    }
}
