using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Service.FunctionalTest
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OwnerAttribute : CategoryAttribute
    {
        public OwnerAttribute(string Owner) : base(Owner)
        {


        }
    }
}
