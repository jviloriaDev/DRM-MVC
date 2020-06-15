using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_ReportResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_ReportResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_ReportResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_Report = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_ReportResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_Report</summary>
        public static string Spartan_Report
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Spartan_Report", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ReportId</summary>
        public static string ReportId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("ReportId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Report_Name</summary>
        public static string Report_Name
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Report_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Date</summary>
        public static string Registration_Date
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Registration_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Hour</summary>
        public static string Registration_Hour
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Registration_Hour", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_User</summary>
        public static string Registration_User
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Registration_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object</summary>
        public static string Object
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Object", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presentation_Type</summary>
        public static string Presentation_Type
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Presentation_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presentation_View</summary>
        public static string Presentation_View
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Presentation_View", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Query</summary>
        public static string Query
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Query", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Report_Fields_Detail</summary>
        public static string Report_Fields_Detail
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Report_Fields_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Filters</summary>
        public static string Filters
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Filters", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Header</summary>
        public static string Header
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Header", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Footer</summary>
        public static string Footer
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report.GetResource("Footer", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_Report.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Data</summary>	public static string TabData 	{		get		{			SetPath();  			return resourceProviderSpartan_Report.GetResource("TabData", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Filters</summary>	public static string TabFilters 	{		get		{			SetPath();  			return resourceProviderSpartan_Report.GetResource("TabFilters", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    /// <summary>Filters</summary>
    public static string TabDesign
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("TabDesign", CultureInfo.CurrentUICulture.Name) as String;
        }
    }

    public static string DetailedReport
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("DetailedReport", CultureInfo.CurrentUICulture.Name) as String;
        }
    }


    public static string dragFiledsToHere
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("dragFiledsToHere", CultureInfo.CurrentUICulture.Name) as String;
        }
    }
    public static string Columns
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("Columns", CultureInfo.CurrentUICulture.Name) as String;
        }
    }
    public static string Records
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("Records", CultureInfo.CurrentUICulture.Name) as String;
        }
    }
    public static string Functions
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("Functions", CultureInfo.CurrentUICulture.Name) as String;
        }
    }
    public static string TotalByColumns
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("TotalByColumns", CultureInfo.CurrentUICulture.Name) as String;
        }
    }

    public static string TotalByRecords
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("TotalByRecords", CultureInfo.CurrentUICulture.Name) as String;
        }
    }
    public static string Result
    {
        get
        {
            SetPath();
            return resourceProviderSpartan_Report.GetResource("Result", CultureInfo.CurrentUICulture.Name) as String;
        }
    }
  

    }
}
