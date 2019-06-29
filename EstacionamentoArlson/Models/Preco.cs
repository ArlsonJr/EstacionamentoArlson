using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoArlson.Models
{
    [Table("Precos")]
    public class Preco
    {
        [Key]
        public int CodigoPreco { get; set; }

        [Display(Name = "Segunda-Feira")]
        public bool Segunda { get; set; }

        [Display(Name = "Terça-Feira")]
        public bool Terca { get; set; }

        [Display(Name = "Quarta-Feira")]
        public bool Quarta { get; set; }

        [Display(Name = "Quinta-Feira")]
        public bool Quinta { get; set; }

        [Display(Name = "Sexta-Feira")]
        public bool Sexta { get; set; }

        [Display(Name = "Sábado")]
        public bool Sabado { get; set; }

        [Display(Name = "Domingo")]
        public bool Domingo { get; set; }

        [Display(Name = "Hora Inicial")]
        public DateTime HoraInicial { get; set; }

        [Display(Name = "Hora Final")]
        public DateTime? HoraFinal { get; set; }

        [Display(Name = "Valor por hora")]
        public double ValorHora { get; set; }

        [Display(Name = "Valor por hora Adicional")]
        public double ValorHoraAdicional { get; set; }
    }
}