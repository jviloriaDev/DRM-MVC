using Resources.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace Resources.Abstract
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public abstract class BaseResourceProvider : IResourceProvider
    {
        // Cache list of resources
        private static Dictionary<string, ResourceEntry> resources = null;

        private static object lockResources = new object();

        private static string CultureName;

        public BaseResourceProvider()
        {
            CultureName = string.Empty;
            Cache = Convert.ToBoolean(ConfigurationManager.AppSettings["CacheResources"]); // By default, enable caching for performance
            
        }

        protected bool Cache { get; set; } // Cache resources ?

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        public object GetResource(string name, string culture)
        {
            if (culture.ToLower() == "es")
                culture = "es-es";

            string result = "";
            try
            {

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Resource name cannot be null or empty.");

                if (string.IsNullOrWhiteSpace(culture))
                    throw new ArgumentException("Culture name cannot be null or empty.");

                // normalize
                culture = culture.ToLowerInvariant();

                if (Cache && resources == null)
                {
                    // Fetch all resources

                    lock (lockResources)
                    {
                        if (resources == null)
                        {
                            CultureName = culture;
                            resources = ReadResources().ToDictionary(r => string.Format("{0}.{1}", r.Culture.ToLowerInvariant(), r.Name));
                        }
                    }
                }
                else if (CultureName != culture)
                {
                    CultureName = culture;
                    resources = ReadResources().ToDictionary(r => string.Format("{0}.{1}", r.Culture.ToLowerInvariant(), r.Name));

                }
                if (Cache)
                {
                    result = resources[string.Format("{0}.{1}", culture, name)].Value;
                }
                else
                {
                    result= ReadResource(name, culture).Value;
                }
            }
            catch (Exception)
            {
                //string joined = string.Join(",", resources);
                //result = "Key:" + name + "-" + culture + " not found \n\n" + joined;
                //throw new Exception(result);
                result = "Key:" + name + "-" + culture;
            }
            return result;
        }

        /// <summary>
        /// Get all resources filter with selected culture
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public IList<ResourceEntry> GetResource(string culture)
        {
            if (culture == "es")
                culture = "es-es";
           return ReadResources(culture);
        }

        /// <summary>
        /// Set resources as null so once user changes any record than it will reload to make refresh
        /// </summary>
        public void SetUpdatedResources()
        {
            resources = null;
        }

        /// <summary>
        /// Returns all resources for all cultures. (Needed for caching)
        /// </summary>
        /// <returns>A list of resources</returns>
        protected abstract IList<ResourceEntry> ReadResources();

        protected abstract IList<ResourceEntry> ReadResources(string culture);

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        protected abstract ResourceEntry ReadResource(string name, string culture);

    }
}