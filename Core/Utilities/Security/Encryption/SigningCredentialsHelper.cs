using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //Jwt ye secretkey ve imzalama algorithmasını bildirir
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigninCredentials(SecurityKey security){
            return new SigningCredentials(security,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}