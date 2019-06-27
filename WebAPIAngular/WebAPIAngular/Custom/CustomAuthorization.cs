using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPIAngular.Custom
{
    public class CustomAuthorization
    {
        public static bool ValidarClaimUsuario (HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Split(",").Contains(claimValue));
        }
    }
}
