using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Detail;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using System.Web.Mvc;
using Spartane.Core.Domain.Spartan_Traduction_Detail;
using Spartane.Core.Domain.Spartan_Traduction_Process;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process;
using System.Xml.Linq;
using System.Configuration;
using Spartane.Core.Domain.Spartan_Traduction_Process_Data;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Data;
using System.Xml;
using Spartane.Core.Domain.SpartaneObject;
using System.IO;

namespace Spartane.Web.Helpers
{
    public static class CultureHelper
    {
        private static readonly ITokenManager _tokenManager;
        private static readonly ISpartaneObjectApiConsumer _spartaneObjectApiConsumer;
        private static readonly ISpartan_MetadataApiConsumer _spartaneMetadataApiConsumer;
        private static readonly ISpartan_Traduction_DetailApiConsumer _spartan_Traduction_DetailApiConsumer;
        private static readonly ISpartan_Traduction_ProcessApiConsumer _spartan_Traduction_ProcessApiConsumer;
        private static readonly ISpartan_Traduction_Process_DataApiConsumer _spartan_Traduction_Process_DataApiConsumer;
        // Valid cultures
        private static readonly List<string> _validCultures = new List<string> { "af", "af-ZA", "sq", "sq-AL", "gsw-FR", "am-ET", "ar", "ar-DZ", "ar-BH", "ar-EG", "ar-IQ", "ar-JO", "ar-KW", "ar-LB", "ar-LY", "ar-MA", "ar-OM", "ar-QA", "ar-SA", "ar-SY", "ar-TN", "ar-AE", "ar-YE", "hy", "hy-AM", "as-IN", "az", "az-Cyrl-AZ", "az-Latn-AZ", "ba-RU", "eu", "eu-ES", "be", "be-BY", "bn-BD", "bn-IN", "bs-Cyrl-BA", "bs-Latn-BA", "br-FR", "bg", "bg-BG", "ca", "ca-ES", "zh-HK", "zh-MO", "zh-CN", "zh-Hans", "zh-SG", "zh-TW", "zh-Hant", "co-FR", "hr", "hr-HR", "hr-BA", "cs", "cs-CZ", "da", "da-DK", "prs-AF", "div", "div-MV", "nl", "nl-BE", "nl-NL", "en", "en-AU", "en-BZ", "en-CA", "en-029", "en-IN", "en-IE", "en-JM", "en-MY", "en-NZ", "en-PH", "en-SG", "en-ZA", "en-TT", "en-GB", "en-US", "en-ZW", "et", "et-EE", "fo", "fo-FO", "fil-PH", "fi", "fi-FI", "fr", "fr-BE", "fr-CA", "fr-FR", "fr-LU", "fr-MC", "fr-CH", "fy-NL", "gl", "gl-ES", "ka", "ka-GE", "de", "de-AT", "de-DE", "de-LI", "de-LU", "de-CH", "el", "el-GR", "kl-GL", "gu", "gu-IN", "ha-Latn-NG", "he", "he-IL", "hi", "hi-IN", "hu", "hu-HU", "is", "is-IS", "ig-NG", "id", "id-ID", "iu-Latn-CA", "iu-Cans-CA", "ga-IE", "xh-ZA", "zu-ZA", "it", "it-IT", "it-CH", "ja", "ja-JP", "kn", "kn-IN", "kk", "kk-KZ", "km-KH", "qut-GT", "rw-RW", "sw", "sw-KE", "kok", "kok-IN", "ko", "ko-KR", "ky", "ky-KG", "lo-LA", "lv", "lv-LV", "lt", "lt-LT", "wee-DE", "lb-LU", "mk", "mk-MK", "ms", "ms-BN", "ms-MY", "ml-IN", "mt-MT", "mi-NZ", "arn-CL", "mr", "mr-IN", "moh-CA", "mn", "mn-MN", "mn-Mong-CN", "ne-NP", "no", "nb-NO", "nn-NO", "oc-FR", "or-IN", "ps-AF", "fa", "fa-IR", "pl", "pl-PL", "pt", "pt-BR", "pt-PT", "pa", "pa-IN", "quz-BO", "quz-EC", "quz-PE", "ro", "ro-RO", "rm-CH", "ru", "ru-RU", "smn-FI", "smj-NO", "smj-SE", "se-FI", "se-NO", "se-SE", "sms-FI", "sma-NO", "sma-SE", "sa", "sa-IN", "sr", "sr-Cyrl-BA", "sr-Cyrl-SP", "sr-Latn-BA", "sr-Latn-SP", "nso-ZA", "tn-ZA", "si-LK", "sk", "sk-SK", "sl", "sl-SI", "es", "es-AR", "es-BO", "es-CL", "es-CO", "es-CR", "es-DO", "es-EC", "es-SV", "es-GT", "es-HN", "es-MX", "es-NI", "es-PA", "es-PY", "es-PE", "es-PR", "es-ES", "es-US", "es-UY", "es-VE", "sv", "sv-FI", "sv-SE", "syr", "syr-SY", "tg-Cyrl-TJ", "tzm-Latn-DZ", "ta", "ta-IN", "tt", "tt-RU", "te", "te-IN", "th", "th-TH", "bo-CN", "tr", "tr-TR", "tk-TM", "ug-CN", "uk", "uk-UA", "wen-DE", "ur", "ur-PK", "uz", "uz-Cyrl-UZ", "uz-Latn-UZ", "vi", "vi-VN", "cy-GB", "wo-SN", "sah-RU", "ii-CN", "yo-NG" };

