using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Infrastructure.Identity
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string userName) : base($"No user found with username: {userName}")
        {
        }
    }
}
