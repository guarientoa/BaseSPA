using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSPA.Core.Models
{
    using System;
    using System.Collections.Generic;
	[Table("Question")]

	public partial class Question
    {
			public Question() => Answers = new HashSet<Answer>();
	    [Key]
		public int Id { get; set; }
      public int SurveyId { get; set; }
      public string QuestionText { get; set; }
      public string Type { get; set; }
      public int? Sorting { get; set; }
      public DateTime? dtAgg { get; set; }
    
      public virtual ICollection<Answer> Answers { get; set; }
	    [ForeignKey("Id")]
		public virtual Survey Survey { get; set; }
    }
}
