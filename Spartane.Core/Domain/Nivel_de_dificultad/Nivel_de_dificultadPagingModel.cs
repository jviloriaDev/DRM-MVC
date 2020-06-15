using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Nivel_de_dificultad
{
    public class Nivel_de_dificultadPagingModel
    {
        public List<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> Nivel_de_dificultads { set; get; }
        public int RowCount { set; get; }
    }
}
