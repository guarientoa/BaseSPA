using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSPA.Core.Models
{
	[Table("RisposteSondaggio")]
	public class RisposteSondaggio
	{
		[Key]
		public Guid IdDomanda { get; set; }
		public int Punteggio { get; set; }

		public Guid IdSondaggio { get; set; }
		public Sondaggi	Sondaggio { get; set; }

		//public Guid IdQuestionario { get; set; }
		//public QuestionarioDettaglio DomandeSondaggio { get; set; }
		//public virtual List<QuestionarioDettaglio> DomandeSondaggio { get; set; }

		public Guid IdDettaglio { get; set; }
		public Sondaggi QuestionarioDettaglio { get; set; }
	}
}