using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class ModuleInstance
    {
        public int Id { get; set; }
        public Module Module { get; set; }
        public string Zone { get; set; }
        public int Index { get; set; }
    }
}