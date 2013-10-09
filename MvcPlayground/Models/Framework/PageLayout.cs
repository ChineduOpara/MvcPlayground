using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class PageLayout : NamedEntity
    {
        public int Id { get; set; }
        public string PartialViewUrl { get; set; }
        public ICollection<Zone> Zones { get; set; }

        public Zone this[string name]
        {
            get
            {
                return Zones.FirstOrDefault(z => string.Equals(z.Name, name, StringComparison.OrdinalIgnoreCase));
            }
        }

        public PageLayout()
        {
        }

        public PageLayout(string name)
        {
            this.Name = name;
            this.PartialViewUrl = string.Format("~/Views/Pages/{0}/Index.cshtml", name);
        }

        public void LoadZones(ICollection<ModuleInstance> moduleInstances)
        {
            var instancesByZone = moduleInstances.GroupBy(i => i.Zone).ToDictionary(g => g.Key, g => g.ToList());
            foreach (var zone in Zones)
            {
                List<ModuleInstance> instances;
                if (instancesByZone.TryGetValue(zone.Name, out instances))
                {
                    zone.ModuleContainers = instances.Select(i => new ModuleContainer() { ModuleInstance = i, ZoneName = zone.Name }).OrderBy(c => c.ModuleInstance.Index).ToList();
                }
            }
        }
    }
}