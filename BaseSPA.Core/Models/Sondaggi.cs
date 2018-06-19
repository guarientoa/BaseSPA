using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSPA.Core.Models
{
	[Table("Sondaggi")]
	public class Sondaggi
	{
		[Key]
		public Guid IdSondaggio { get; set; }
		public string Note { get; set; }

		public Guid IdQuestionario { get; set; }
		public Questionari	Questionari { get; set; }

		public virtual List<RisposteSondaggio> RisposteSondaggio { get; set; }
	}
}