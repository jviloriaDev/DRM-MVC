using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Models
{
    /// <summary>
    /// Clase mara mmanipular los nodos del jsTree
    /// </summary>
    public class JsTreeNodeModel
    {

        /// <summary>
        /// requerido
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// object id
        /// </summary>
        public int objectId { get; set; }

        /// <summary>
        /// Texto que se mostrara en el nodo
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// icono a mostrar
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// Atributos del elemento li
        /// </summary>
        public JsTreeAttributeModel li_attr { get; set; }

        /// <summary>
        /// Atributos del elemento a
        /// </summary>
        public JsTreeAttributeModel a_attr { get; set; }

        /// <summary>
        /// Estado del noso
        /// </summary>
        public JsTreeNodeStateModel state { get; set; }

        /// <summary>
        /// Hijos del nodo
        /// </summary>
        public List<JsTreeNodeModel> children { get; set; }
    }

    


}