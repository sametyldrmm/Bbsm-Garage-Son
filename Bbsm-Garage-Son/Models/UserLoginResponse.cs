namespace Bbsm_Garage_Son.Models
{
    public class UserLoginResponse
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }

        public int? id {get; set;} 
    }
}
