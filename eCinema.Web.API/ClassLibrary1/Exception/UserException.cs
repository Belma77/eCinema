using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Exceptions
{
    public class UserException:Exception
    {
        public UserException(string message) :  base(message){ }
    }

    public class UnauthorizedException : UserException
    {
        public UnauthorizedException(string message) : base(message) { }
    }

    public class NotFoundException : UserException
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class ForbbidenException : UserException
    {
        public ForbbidenException(string message) : base(message) { }
    }
   



}
