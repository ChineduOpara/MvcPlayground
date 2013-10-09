using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class Zone : NamedEntity
    {
        public int LayoutId { get; set; }
        public ICollection<ModuleContainer> ModuleContainers { get; set; }
    }
}