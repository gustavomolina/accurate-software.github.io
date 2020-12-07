using System;
using System.Security.Claims;
using Core.AspNetIdentity;
using Newtonsoft.Json;

namespace ifound_api.Backoffice.Domain.Auth
{
    public static class MyUserHelperExtensions
    {
        public static ClaimsIdentity CreateIdentity(string user, string authenticationType)
        {
            if (user != null)
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(authenticationType, ClaimTypes.NameIdentifier, ClaimTypes.Role);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user));

                //serializa todo o objeto e adiciona a claim pra ele
                var userComplete = JsonConvert.SerializeObject(user);
                claimsIdentity.AddClaim(new Claim("CompleteUser", userComplete));

                ////adiciona as roles
                //foreach (var role in user.Roles)
                //    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));

                return claimsIdentity;
            }
            else
                throw new ArgumentNullException("user");
        }
    }
}
