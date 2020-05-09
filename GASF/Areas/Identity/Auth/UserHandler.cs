using System;
using System.Threading.Tasks;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GASF.Areas.Identity.Auth
{
    public class UserHandler: AuthorizationHandler<UserRequirement>
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly UserService userService;

        public UserHandler(UserManager<IdentityUser> userManager, UserService userService)
        {   
            this.userManager = userManager;
            this.userService = userService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            var userId = Guid.Parse(userManager.GetUserId(context.User));

            if (requirement.userType == "Secretary" && userService.IsUserSecretary(userId)) {
                context.Succeed(requirement);
            }
            if (requirement.userType == "Student" && userService.IsUserStudent(userId)) {
                context.Succeed(requirement);
            }
            if (requirement.userType == "Teacher" && userService.IsUserTeacher(userId)) {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}