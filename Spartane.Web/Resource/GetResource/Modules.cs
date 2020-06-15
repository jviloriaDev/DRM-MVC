using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Entities;
using System.Xml.Linq;
using System.Configuration;

namespace Resources
{
    public static class Modules
    {
        private static List<ResourceEntry> _moduleList;
        private static object _moduleMainLock = new object();
        private static object _moduleUpdateLock = new object();
        private static string filePath;
        private static bool loadingModules;

        static Modules()
        {
            loadingModules = false;
            filePath = Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\ModuleResources.xml");
            LoadAllModules();
        }

        /// <summary>
        /// Used to load all modules from the xml
        /// </summary>
        private static void LoadAllModules()
        {
            loadingModules = true;
            lock (_moduleMainLock)
            {
                _moduleList = XDocument.Parse(File.ReadAllText(filePath))
                .Element("Modules")
                .Elements("Module")
                .Select(e => new ResourceEntry
                {
                    Id = Convert.ToInt32(e.Attribute("Id").Value),
                    Value = e.Attribute("value").Value,
                    Culture = e.Attribute("culture").Value
                }).ToList();
            }
            loadingModules = false;
        }

        /// <summary>
        /// Used to get the get Module Value(Using current culture)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetModuleValueById(long id)
        {
            return GetModuleValueById(id, CultureInfo.CurrentUICulture.Name);
        }

        /// <summary>
        /// Used to get the get Module Value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string GetModuleValueById(long id, string culture)
        {
            string result = "";
            try
            {
                if (loadingModules)
                    lock (_moduleUpdateLock)
                        lock (_moduleMainLock)
                        { }

                culture = culture.ToLower();
                result = _moduleList.FirstOrDefault(m => m.Id == id && m.Culture == culture).Value;
            }
            catch (Exception)
            {
                //throw new Exception("Id=" + id + " and Culture=" + culture + " not found.", ex);
                result = "Id=" + id + " and Culture=" + culture + " not found. \n\n FilePath:" + filePath;
            }
            return result;
        }

        /// <summary>
        /// Used to insert new module
        /// </summary>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool InsertUpdateModule(int id, string value, string culture)
        {
            try
            {
                lock (_moduleUpdateLock)
                {
                    var xmlDocument = XDocument.Parse(File.ReadAllText(filePath));
                    if (_moduleList.Any(m => m.Id == id && m.Culture == culture))
                    {
                        var target = (from el in xmlDocument.Element("Modules").Elements("Module")
                                      where
                                          (string)el.Attribute("culture") == culture &&
                                          (string)el.Attribute("Id") == id.ToString()
                                      select el).FirstOrDefault();


                        target.Attribute("value").Value = value;
                    }
                    else
                    {

                        xmlDocument.Element("Modules").Add(new XElement("Module",
                            new XAttribute("culture", culture),
                            new XAttribute("Id", id), new XAttribute("value", value), "")); // Elton: The space is to close the tag
                    }
                    xmlDocument.Save(filePath);
                    LoadAllModules();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Id=" + id + " and Culture=" + culture + " not found.", ex);
            }
        }

        /// <summary>
        ///Used to insert bulk module
        /// 
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool InsertUpdateModule(List<ResourceEntry> entries)
        {

            lock (_moduleUpdateLock)
            {
                var xmlDocument = XDocument.Parse(File.ReadAllText(filePath));
                foreach (var entry in entries)
                {
                    try
                    {
                        ResourceEntry entry1 = entry;
                        if (_moduleList.Any(m => m.Id == entry1.Id && m.Culture == entry1.Culture))
                        {
                            ResourceEntry entry2 = entry;
                            var target = (from el in xmlDocument.Element("Modules").Elements("Module")
                                          where
                                              (string)el.Attribute("Id") == entry2.Id.ToString() &&
                                              (string)el.Attribute("culture") == entry2.Culture
                                          select el).FirstOrDefault();


                            target.Attribute("value").Value = entry.Value;
                        }
                        else
                        {

                            xmlDocument.Element("Modules").Add(new XElement("Module",
                                new XAttribute("culture", entry.Culture),
                                new XAttribute("Id", entry.Id), new XAttribute("value", entry.Value), "")); // Elton: The space is to close the tag

                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException("Id=" + entry.Id + " and Culture=" + entry.Culture + " not found.", ex);
                    }
                }

                xmlDocument.Save(filePath);
                LoadAllModules();
            }
            return true;

        }
    }
}
