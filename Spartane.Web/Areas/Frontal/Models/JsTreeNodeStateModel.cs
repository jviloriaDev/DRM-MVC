using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Models
{
    /// <summary>
    /// Clase para manejar los estados de un nodo
    /// </summary>
    public class JsTreeNodeStateModel
    {
        /// <summary>
        /// indica si el nodo esta abierto
        /// </summary>
        public bool opened { get; set; }

        /// <summary>
        /// indica si esta deshabilitado
        /// </summary>
        public bool disabled { get; set; }

        /// <summary>
        /// indica si esta seleccionado
        /// </summary>
        public bool selected { get; set; }
    }

}
