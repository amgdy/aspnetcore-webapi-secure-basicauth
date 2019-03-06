using Microsoft.AspNetCore.Authentication;
using System;

namespace AspNetCoreApiBasicAuth.Web.Handlers
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        private string _realm;

        public string Realm
        {
            get
            {
                return _realm;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && !IsAscii(value))
                {
                    throw new ArgumentException("Realm must be US ASCII");
                }

                _realm = value;
            }
        }

        public bool AllowInsecureProtocol { get; set; }

        private static bool IsAscii(string input)
        {
            foreach (char c in input)
            {
                if (c < 32 || c >= 127)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
