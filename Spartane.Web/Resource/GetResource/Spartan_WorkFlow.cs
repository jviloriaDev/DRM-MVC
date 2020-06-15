using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlowResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlowResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlowResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_WorkFlow = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlowResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_WorkFlow</summary>
        public static string Spartan_WorkFlow
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Spartan_WorkFlow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>WorkFlowId</summary>
        public static string WorkFlowId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("WorkFlowId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Name</summary>
        public static string Name
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Objective</summary>
        public static string Objective
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Objective", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object</summary>
        public static string Object
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Object", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phases</summary>
        public static string Phases
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Phases", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>State</summary>
        public static string State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Conditions_by_State</summary>
        public static string Conditions_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Conditions_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Information_by_State</summary>
        public static string Information_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Information_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Roles_by_State</summary>
        public static string Roles_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Roles_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Matrix_of_States</summary>
        public static string Matrix_of_States
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("Matrix_of_States", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /// <summary>Phases</summary>
        public static string TabPhases
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("TabPhases", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /// <summary>State</summary>
        public static string TabState
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("TabState", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /// <summary>Conditions by State</summary>
        public static string TabConditions_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("TabConditions_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /// <summary>Information by State</summary>
        public static string TabInformation_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("TabInformation_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /// <summary>Roles by State</summary>
        public static string TabRoles_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("TabRoles_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /// <summary>Matrix of States</summary>
        public static string TabMatrix_of_States
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow.GetResource("TabMatrix_of_States", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
