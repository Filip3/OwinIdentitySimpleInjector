using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OwinIdentitySimpleInjector.BO.Users;
using OwinIdentitySimpleInjector.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinIdentitySimpleInjector.Core
{
    public interface IApplicationUserManager
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> IsEmailConfirmedAsync(string userId);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> AddPasswordAsync(string userId, string password);
        Task<IdentityResult> SetPhoneNumberAsync(string userId, string phoneNumber);
        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<IdentityResult> SetTwoFactorEnabledAsync(string userId, bool enabled);
        Task<string> GenerateChangePhoneNumberTokenAsync(string userId, string phoneNumber);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login);
        Task<IList<UserLoginInfo>> GetLoginsAsync(string userId);
        Task<bool> GetTwoFactorEnabledAsync(string userId);
        Task<string> GetPhoneNumberAsync(string userId);
        Task<IdentityResult> ChangePhoneNumberAsync(string userId, string phoneNumber, string token);
        IIdentityMessageService SmsServiceExtend();
    }
}
