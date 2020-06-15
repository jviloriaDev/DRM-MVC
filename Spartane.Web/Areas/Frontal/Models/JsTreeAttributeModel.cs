using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Models
{
   /// <summary>
   /// Clase para manejar los atributos del nodo
   /// </summary>
      public class JsTreeAttributeModel
        {
        public bool draggable { get; set; }

        public string objectName { get; set; }

        public string className { get; set; }

        public string physicalName { get; set; }

        public string logicalName { get; set; }

        public string fieldPath { get; set; }

        public string classId { get; set; }

        public string atributteId { get; set; }

        public int fieldId { get; set; }




    }

}