using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using OwinIdentitySimpleInjector.BO.Users;
using OwinIdentitySimpleInjector.Contracts;
using OwinIdentitySimpleInjector.DAL.Contracts;
using OwinIdentitySimpleInjector.Core;
using OwinIdentitySimpleInjector.Core.Users;
using OwinIdentitySimpleInjector.DAL;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace OwinIdentitySimpleInjector
{
    public static class IdentityConfig
    {
        public static void UseOwinContextInjector(this IAppBuilder app, Container container)
        {
            // Create an OWIN middleware to create an execution context scope
            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next.Invoke();
                }
            });
        }

        private static void InitializeUserManager(ApplicationUserManager manager, IAppBuilder app)
        {
            manager.UserValidator =
             new UserValidator<ApplicationUser>(manager)
             {
                 AllowOnlyAlphanumericUserNames = false,
                 RequireUniqueEmail = false
             };

            //Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            // manager.EmailService = new EmailService();
            // manager.SmsService = new SmsService();

            var dataProtectionProvider =
                 app.GetDataProtectionProvider();

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                 new DataProtectorTokenProvider<ApplicationUser>(
                  dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }

        public static Container RegisterInjections(IAppBuilder app)
        {
            ILogger _logger = LogManager.GetLogger("OwinIdentitySimpleInjector");
            // Create container
            var container = new Container();

            app.UseOwinContextInjector(container);

            // http://simpleinjector.codeplex.com/wikipage?title=ObjectLifestyleManagement#PerThread
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<IAppBuilder>(() => app, Lifestyle.Singleton);

            container.RegisterSingleton<ILogger>(_logger);
            container.RegisterPerWebRequest(() => AdvancedExtensions.IsVerifying(container) ? new OwinContext(new Dictionary<string, object>()).Authentication : HttpContext.Current.GetOwinContext().Authentication);

            container.Register(typeof(IApplicationUserManager), typeof(ApplicationUserManager), Lifestyle.Scoped);
            container.RegisterInitializer<ApplicationUserManager>(manager => InitializeUserManager(manager, app));
            container.RegisterSingleton(new ApplicationDbContext());
            container.Register<IUserStore<ApplicationUser>>(() => new CustomUserStore(
                container.GetInstance<ApplicationDbContext>()),
                Lifestyle.Scoped);
            container.Register<IdentityDbContext>(() => new IdentityDbContext("DefaultConnection"), Lifestyle.Scoped);


            container.Register<ISmsService, SmsService>();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }
    }
}
