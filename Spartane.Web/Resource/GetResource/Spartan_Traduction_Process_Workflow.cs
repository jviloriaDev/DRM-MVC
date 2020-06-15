using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Traduction_Process_WorkflowResources
    {
        //private static IResourceProvider resourceProviderSpartan_Traduction_Process_Workflow = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Traduction_Process_WorkflowResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Traduction_Process_Workflow = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_Process_WorkflowResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_Traduction_Process_Workflow = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_Process_WorkflowResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_Traduction_Process_Workflow</summary>
        public static string Spartan_Traduction_Process_Workflow
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Workflow.GetResource("Spartan_Traduction_Process_Workflow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Workflow.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Concept</summary>
        public static string Concept
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Workflow.GetResource("Concept", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ID_of_Step</summary>
        public static string ID_of_Step
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Workflow.GetResource("ID_of_Step", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Original_Text</summary>
        public static string Original_Text
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Workflow.GetResource("Original_Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Translated_Text</summary>
        public static string Translated_Text
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Workflow.GetResource("Translated_Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_Traduction_Process_Workflow.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
