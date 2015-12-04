using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MVCIdiomas.Idiomas;

namespace MVCIdiomas.Models
{
    public class Persona
    {
        [Display(ResourceType = typeof (Personas), Name = "Nombre")]
        [Required(ErrorMessageResourceType = typeof (Personas), ErrorMessageResourceName = "Nombre_o")]
        public String Nombre { get; set; }

        [Required(ErrorMessageResourceType = typeof (Personas), ErrorMessageResourceName = "Saldo_o")]
        [DataType(DataType.Currency, ErrorMessageResourceType = typeof (Personas),
            ErrorMessageResourceName = "Saldo_formato")]
        [Display(ResourceType = typeof (Personas), Name = "Saldo")]
        public double Saldo { get; set; }

    }
}
