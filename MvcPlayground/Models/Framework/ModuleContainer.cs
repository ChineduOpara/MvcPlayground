using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class ModuleContainer
    {
        public string ZoneName { get; set; }
        public ModuleInstance ModuleInstance { get; set; }

        public virtual object GetModel()
        {
            return ModuleInstance;
        }
    }

    public class ModuleContainer<T> : ModuleContainer
    {
        public T Entity { get; set; }

        public ModuleContainer(ModuleContainer container)
        {
            ModuleInstance = container.ModuleInstance;
            ZoneName = container.ZoneName;
        }        

        public override object GetModel()
        {
            return Entity;
        }
    }
}