using Resources.Abstract;
using Resources.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Configuration;

namespace Resources.Concrete
{
    public class XmlResourceProvider : BaseResourceProvider
    {
        // File path
        private string filePath = null;

        public XmlResourceProvider(string filePath)
        {
            this.filePath = filePath;
            if (!File.Exists(filePath)) throw new FileNotFoundException(string.Format("XML Resource file {0} was not found", filePath));
        }

        /// <summary>
        /// Read all resources from XML file
        /// </summary>
        /// <returns></returns>
        protected override IList<ResourceEntry> ReadResources()
        {
            //SetFilePath();
            // Parse the XML file
            if (!File.Exists(filePath))
                throw new Exception("ReadResources() " + filePath);

            try
            {
         
                return XDocument.Parse(File.ReadAllText(filePath))
                    .Element("resources")
                    .Elements("resource")
                    .Select(e => new ResourceEntry
                    {
                        Name = e.Attribute("name").Value,
                        Value = e.Attribute("value").Value,
                        Culture = e.Attribute("culture").Value
                    }).ToList();
            }
            catch (Exception)
            {

                throw new Exception("ReadResources() " + filePath);
            }
        }

        /// <summary>
        /// Read resources as per selected culture
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected override IList<ResourceEntry> ReadResources(string culture)
        {
            //SetFilePath();
            // Parse the XML file
            if (!File.Exists(filePath))
                throw new Exception("ReadResources(string culture) " + filePath);

            try
            {
                return XDocument.Parse(File.ReadAllText(filePath))
                    .Element("resources")
                    .Elements("resource")
                    .Where(e => e.Attribute("culture").Value == culture.ToLowerInvariant())
                    .Select(e => new ResourceEntry
                    {
                        Name = e.Attribute("name").Value,
                        Value = e.Attribute("value").Value,
                        Culture = e.Attribute("culture").Value
                    }).ToList();
            }
            catch (Exception)
            {

                throw new Exception("ReadResources(string culture) " + filePath + "    " + culture);
            }

        }

        /// <summary>
        /// read single entity from xml file with name and culture
        /// </summary>
        /// <param name="name"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected override ResourceEntry ReadResource(string name, string culture)
        {
            //SetFilePath();
            // Parse the XML file
            if (!File.Exists(filePath))
                throw new Exception("ReadResource(string name, string culture) " + filePath);

            try
            {
                return XDocument.Parse(File.ReadAllText(filePath))
                    .Element("resources")
                    .Elements("resource")
                    .Where(e => e.Attribute("name").Value == name && ((culture == "en-us" && (e.Attribute("culture").Value == culture || e.Attribute("culture").Value == "en-US")) || e.Attribute("culture").Value == culture))
                    .Select(e => new ResourceEntry
                    {
                        Name = e.Attribute("name").Value,
                        Value = e.Attribute("value").Value,
                        Culture = e.Attribute("culture").Value
                    }).FirstOrDefault();
            }
            catch (Exception)
            {

                throw new Exception("ReadResource(string name, string culture) " + filePath + "    " + name + "/" + culture);
            }
        }

        /// <summary>
        /// Set File path as per selected culture
        /// </summary>
        private void SetFilePath()
        {
            filePath = Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Resources" + (Thread.CurrentThread.CurrentUICulture.ToString() == "en-US" ? "" : "." + Thread.CurrentThread.CurrentUICulture.ToString()) + ".xml");
        }

    }
}