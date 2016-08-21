using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OwinIdentitySimpleInjector.BO.Users;
using OwinIdentitySimpleInjector.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinIdentitySimpleInjector.Core.Users
{
    /// <summary>
    /// Implements 'User Store' of ASP.NET Identity Framework.
    /// </summary>
    public class CustomUserStore : UserStore<ApplicationUser>, ICustomUserStore<ApplicationUser>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
