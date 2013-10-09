using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class Module : NamedEntity
    {
        private string _partialViewFilename;
        public string ViewFilename
        {
            get { return _partialViewFilename; }
            set
            {
                _partialViewFilename = Path.ChangeExtension(value, ".cshtml");
            }
        }
        public int Id { get; set; }
        public string ErrorFilename { get; set; }        

        public string PartialViewUrl
        {
            get
            {
                return string.Format("~/Views/Modules/{0}/{1}", Name, ViewFilename ?? "Index.cshtml");
            }
        }

        public string ErrorViewUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(ErrorFilename))
                {
                    return string.Format("~/Views/Modules/{0}/{1}", Name, ErrorFilename);
                }
                else
                {
                    return string.Format("~/Views/Shared/{0}", "Error.cshtml");
                }                
            }
        }

        public Module()
        {
            ViewFilename = "Index.cshtml";
        }
    }
}