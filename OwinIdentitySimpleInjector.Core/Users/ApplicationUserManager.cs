using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OwinIdentitySimpleInjector.BO.Users;
using OwinIdentitySimpleInjector.Contracts;
using OwinIdentitySimpleInjector.Core.Users;
using OwinIdentitySimpleInjector.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinIdentitySimpleInjector.Core.Users
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        //{
        //    var manager = new ApplicationUserManager(new CustomUserStore(context.Get<IdentityDbContext>()));
        //    // Configure validation logic for usernames
        //    manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false,
        //        RequireUniqueEmail = true
        //    };

        //    // Configure validation logic for passwords
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6,
        //        RequireNonLetterOrDigit = true,
        //        RequireDigit = true,
        //        RequireLowercase = true,
        //        RequireUppercase = true,
        //    };

        //    // Configure user lockout defaults
        //    manager.UserLockoutEnabledByDefault = true;
        //    manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //    manager.MaxFailedAccessAttemptsBeforeLockout = 5;

        //    // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
        //    // You can write your own provider and plug it in here.
        //    manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
        //    {
        //        MessageFormat = "Your security code is {0}"
        //    });
        //    manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
        //    {
        //        Subject = "Security Code",
        //        BodyFormat = "Your security code is {0}"
        //    });
        //    // manager.EmailService = new EmailService();
        //    // manager.SmsService = new SmsService();
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //    {
        //        manager.UserTokenProvider =
        //            new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    }
        //    return manager;
        //}

        public override Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            return base.CreateAsync(user);
        }

        public override Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            return base.ConfirmEmailAsync(userId, token);
        }

        public override Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return base.FindByEmailAsync(email);
        }

        public override Task<bool> IsEmailConfirmedAsync(string userId)
        {
            return base.IsEmailConfirmedAsync(userId);
        }

        public override Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return base.FindByNameAsync(userName);
        }

        public override Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            return base.ResetPasswordAsync(userId, token, newPassword);
        }

        public override Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId)
        {
            return base.GetValidTwoFactorProvidersAsync(userId);
        }

        public override Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            return base.AddLoginAsync(userId, login);
        }

        public override Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return base.CreateAsync(user, password);
        }

        public override Task<string> GetPhoneNumberAsync(string userId)
        {
            return base.GetPhoneNumberAsync(userId);
        }

        public override Task<bool> GetTwoFactorEnabledAsync(string userId)
        {
            return base.GetTwoFactorEnabledAsync(userId);
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(string userId)
        {
            return base.GetLoginsAsync(userId);
        }

        public override Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login)
        {
            return base.RemoveLoginAsync(userId, login);
        }

        public override Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return base.FindByIdAsync(userId);
        }

        public override Task<string> GenerateChangePhoneNumberTokenAsync(string userId, string phoneNumber)
        {
            return base.GenerateChangePhoneNumberTokenAsync(userId, phoneNumber);
        }

        public override Task<IdentityResult> SetTwoFactorEnabledAsync(string userId, bool enabled)
        {
            return base.SetTwoFactorEnabledAsync(userId, enabled);
        }

        public override Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            return base.ChangePasswordAsync(userId, currentPassword, newPassword);
        }

        public override Task<IdentityResult> SetPhoneNumberAsync(string userId, string phoneNumber)
        {
            return base.SetPhoneNumberAsync(userId, phoneNumber);
        }

        public override Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return base.CheckPasswordAsync(user, password);
        }

        public override Task<IdentityResult> AddPasswordAsync(string userId, string password)
        {
            return base.AddPasswordAsync(userId, password);
        }

        public Task<IList<UserLoginInfo>> GetLoginsA(string userId)
        {
            return base.GetLoginsAsync(userId);
        }

        public override Task<IdentityResult> ChangePhoneNumberAsync(string userId, string phoneNumber, string token)
        {
            return base.ChangePhoneNumberAsync(userId, phoneNumber, token);
        }

        public IIdentityMessageService SmsServiceExtend()
        {
            return base.SmsService;
        }
    }
}
