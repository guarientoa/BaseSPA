using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSPA.Core.Models
{
	[Table("Questionari")]
	public class Questionari
	{
		[Key]
		public Guid IdQuestionario { get; set; }
		public string Titolo { get; set; }

		public virtual List<QuestionarioDettaglio> DomandeQuestionario { get; set; }
		public virtual List<Sondaggi> Sondaggi { get; set; }
	}
}