using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoArlson.Models
{
    public class Estacionamento
    {
        [Key]
        public int CodigoEstacionamento { get; set; }

        [Required(ErrorMessage = "Informe a Placa")]
        public string Placa { get; set; }

        [Display(Name = "Tempo Cobrado")]
        public int? TempoCobrado { get; set; }

        [Display(Name = "Valor Total")]
        public double? ValorTotal { get; set; }

        [Required(ErrorMessage = "Informe a Hora Entrada")]
        public DateTime Entrada { get ; set; }

        [Required(ErrorMessage = "Informe a Hora Saída")]
        public DateTime? Saida { get; set; }

        public TimeSpan? Duracao { get { return Saida != null ? Entrada.Subtract(Saida.Value) : (TimeSpan?)null; } }

        [Required]
        [ForeignKey("Preco")]
        public int IdPreco { get; set; }

        public virtual Preco Preco { get; set; }
    }
}