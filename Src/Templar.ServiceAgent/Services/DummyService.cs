using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templar.ServiceAgent.Services
{
    public class DummyService  : IDummyService 
    {
        public DateTime GetDate()
        {
            throw new ApplicationException(); 
            return DateTime.Now; 
        }
    }
}
