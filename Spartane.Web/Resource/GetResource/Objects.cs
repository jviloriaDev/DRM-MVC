using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Resources.Entities;
using System.Xml.Linq;
using System.Configuration;

namespace Resources
{
    public class Objects
    {
        private static List<ResourceEntry> _objectList;
        private static object _objectMainLock = new object();
        private static object _objectUpdateLock = new object();
        private static string filePath;
        private static bool loadingObjects;

        static Objects()
        {
            loadingObjects = false;
            filePath = Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\ObjectResources.xml");
            LoadAllObjects();
        }

        /// <summary>
        /// Used to load all Objects from the xml
        /// </summary>
        private static void LoadAllObjects()
        {
            loadingObjects = true;
            lock (_objectMainLock)
            {
                _objectList = XDocument.Parse(File.ReadAllText(filePath))
                .Element("Objects")
                .Elements("Object")
                .Select(e => new ResourceEntry
                {
                    Id = Convert.ToInt32(e.Attribute("Id").Value),
                    Value = e.Attribute("value").Value,
                    Culture = e.Attribute("culture").Value
                }).ToList();
            }
            loadingObjects = false;
        }

        /// <summary>
        /// Used to get the get Module Value(Using current culture)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetObjectValueById(long id)
        {
            return GetObjectValueById(id, CultureInfo.CurrentUICulture.Name);
        }
        /// <summary>
        /// Used to get the get Object Value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string GetObjectValueById(long id, string culture)
        {
            if (culture==null)
                culture = "es-es";

            if (culture=="")
                culture = "es-es";

            string result = "";
            try
            {
                if (loadingObjects)
                    lock (_objectUpdateLock)
                        lock (_objectMainLock)
                        { }

                culture = culture.ToLower();
                result= _objectList.FirstOrDefault(m => m.Id == id && m.Culture == culture).Value;
            }
            catch (Exception)
            {
                result="Id=" + id + " and Culture=" + culture + " not found.";
                //throw new Exception("Id=" + id + " and Culture=" + culture + " not found.", ex);
            }
            return result;
        }

        /// <summary>
        /// Used to insert new Object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool InsertUpdateObject(int id, string value, string culture)
        {
            if (culture == null)
                culture = "es-es";

            if (culture == "")
                culture = "es-es";
            try
            {
                lock (_objectUpdateLock)
                {
                    var xmlDocument = XDocument.Parse(File.ReadAllText(filePath));
                    if (_objectList.Any(m => m.Id == id && m.Culture == culture))
                    {
                        var target = (from el in xmlDocument.Element("Objects").Elements("Object")
                                      where
                                          (string)el.Attribute("Id") == id.ToString() &&
                                          (string)el.Attribute("culture") == culture
                                      select el).FirstOrDefault();


                        target.Attribute("value").Value = value;
                    }
                    else
                    {

                        xmlDocument.Element("Objects").Add(new XElement("Object",
                            new XAttribute("Id", id),
                            new XAttribute("culture", culture), new XAttribute("value", value)));

                    }
                    xmlDocument.Save(filePath);
                    LoadAllObjects();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Id=" + id + " and Culture=" + culture + " not found.", ex);
            }
        }

        /// <summary>
        ///Used to insert bulk Object
        /// 
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static bool InsertUpdateObject(List<ResourceEntry> entries)
        {
           
                lock (_objectUpdateLock)
                {
                    var xmlDocument = XDocument.Parse(File.ReadAllText(filePath));
                    foreach (var entry in entries)
                    {
                        try
                        {
                            ResourceEntry entry1 = entry;
                            if (_objectList.Any(m => m.Id == entry1.Id && m.Culture == entry1.Culture))
                            {
                                ResourceEntry entry2 = entry;
                                var target = (from el in xmlDocument.Element("Objects").Elements("Object")
                                    where
                                        (string) el.Attribute("Id") == entry2.Id.ToString() &&
                                        (string) el.Attribute("culture") == entry2.Culture
                                    select el).FirstOrDefault();


                                target.Attribute("value").Value = entry.Value;
                            }
                            else
                            {

                                xmlDocument.Element("Objects").Add(new XElement("Object",
                                    new XAttribute("Id", entry.Id),
                                    new XAttribute("culture", entry.Culture), new XAttribute("value", entry.Value)));

                            }
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException("Id=" + entry.Id + " and Culture=" + entry.Culture + " not found.", ex);
                        }
                    }

                    xmlDocument.Save(filePath);
                    LoadAllObjects();
                }
                return true;
           
        }
    }
}
