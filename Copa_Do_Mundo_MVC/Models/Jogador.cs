using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Copa_Do_Mundo_MVC.Models
{
	[Table("Jogadores")]
	public class Jogador
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório.")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O campo Posicao é obrigatorio")]
		public string Posicao { get; set; }

		[DataType(DataType.Date)]
		public DateTime Nascimento { get; set; }

		[Required(ErrorMessage = "O campo Altura é 19 obrigatório.")]
		public double Altura { get; set; }

		public int SelecaoId { get; set; }


		[InverseProperty("Jogadores")]
		public Selecao Selecao { get; set; }
	}
}