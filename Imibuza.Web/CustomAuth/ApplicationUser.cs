using System;
using Microsoft.AspNet.Identity;

namespace Imibuza.Web.CustomAuth
{
    public class ApplicationUser : IUser
    {
        public DateTime CreateDate { get; set; }
        public DateTime BirthDate { get; set; }

        public ApplicationUser()
        {
            CreateDate = DateTime.Now;
        }
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}