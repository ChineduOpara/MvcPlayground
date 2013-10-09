using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class Application
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Domain { get; set; }
        public string Version { get; set; }
        public ICollection<Page> Pages { get; private set; }

        /// <summary>
        /// Indexer by page name.
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public Page this[string pageName]
        {
            get
            {
                return Pages.FirstOrDefault(p => string.Equals(p.Name, pageName, StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Application()
        {
            Pages = new List<Page>();
        }
    }
}