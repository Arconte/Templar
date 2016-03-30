using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Templar.Soap.Service.Model;

namespace Templar.Soap.Service
{
    [ServiceContract(  SessionMode= SessionMode.NotAllowed, Namespace = Constants.Namespace )]    
    public interface IClueService
    {
        [OperationContract]
        void Add(Guid Id, string Source, string Content, DateTime DueDate);

        [OperationContract]
        IEnumerable<ClueRp> Get(); 

    }
}