        // Include ONLY cultures you are implementing
        private static readonly List<string> _cultures = new List<string> {
            "es-ES",  // first culture is the DEFAULT
            "en-US" // Spanish NEUTRAL culture
            //"ar"  // Arabic NEUTRAL culture
           
        };

        static CultureHelper()
        {
            _tokenManager = DependencyResolver.Current.GetService<ITokenManager>();
            _spartaneObjectApiConsumer = DependencyResolver.Current.GetService<ISpartaneObjectApiConsumer>();
            _spartaneMetadataApiConsumer = DependencyResolver.Current.GetService<ISpartan_MetadataApiConsumer>();
            _spartan_Traduction_DetailApiConsumer = DependencyResolver.Current.GetService<ISpartan_Traduction_DetailApiConsumer>();
            _spartan_Traduction_ProcessApiConsumer = DependencyResolver.Current.GetService<ISpartan_Traduction_ProcessApiConsumer>();
            _spartan_Traduction_Process_DataApiConsumer = DependencyResolver.Current.GetService<ISpartan_Traduction_Process_DataApiConsumer>();
        }

        /// <summary>
        /// Returns true if the language is a right-to-left language. Otherwise, false.
        /// </summary>      
        public static bool IsRighToLeft()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;

        }

        public static bool IsRightToLeft()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;
        }






        /// <summary>
        /// Returns a valid culture name based on "name" parameter. If "name" is not valid, it returns the default culture "en-US"
        /// </summary>
        /// <param name="name">Culture's name (e.g. en-US)</param>
        public static string GetImplementedCulture(string name)
        {
            // make sure it's not null
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture(); // return Default culture

            // make sure it is a valid culture first
            if (_validCultures.Where(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Count() == 0)
                return GetDefaultCulture(); // return Default culture if it is invalid


            // if it is implemented, accept it
            if (_cultures.Where(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                return name; // accept it



            // Find a close match. For example, if you have "en-US" defined and the user requests "en-GB", 
            // the function will return closes match that is "en-US" because at least the language is the same (ie English)  
            var n = GetNeutralCulture(name);
            foreach (var c in _cultures)
                if (c.StartsWith(n))
                    return c;



            // else 
            // It is not implemented
            return GetDefaultCulture(); // return Default culture as no match found
        }


        /// <summary>
        /// Returns default culture name which is the first name decalared (e.g. en-US)
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultCulture()
        {
            return _cultures[0]; // return Default culture

        }

        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
        }


        public static string GetNeutralCulture(string name)
        {
            if (!name.Contains("-")) return name;

            return name.Split('-')[0]; // Read first part only. E.g. "en", "es"
        }

        public static void ProcessResources(int object_id, int? languageId = null)
        {
            if (!_tokenManager.GenerateToken("admin", "admin"))
                throw new ArgumentException("Unable to Authorize the application");
            _spartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            _spartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            _spartan_Traduction_ProcessApiConsumer.SetAuthHeader(_tokenManager.Token);
            _spartaneMetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            bool ret = false;

            if ((object_id == 5 || object_id == 6 && languageId != null))
            {
                ProcessFormatRepostFile(Convert.ToInt32(languageId), object_id);
                ret = true;
            }
            for (int i = 1; i < _cultures.Count + 1; i++)
            {
                if (object_id == 1)
                {
                    ProcessRolesFile(i);
                    ret = true;
                }
                if (object_id == 2)
                {
                    ProcessModulesFile(i);
                    ret = true;
                }
                if (object_id == 3)
                {
                    ProcessObjectFile(i);
                    ret = true;
                }
                if (object_id == 4)
                {
                    ProcessGenericTextFile(i);
                    ret = true;
                }
               
                if (!ret)
                {
                    ProcessObjects(i, object_id);
                    ProcessDataControl(i, object_id);
                }

            }
        }

        private static void ProcessDataControl(int idLanguage, int object_id)
        {
            SpartaneObjectPagingModel objects = null;
            if (object_id == 0)
            {
                objects = _spartaneObjectApiConsumer.ListaSelAll(0, 9999, "", "").Resource;
            }
            else
            {
                string where = "Spartan_Object.Object_Id=" + object_id;
                objects = _spartaneObjectApiConsumer.ListaSelAll(0, 9999, where, "").Resource;
            }
            if (objects != null)
            {
                foreach (var obj in objects.Spartan_Objects)
                {
                    string language = _cultures[idLanguage - 1];
                    string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + obj.URL + "Resource." + language + ".xml";
                    Spartan_Traduction_ProcessPagingModel processes = _spartan_Traduction_ProcessApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Process.ObjectT=" + obj.Object_Id + " AND Spartan_Traduction_Process.LanguageT=" + idLanguage, "").Resource;
                    if (processes.RowCount > 0)
                    {
                        foreach (var pr in processes.Spartan_Traduction_Processs)
                        {
                            ProcessDataControlParticular(url, obj.Object_Id, pr.IdTraduction, language);
                        }
                    }
                }
            }
        }

        private static void ProcessDataControlParticular(string url, int object_id, int process, string culture)
        {
            try
            {
                XDocument fullFile = XDocument.Load(url);
                _spartan_Traduction_Process_DataApiConsumer.SetAuthHeader(_tokenManager.Token);
                Spartan_Traduction_Process_DataPagingModel traduction_Processes_Data = _spartan_Traduction_Process_DataApiConsumer.ListaSelAll(object_id, process).Resource;
                if (traduction_Processes_Data.Spartan_Traduction_Process_Datas.Count > 0)
                {
                    string traductionDescription = "";
                    foreach (var traductionDetail in traduction_Processes_Data.Spartan_Traduction_Process_Datas)
                    {
                        traductionDescription = traductionDetail.Translated_Text;
                        var nodeToChange =
                                (from p in fullFile.Descendants("resource")
                                 where p.Attribute("name").Value == traductionDetail.Original_Text && p.Attribute("control").Value == traductionDetail.Name_of_Control
                                 select p).FirstOrDefault();
                        if (nodeToChange != null)
                            nodeToChange.Attribute("value").Value = traductionDescription;
                        else
                        {
                            var characters = fullFile.Descendants("resources").FirstOrDefault();
                            if (characters != null)
                            {
                                XElement newNode = new XElement("resource");
                                newNode.SetAttributeValue("name", traductionDetail.Original_Text);
                                newNode.SetAttributeValue("control", traductionDetail.Name_of_Control);
                                newNode.SetAttributeValue("value", traductionDescription);
                                newNode.SetAttributeValue("culture", culture);
                                characters.Add(newNode);
                                fullFile.Save(url);
                            }
                        }
                    }
                    fullFile.Save(url);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private static void ProcessRolesFile(int idLanguage)
        {
            string language = _cultures[idLanguage - 1].ToLower();

            string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\Roles.xml";
            XDocument fullFile = XDocument.Load(url);
            var traductionsDetail = _spartan_Traduction_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Detail.Concept=1 AND Spartan_Traduction_Process.LanguageT=" + idLanguage, "").Resource;
            if (traductionsDetail != null)
            {
                string IdRole = "";
                string traductionDescription = "";
                foreach (var traductionDetail in traductionsDetail.Spartan_Traduction_Details)
                {
                    IdRole = traductionDetail.IdConcept.Value.ToString();
                    traductionDescription = traductionDetail.Translated_Text;
                    var nodeToChange =
                            (from p in fullFile.Descendants("Role")
                             where p.Attribute("Id").Value == IdRole && p.Attribute("culture").Value == language
                             select p).FirstOrDefault();
                    if (nodeToChange != null)
                        nodeToChange.Attribute("value").Value = traductionDescription;
                }
                fullFile.Save(url);
            }
        }

        private static void ProcessGenericTextFile(int idLanguage)
        {
            string language = _cultures[idLanguage - 1];

            string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\Resources." + language + ".xml";
            XDocument fullFile = XDocument.Load(url);
            var traductionsDetail = _spartan_Traduction_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Detail.Concept=6 AND Spartan_Traduction_Process.LanguageT=" + idLanguage, "").Resource;
            if (traductionsDetail != null)
            {
                string Original_text = "";
                string traductionDescription = "";
                foreach (var traductionDetail in traductionsDetail.Spartan_Traduction_Details)
                {
                    Original_text = traductionDetail.Original_Text;
                    traductionDescription = traductionDetail.Translated_Text;
                    var nodeToChange =
                            (from p in fullFile.Descendants("resource")
                             where p.Attribute("name").Value == Original_text
                             select p).FirstOrDefault();
                    if (nodeToChange != null)
                        nodeToChange.Attribute("value").Value = traductionDescription;
                }
                fullFile.Save(url);
            }
        }

        private static void ProcessModulesFile(int idLanguage)
        {
            string language = _cultures[idLanguage - 1].ToLower();

            string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\ModuleResources.xml";
            XDocument fullFile = XDocument.Load(url);
            var traductionsDetail = _spartan_Traduction_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Detail.Concept=2 AND Spartan_Traduction_Process.LanguageT=" + idLanguage, "").Resource;
            if (traductionsDetail != null)
            {
                string IdModule = "";
                string traductionDescription = "";
                foreach (var traductionDetail in traductionsDetail.Spartan_Traduction_Details)
                {
                    IdModule = traductionDetail.IdConcept.Value.ToString();
                    traductionDescription = traductionDetail.Translated_Text;
                    var nodeToChange =
                            (from p in fullFile.Descendants("Module")
                             where p.Attribute("Id").Value == IdModule && p.Attribute("culture").Value == language
                             select p).FirstOrDefault();
                    if (nodeToChange != null)
                        nodeToChange.Attribute("value").Value = traductionDescription;
                }
                fullFile.Save(url);
            }
        }

        private static void ProcessObjectFile(int idLanguage)
        {
            string language = _cultures[idLanguage - 1].ToLower();

            string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\ObjectResources.xml";
            XDocument fullFile = XDocument.Load(url);
            var traductionsDetail = _spartan_Traduction_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Detail.Concept=3 AND Spartan_Traduction_Process.LanguageT=" + idLanguage, "").Resource;
            if (traductionsDetail != null)
            {
                string IdObject = "";
                string traductionDescription = "";
                foreach (var traductionDetail in traductionsDetail.Spartan_Traduction_Details)
                {
                    IdObject = traductionDetail.IdConcept.Value.ToString();
                    traductionDescription = traductionDetail.Translated_Text;
                    var nodeToChange =
                            (from p in fullFile.Descendants("Object")
                             where p.Attribute("Id").Value == IdObject && p.Attribute("culture").Value == language
                             select p).FirstOrDefault();
                    if (nodeToChange != null)
                        nodeToChange.Attribute("value").Value = traductionDescription;
                }
                fullFile.Save(url);
            }
        }
        private static void ProcessFormatRepostFile(int idLanguage, int objectType)
        {
            string language = idLanguage == 1 ? _cultures[idLanguage].ToLower() : _cultures[0].ToLower();


            string nameResource = objectType == 5 ? "Format" : "Report";
            int concept = objectType == 5 ? 9 : 10;

            string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + nameResource + "Resources.xml";

            if (!File.Exists(url))
            {
                using (File.Create(url)) ;
            }
            XDocument fullFile = XDocument.Load(url);
            var traductionsDetail = _spartan_Traduction_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Detail.Concept=" + concept + " AND Spartan_Traduction_Process.LanguageT=" + idLanguage, "").Resource;
            if (traductionsDetail != null)
            {
                string IdResource = "";
                string traductionDescription = "";
                foreach (var traductionDetail in traductionsDetail.Spartan_Traduction_Details)
                {
                    IdResource = traductionDetail.IdConcept.Value.ToString();
                    traductionDescription = traductionDetail.Translated_Text;
                    if (traductionDescription != null)
                    {

                        var elements = XDocument.Parse(File.ReadAllText(url)).Element(nameResource + "s");

                        if (elements.Descendants().Count() > 0 && elements.Descendants().Where(n => n.Attribute("Id").Value == IdResource && n.Attribute("culture").Value == language).Count() > 0)
                        {
                            var nodeToChange = fullFile.Descendants(nameResource).Where(p => p.Attribute("Id").Value == IdResource && p.Attribute("culture").Value == language).FirstOrDefault();

                            if (nodeToChange != null)
                                nodeToChange.Attribute("value").Value = traductionDescription;
                        }
                        else
                        {
                            fullFile.Element(nameResource + "s").Add(new XElement(nameResource,
                               new XAttribute("culture", language),
                               new XAttribute("Id", IdResource), new XAttribute("value", traductionDescription), "")); // Elton: The space is to close the tag
                        }
                    }

                }
                fullFile.Save(url);
            }
        }


        private static void ProcessObjects(int idLanguage, int object_id)
        {
            SpartaneObjectPagingModel objects = null;
            if (object_id == 0)
            {
                objects = _spartaneObjectApiConsumer.ListaSelAll(0, 9999, "", "").Resource;
            }
            else
            {
                string where = "Spartan_Object.Object_Id=" + object_id;
                objects = _spartaneObjectApiConsumer.ListaSelAll(0, 9999, where, "").Resource;
            }
            if (objects != null)
            {
                foreach (var obj in objects.Spartan_Objects)
                {
                    if (obj.URL.Contains("Quick"))
                    {
                        string a = "";
                    }
                    Spartan_Traduction_ProcessPagingModel traduction_Processes = _spartan_Traduction_ProcessApiConsumer.ListaSelAll(0, 10, "Spartan_Traduction_Process.ObjectT=" + obj.Object_Id + " AND Spartan_Traduction_Process.LanguageT=" + idLanguage, "").Resource;
                    if (traduction_Processes.RowCount > 0)
                    {
                        var traduction_Process = traduction_Processes.Spartan_Traduction_Processs[0];
                        int idTraduction = traduction_Process.IdTraduction;
                        ProcessObject(idLanguage, obj.URL, idTraduction);
                        ProcessObjectTabs(idLanguage, obj.URL, idTraduction);
                        ProcessObjectHeaders(idLanguage, obj.URL, idTraduction);
                    }
                }
            }

        }

        private static void ProcessObject(int idLanguage, string nameObject, int idTraduction)
        {
            string language = _cultures[idLanguage - 1];

            string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + nameObject + "Resource." + language + ".xml";
            try
            {
                XDocument fullFile = XDocument.Load(url);
                var traductionsDetail = _spartan_Traduction_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Detail.Concept=5 AND Spartan_Traduction_Process.LanguageT=" + idLanguage + " AND Spartan_Traduction_Process.IdTraduction= " + idTraduction, "").Resource;
                if (traductionsDetail != null)
                {
                    int AttributeId = 0;
                    string traductionDescription = "";
                    foreach (var traductionDetail in traductionsDetail.Spartan_Traduction_Details)
                    {
                        AttributeId = traductionDetail.IdConcept.Value;
                        Spartan_Metadata metadata = _spartaneMetadataApiConsumer.GetByKey(AttributeId, false).Resource;
                        traductionDescription = traductionDetail.Translated_Text;
                        var nodeToChange =
                                (from p in fullFile.Descendants("resource")
                                 where p.Attribute("name").Value == metadata.Physical_Name
                                 select p).FirstOrDefault();
                        if (nodeToChange != null)
                            nodeToChange.Attribute("value").Value = traductionDescription;
                    }
                    fullFile.Save(url);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private static void ProcessObjectTabs(int idLanguage, string nameObject, int idTraduction)
        {
            string language = _cultures[idLanguage - 1];

            string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + nameObject + "Resource." + language + ".xml";
            try
            {
                XDocument fullFile = XDocument.Load(url);
                var traductionsDetail = _spartan_Traduction_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Detail.Concept=4 AND Spartan_Traduction_Process.LanguageT=" + idLanguage + " AND Spartan_Traduction_Process.IdTraduction= " + idTraduction, "").Resource;
                if (traductionsDetail != null)
                {
                    string name = "";
                    string traductionDescription = "";
                    foreach (var traductionDetail in traductionsDetail.Spartan_Traduction_Details)
                    {
                        name = "Tab" + traductionDetail.Original_Text
                            .Replace(" ", "_")
                            .Replace("á", "a")
                            .Replace("é", "e")
                            .Replace("í", "i")
                            .Replace("ó", "o")
                            .Replace("ú", "u");
                        traductionDescription = traductionDetail.Translated_Text;
                        var nodeToChange =
                                (from p in fullFile.Descendants("resource")
                                 where p.Attribute("name").Value == name
                                 select p).FirstOrDefault();
                        if (nodeToChange != null)
                            nodeToChange.Attribute("value").Value = traductionDescription;
                    }
                    fullFile.Save(url);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private static void ProcessObjectHeaders(int idLanguage, string nameObject, int idTraduction)
        {
            string language = _cultures[idLanguage - 1];

            string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + nameObject + "Resource." + language + ".xml";
            try
            {
                XDocument fullFile = XDocument.Load(url);
                var traductionsDetail = _spartan_Traduction_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_Traduction_Detail.Concept=3 AND Spartan_Traduction_Process.LanguageT=" + idLanguage + " AND Spartan_Traduction_Process.IdTraduction= " + idTraduction, "").Resource;
                if (traductionsDetail != null)
                {
                    string name = "";
                    string traductionDescription = "";
                    foreach (var traductionDetail in traductionsDetail.Spartan_Traduction_Details)
                    {
                        name = traductionDetail.Original_Text
                            .Replace(" ", "_")
                            .Replace("á", "a")
                            .Replace("é", "e")
                            .Replace("í", "i")
                            .Replace("ó", "o")
                            .Replace("ú", "u");
                        traductionDescription = traductionDetail.Translated_Text;
                        var nodeToChange =
                                (from p in fullFile.Descendants("resource")
                                 where p.Attribute("name").Value == name
                                 select p).FirstOrDefault();
                        if (nodeToChange != null)
                            nodeToChange.Attribute("value").Value = traductionDescription;
                    }
                    fullFile.Save(url);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }


        /*public static object GetTraduction(string id, string objectName, object defValue, string nameOfControl = "") 
        {
            try
            {
               

                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue;

                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return defValue;
            }

        }
        */

        public static string GetTraduction(string id, string objectName, string defValue, string nameOfControl = "")
        {
            try
            {
				defValue = defValue == "" ? null : defValue;
                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
				/*
                if (nodeTraduction == null)
				{
					if (defValue == null)
					{
						string[] names = objectName.Split('_');
						string newString = "";
						foreach (string word in names)
						{
							newString = newString + word + " ";
						}
						defValue = newString.Trim();
					}
					return defValue;
				}
				*/
				if (nodeTraduction == null)
                    return defValue;
				
                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return defValue;
            }

        }

        public static string GetTraduction(string id, string objectName, int? defValue, string nameOfControl = "")
        {
            try
            {
                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue.HasValue ? defValue.Value.ToString() : "";

                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return defValue.HasValue ? defValue.Value.ToString() : "";
            }

        }

        public static string GetTraduction(string id, string objectName, DateTime? defValue, string nameOfControl = "")
        {
            try
            {
                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue.HasValue ? defValue.Value.ToShortDateString() : "";

                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return defValue.HasValue ? defValue.Value.ToShortDateString() : "";
            }

        }		
		

        public static string GetTraductionNew(string id, string objectName, int defValue, string nameOfControl = "")
        {
            try
            {


                return defValue.ToString();
            }
            catch (Exception)
            {
                return defValue.ToString();
            }

        }
		
		public static object GetTraductionNew(string id, string objectName, object defValue, string nameOfControl = "") 
        {
            try
            {
               

                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue;

                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return defValue;
            }

        }


        public static string GetTraductionNew(string id, string objectName, string defValue = "", string nameOfControl = "")
        {
            try
            {
                defValue = defValue == "" ? null : defValue;
                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue;

                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return defValue;
            }

        }

        public static int GetTraductionint(string id, string objectName, int? defValue, string nameOfControl = "")
        {
            try
            {
                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue.HasValue ? defValue.Value : 0;

                var result = nodeTraduction.Attribute("value").Value;
                return Convert.ToInt32(result);
            }
            catch (Exception)
            {
                return defValue.HasValue ? defValue.Value : 0;
            }

        }

        public static string GetTraduction(string id, string objectName, string nameOfControl)
        {
            try
            {

                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return null;

                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static string GetTraductionstring(string id, string objectName, string defValue, string nameOfControl = "")
        {
            try
            {

                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue;

                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return defValue;
            }

        }

        public static DateTime GetTraductionDateTime(string id, string objectName, DateTime? defValue, string nameOfControl = "")
        {
            try
            {

                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue.HasValue ? defValue.Value : DateTime.MinValue;

                var result = Convert.ToDateTime(nodeTraduction.Attribute("value").Value);
                return result;
            }
            catch (Exception)
            {
                return defValue.HasValue ? defValue.Value : DateTime.MinValue;
            }

        }
		
		public static short GetTraductionshort(string id, string objectName, short? defValue, string nameOfControl = "")
        {
            try
            {
                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue.HasValue ? defValue.Value : (short)0;

                var result = nodeTraduction.Attribute("value").Value;
                return Convert.ToInt16(result);
            }
            catch (Exception)
            {
                return defValue.HasValue ? defValue.Value : (short)0;
            }

        }

        public static string GetTraductionAdd(string id, string objectName, string defaultName)
        {
            try
            {
                string culture = GetCurrentCulture().ToLower();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resources" + ".xml";
                XDocument fullFile = XDocument.Load(url);

                var nodeTraduction = fullFile.Descendants(objectName).Where(p => p.Attribute("Id").Value == id && p.Attribute("culture").Value == culture);

                if (nodeTraduction.FirstOrDefault() == null)
                    return defaultName;
                var result = nodeTraduction.FirstOrDefault().Attribute("value").Value;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static string GetTraduction(string id, string objectName)
        {
            string defValue = "";
            string nameOfControl = "";
            try
            {
                defValue = defValue == "" ? null : defValue;
                string culture = GetCurrentCulture();
                string url = ConfigurationManager.AppSettings["BaseDirectoyPhysical"] + "Uploads\\Resources\\" + objectName + "Resource." + culture + ".xml";
                XDocument fullFile = XDocument.Load(url);
                var nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == nameOfControl + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == nameOfControl) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                if (nodeTraduction == null)
                {
                    nodeTraduction = (from p in fullFile.Descendants("resource")
                                      where p.Attribute("name").Value == objectName + "." + id && ((nameOfControl != "" && p.Attribute("control").Value == objectName) || (nameOfControl == ""))
                                      select p).FirstOrDefault();
                }
                if (nodeTraduction == null)
                    return defValue;

                var result = nodeTraduction.Attribute("value").Value;
                return result;
            }
            catch (Exception)
            {
                return defValue;
            }

        }
    }
}