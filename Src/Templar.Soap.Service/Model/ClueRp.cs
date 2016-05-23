using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Soap.Service.Model
{
    [DataContract]
    public class ClueRp
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Log { get; set; }
    }
}
