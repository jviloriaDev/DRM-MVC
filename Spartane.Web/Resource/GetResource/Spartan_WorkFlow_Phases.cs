using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_PhasesResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Phases = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_PhasesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Phases = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_PhasesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_WorkFlow_Phases = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_PhasesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_WorkFlow_Phases</summary>
        public static string Spartan_WorkFlow_Phases
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("Spartan_WorkFlow_Phases", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PhasesId</summary>
        public static string PhasesId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("PhasesId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase_Number</summary>
        public static string Phase_Number
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("Phase_Number", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Name</summary>
        public static string Name
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase_Type</summary>
        public static string Phase_Type
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("Phase_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Type_of_Work_Distribution</summary>
        public static string Type_of_Work_Distribution
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("Type_of_Work_Distribution", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Type_Flow_Control</summary>
        public static string Type_Flow_Control
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("Type_Flow_Control", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase_Status</summary>
        public static string Phase_Status
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("Phase_Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Phases.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
