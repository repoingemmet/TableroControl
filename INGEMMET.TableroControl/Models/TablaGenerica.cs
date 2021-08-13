using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INGEMMET.TableroControl.Models
{
    public class TablaGenerica
    {
        public string tipo { get; set; }

        public string codigo { get; set; }

        public string descripcion { get; set; }

        public string indicadorActivo { get; set; }

        public int? orden { get; set; }

        public string detalle { get; set; }

        public string adicional { get; set; }

        public string adicional2 { get; set; }

        public string adicional3 { get; set; }
    }
}