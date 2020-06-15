using System.IO;
using Resources.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Globalization;

namespace Resources
{
    public class Roles
    {
        private static List<ResourceEntry> _rolesList;
        private static object _objectMainLock = new object();
        private static object _objectUpdateLock = new object();
        private static string filePath;
        private static bool loadingObjects;

        static Roles()
        {
            loadingObjects = false;
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Roles.xml");
            LoadAllRoles();
        }
        
        /// <summary>
        /// Used to load all Objects from the xml
        /// </summary>
        private static void LoadAllRoles()
        {
            loadingObjects = true;
            lock (_objectMainLock)
            {
                _rolesList = XDocument.Parse(File.ReadAllText(filePath))
                .Element("Roles")
                .Elements("Role")
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
        public static string GetRoleValueById(long id)
        {
            return GetRoleValueById(id, CultureInfo.CurrentUICulture.Name);
        }

        /// <summary>
        /// Used to get the get Object Value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string GetRoleValueById(long id, string culture)
        {
            try
            {
                if (loadingObjects)
                    lock (_objectUpdateLock)
                        lock (_objectMainLock)
                        { }

                culture = culture.ToLower();
                return _rolesList.FirstOrDefault(m => m.Id == id && m.Culture == culture).Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Id=" + id + " and Culture=" + culture + " not found.", ex);
            }
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
            try
            {
                lock (_objectUpdateLock)
                {
                    var xmlDocument = XDocument.Parse(File.ReadAllText(filePath));
                    if (_rolesList.Any(m => m.Id == id && m.Culture == culture))
                    {
                        var target = (from el in xmlDocument.Element("Roles").Elements("Role")
                                      where
                                          (string)el.Attribute("Id") == id.ToString() &&
                                          (string)el.Attribute("culture") == culture
                                      select el).FirstOrDefault();


                        target.Attribute("value").Value = value;
                    }
                    else
                    {

                        xmlDocument.Element("Roles").Add(new XElement("Role",
                            new XAttribute("culture", culture),
                            new XAttribute("Id", id), new XAttribute("value", value), "")); // Elton: The space is to close the tag

                    }
                    xmlDocument.Save(filePath);
                    LoadAllRoles();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Id=" + id + " and Culture=" + culture + " not found.", ex);
            }
        }

        /// <summary>
        ///Used to insert bulk Roles
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static bool InsertUpdateRoles(List<ResourceEntry> entries)
        {

            lock (_objectUpdateLock)
            {
                var xmlDocument = XDocument.Parse(File.ReadAllText(filePath));
                foreach (var entry in entries)
                {
                    try
                    {
                        ResourceEntry entry1 = entry;
                        if (_rolesList.Any(m => m.Id == entry1.Id && m.Culture == entry1.Culture))
                        {
                            ResourceEntry entry2 = entry;
                            var target = (from el in xmlDocument.Element("Roles").Elements("Role")
                                          where
                                              (string)el.Attribute("Id") == entry2.Id.ToString() &&
                                              (string)el.Attribute("culture") == entry2.Culture
                                          select el).FirstOrDefault();


                            target.Attribute("value").Value = entry.Value;
                        }
                        else
                        {

                            xmlDocument.Element("Roles").Add(new XElement("Role",
                                new XAttribute("Id", entry.Id),
                                new XAttribute("culture", entry.Culture), new XAttribute("value", entry.Value), "")); // Elton: The space is to close the tag

                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException("Id=" + entry.Id + " and Culture=" + entry.Culture + " not found.", ex);
                    }
                }

                xmlDocument.Save(filePath);
                LoadAllRoles();
            }
            return true;

        }

    }
}