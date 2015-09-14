using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miam.ApplicationServices.Security
{
    public class BCryptService : IHashService
    {
        private const int BCRYPT_WORK_FACTOR = 12;

        public string Hash(string value)
        {
            return BCrypt.Net.BCrypt.HashString(value, BCRYPT_WORK_FACTOR);
        }

        public string HashPassword(string value)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(BCRYPT_WORK_FACTOR);

            return BCrypt.Net.BCrypt.HashPassword(value, salt);
        }

        public bool Verify(string value, string hash)
        {
            if (value == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(value, hash);
        }

        public bool VerifyPassword(string value, string passhash)
        {
            if (value == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(value, passhash);
        }
    }
}
