using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_MetadataGridModel
    {
        public int? AttributeId { get; set; }
        public int? Class_Id { get; set; }
        public string Class_Name { get; set; }
        public int? Object_Id { get; set; }
        public string Physical_Name { get; set; }
        public string Logical_Name { get; set; }
        public short? Identifier_Type { get; set; }
        public short? Attribute_Type { get; set; }
        public int? Length { get; set; }
        public short? Decimals_Length { get; set; }
        public short? Relation_Type { get; set; }
        public int? Related_Object_Id { get; set; }
        public int? Related_Class_Id { get; set; }
        public string Related_Class_Name { get; set; }
        public int? Related_Class_Identifier { get; set; }
        public string Related_Class_Description { get; set; }
        public bool? Required { get; set; }
        public string DefaultValue { get; set; }
        public bool? Visible { get; set; }
        public string Help_Text { get; set; }
        public bool? Read_Only { get; set; }
        public int? ScreenOrder { get; set; }
        public int? Control_Type { get; set; }
        public string Group_Name { get; set; }
        
    }
}

