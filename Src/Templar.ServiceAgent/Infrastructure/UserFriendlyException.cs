using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templar.ServiceAgent.Infrastructure
{
    public class UserFriendlyException : ApplicationException
    {
        public UserFriendlyException() { }
        public UserFriendlyException(Guid ErrorId, string Message = "We found an error in the application, please record this id: {0} to track it." )
            :base( string.Format(Message,ErrorId))
        { 

        }
    }
}
