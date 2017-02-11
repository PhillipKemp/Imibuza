using System.Threading.Tasks;
using Imibuza.Web.Controllers;
using Imibuza.Web.Models;
using Microsoft.AspNet.Identity;

namespace Imibuza.Web.CustomAuth
{
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        public CustomUserManager() : base(new CustomUserSore<ApplicationUser>())
        {
            //We can retrieve Old System Hash Password and can encypt or decrypt old password using custom approach. 
            //When we want to reuse old system password as it would be difficult for all users to initiate pwd change as per Idnetity Core hashing. 
            this.PasswordHasher = new OldSystemPasswordHasher();
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            Task<ApplicationUser> taskInvoke = Task<ApplicationUser>.Factory.StartNew(() =>
            {
                //First Verify Password... 
                PasswordVerificationResult result = this.PasswordHasher.VerifyHashedPassword(userName, password);
                if (result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    ApplicationUser applicationUser = new ApplicationUser();
                    //applicationUser.UserName = "san";
                    return applicationUser;
                }
                return null;
            });
            return taskInvoke;
        }
    }
}