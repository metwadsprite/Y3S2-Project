using Microsoft.AspNetCore.Authorization;

namespace GASF.Areas.Identity.Auth
{
    public class UserRequirement: IAuthorizationRequirement
    {
        public string userType;

        public UserRequirement(string userType)
        {
            this.userType = userType;
        }
    }
}