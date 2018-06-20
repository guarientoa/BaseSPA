using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSPA.Core.Models
{
	using System;
	using System.Collections.Generic;
	[Table("Survey")]

	public class Survey
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Description { get; set; }
		public string Notes { get; set; }
		public DateTime? dtAgg { get; set; }

		public virtual ICollection<Question> Questions { get; set; }
	}
}
