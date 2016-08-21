# OwinIdentitySimpleInjector

###### OWIN-Identity-SimpleInjector-Middleware

This sample app shows how to add SimpleInjector to Owin and Identity. Also it shows how to implement some example middleware in to the mix.

###### Description of the sample

The app uses SimpleInjector as a dependency library, 
[SimpleInjector](https://github.com/simpleinjector/SimpleInjector)

You can find the implementation on the highest level of the sample in the App_Start\IdentityConfig , under the RegisterInjections method.

In there you can find the registration of the OwinContext, also there are the registrations for the related implementations of Identity, which are ApplicationUserManager, ApplicationUser, IdentityDbContext and ApplicationDbContext.

The app uses the NLog logging platform for logging, 
[NLog](https://github.com/NLog/NLog)

You can find the configuration of the NLog in the Nlog.config, where you can see a simple configuration for NLog, just for demonstration purposes in the middleware.

The implementation of the logging examples are implemented in the \Middlware\ folder. 

The sample also contains a test project, where you can see we have added NSubstitute,
[NSubstitute](http://nsubstitute.github.io/)

In that project you can also find how to mock the Owin context, and an implementation of a couple of example tests.

###### Prerequisites

This sample requires:
 
- Visual Studio
- MS SQL


###### To start the sample

- Clone the project
- Restore nuget packages 
- Build the sample
- Run and test the sample

###### Change log

- August 2016

###### Related content
[OWIN](http://owin.org/) 

[ASP.NET Identity](http://www.asp.net/identity)
