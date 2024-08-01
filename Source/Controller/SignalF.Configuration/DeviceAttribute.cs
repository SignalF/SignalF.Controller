using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalF.Configuration
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DeviceAttribute : Attribute
    {
        public Type OptionsType { get; set; }
    }
}
