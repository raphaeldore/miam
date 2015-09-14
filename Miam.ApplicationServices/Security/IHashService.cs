using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miam.ApplicationServices.Security
{
    public interface IHashService
    {
        String Hash(String value);
        String HashPassword(String value);
        Boolean Verify(String value, String hash);
        Boolean VerifyPassword(String value, String passhash);
    }
}
