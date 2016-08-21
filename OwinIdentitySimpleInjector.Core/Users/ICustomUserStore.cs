using OwinIdentitySimpleInjector.BO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinIdentitySimpleInjector.Core.Users
{
    public interface ICustomUserStore<TUser>
        where TUser : ApplicationUser
    {
    }
}
