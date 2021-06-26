using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DBEntity//Clase para el manejor de errores
    {
        public int CodError { get; set; }
        public string MsgError { get; set; }//obtiene el detalle del error
    }
}
