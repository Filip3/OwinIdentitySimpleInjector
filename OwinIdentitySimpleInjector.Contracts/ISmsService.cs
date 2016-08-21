using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinIdentitySimpleInjector.Contracts
{
    public interface ISmsService
    {
        Task SendAsync(IdentityMessage message);
    }
}
