using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSPA.Core.Models
{
    using System;
    using System.Collections.Generic;
	[Table("Answer")]
	public partial class Answer
    {
	    [Key]
		public int Id { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string AnswerText { get; set; }
        public DateTime? dtAgg { get; set; }

	    [ForeignKey("QuestionId")]
			public virtual Question Question { get; set; }
    }
}
