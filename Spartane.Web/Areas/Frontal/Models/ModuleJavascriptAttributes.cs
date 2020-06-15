using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class ModuleJavascriptAttributesMR
    {
        public string table { get; set; }

        public List<ModuleJavascriptAttributes> elements { get; set; }
    }
    public class ModuleJavascriptAttributes
    {
        public string inputId { get; set; }

        public string inputType { get; set; }

        public bool IsRequired { get; set; }

        public bool IsVisible { get; set; }

        public bool IsReadOnly { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Required(AllowEmptyStrings=true)]
        public string DefaultValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Required(AllowEmptyStrings = true)]
        public string HelpText { get; set; }

        //public string PlaceHolder { get; set; }

        //public string selectDefaultValidationValue { get; set; }

    }

    public class EmpleadoElementAttribute
    {
        public string MainElement { get; set; }

        public string ChildElement { get; set; }
    }

    public class EmpleadoElements
    {
        public List<ModuleJavascriptAttributes> EmployeeModuleAttributeList { get; set; }

        public List<ModuleJavascriptAttributes> HistoryModuleAttributeList { get; set; }
    }


    public class CustomElementAttribute
    {
        public string MainElement { get; set; }

        public string ChildElement { get; set; }
    }

    public class CustomElements
    {
        public List<ModuleJavascriptAttributes> CustomModuleAttributeList { get; set; }
        public List<ModuleJavascriptAttributes> ChildModuleAttributeList { get; set; }
    }

    public class CustomElementsNew
    {
        public List<ModuleJavascriptAttributes> CustomModuleAttributeList { get; set; }
        public List<ModuleJavascriptAttributesMR> ChildModuleAttributeList { get; set; }
    }


}