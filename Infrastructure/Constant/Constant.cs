using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Constant
{
    public class DBStatus
    {
        public const int NOT_FOUND = 0;
        public const int SUCCESS = 1;
        public const int FAIL = 2;
        public const int SYSTEM_FAIL = 3;
    }

    public class UserIdentityConstant
    {
        public const string TOKEN_HEADER = "TokenHeader";
        public const string USERNAME = "Username";
        public const string FULL_NAME = "FullName";
        public const string EMAIL = "Email";
        public const string UNIQUE_NAME = "unique_name";
        public const string ROLE = "role";
    }
}
