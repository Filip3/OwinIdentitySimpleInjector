//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OwinIdentitySimpleInjector.BO
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserClaim
    {
        public int UserClaimId { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    
        public virtual User User { get; set; }
    }
}
