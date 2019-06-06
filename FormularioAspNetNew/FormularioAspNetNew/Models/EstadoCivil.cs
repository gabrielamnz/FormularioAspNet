using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FormularioAspNetNew.Models
{
    public enum EstadoCivil
    {
        [Display(Name = "Solteiro(a)")]
        Solteiro,

        [Display(Name = "Casado(a)")]
        Casado,

        [Display(Name = "Divorciado(a)")]
        Divorciado,

        [Display(Name = "Viuvo(a)")]
        Viuvo,

        [Display(Name = "Separado(a)")]
        Separado
    }
}