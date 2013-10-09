using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class Page : NamedEntity
    {
        private PageLayout _pageLayout = null;

        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int LayoutId { get; set; }
        public ICollection<ModuleInstance> ModuleInstances { get; set; }        

        public ModuleContainer this[string moduleName]
        {
            get
            {
                return Layout.Zones.SelectMany(z => z.ModuleContainers).FirstOrDefault(c => string.Equals(c.ModuleInstance.Module.Name, moduleName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public PageLayout Layout
        {
            get
            {
                if (_pageLayout == null)
                {
                    DataManager data = new DataManager();
                    _pageLayout = data.PageLayouts[Name];
                    _pageLayout.LoadZones(ModuleInstances);
                }
                return _pageLayout;
            }
        }

        public Page()
        {
        }

        public Page(string name)
        {
            this.ApplicationId = 1;
            this.Name = name;
        }

        public void ReplaceContainer(ModuleContainer container)
        {
            var zone = Layout[container.ZoneName];
            if (zone != null)
            {
                var containers = (List<ModuleContainer>)zone.ModuleContainers;
                var index = containers.FindIndex(c => c.ModuleInstance.Index == container.ModuleInstance.Index);
                if (index > -1)
                {
                    containers[index] = container;
                }
            }
        }
    }
}