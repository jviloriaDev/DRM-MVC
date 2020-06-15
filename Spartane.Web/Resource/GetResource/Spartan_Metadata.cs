using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_MetadataResources
    {
        //private static IResourceProvider resourceProviderSpartan_Metadata = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_MetadataResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Metadata = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_MetadataResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Metadata</summary>
        public static string Spartan_Metadata
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Spartan_Metadata", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>AttributeId</summary>
        public static string AttributeId
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("AttributeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Class_Id</summary>
        public static string Class_Id
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Class_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Class_Name</summary>
        public static string Class_Name
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Class_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object_Id</summary>
        public static string Object_Id
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Object_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Physical_Name</summary>
        public static string Physical_Name
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Physical_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Logical_Name</summary>
        public static string Logical_Name
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Logical_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Identifier_Type</summary>
        public static string Identifier_Type
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Identifier_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Attribute_Type</summary>
        public static string Attribute_Type
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Attribute_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Length</summary>
        public static string Length
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Length", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Decimals_Length</summary>
        public static string Decimals_Length
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Decimals_Length", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Relation_Type</summary>
        public static string Relation_Type
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Relation_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Related_Object_Id</summary>
        public static string Related_Object_Id
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Related_Object_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Related_Class_Id</summary>
        public static string Related_Class_Id
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Related_Class_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Related_Class_Name</summary>
        public static string Related_Class_Name
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Related_Class_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Related_Class_Identifier</summary>
        public static string Related_Class_Identifier
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Related_Class_Identifier", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Related_Class_Description</summary>
        public static string Related_Class_Description
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Related_Class_Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Required</summary>
        public static string Required
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Required", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>DefaultValue</summary>
        public static string DefaultValue
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("DefaultValue", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Visible</summary>
        public static string Visible
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Visible", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Help_Text</summary>
        public static string Help_Text
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Help_Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Read_Only</summary>
        public static string Read_Only
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Read_Only", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ScreenOrder</summary>
        public static string ScreenOrder
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("ScreenOrder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Control_Type</summary>
        public static string Control_Type
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Control_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Group_Name</summary>
        public static string Group_Name
        {
            get
            {
                return resourceProviderSpartan_Metadata.GetResource("Group_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
