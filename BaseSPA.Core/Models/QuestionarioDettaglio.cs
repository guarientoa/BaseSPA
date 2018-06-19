using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSPA.Core.Models
{
	[Table("QuestionarioDettaglio")]
	public class QuestionarioDettaglio
	{
		[Key]
		public Guid IdDettaglio { get; set; }
		public string Domanda { get; set; }

		public Guid IdQuestionario { get; set; }
		public Questionari	Questionari { get; set; }

		//public Guid IdDomanda { get; set; }
		//public RisposteSondaggio Risposte { get; set; }

		public virtual List<RisposteSondaggio> RisposteSondaggio { get; set; }
	}
}