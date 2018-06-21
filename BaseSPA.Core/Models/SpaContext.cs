using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSPA.Core.Models
{
	public class SpaContext : DbContext
	{
		public virtual DbSet<Answer> Answers { get; set; }
		public virtual DbSet<Question> Questions { get; set; }
		public virtual DbSet<Survey> Surveys { get; set; }
	}
}
