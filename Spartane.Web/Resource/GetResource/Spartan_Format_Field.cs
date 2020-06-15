using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Format_FieldResources
    {
        //private static IResourceProvider resourceProviderSpartan_Format_Field = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Format_FieldResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Format_Field = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Format_FieldResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Format_Field</summary>
        public static string Spartan_Format_Field
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Spartan_Format_Field", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>FormatFieldId</summary>
        public static string FormatFieldId
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("FormatFieldId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Format</summary>
        public static string Format
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Format", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Field_Path</summary>
        public static string Field_Path
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Field_Path", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Physical_Field_Name</summary>
        public static string Physical_Field_Name
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Physical_Field_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Logical_Field_Name</summary>
        public static string Logical_Field_Name
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Logical_Field_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Creation_Date</summary>
        public static string Creation_Date
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Creation_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Creation_Hour</summary>
        public static string Creation_Hour
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Creation_Hour", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Creation_User</summary>
        public static string Creation_User
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Creation_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Properties</summary>
        public static string Properties
        {
            get
            {
                return resourceProviderSpartan_Format_Field.GetResource("Properties", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
