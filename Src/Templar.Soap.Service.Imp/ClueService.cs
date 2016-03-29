using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Soap.Service
{
    [ServiceBehavior( 
        ConcurrencyMode = ConcurrencyMode.Multiple,
         InstanceContextMode = InstanceContextMode.Single)]
    public class ClueService : IClueService
    {

    }
}
