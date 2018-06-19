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
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Questionari> Questionari { get; set; }
		public DbSet<QuestionarioDettaglio> DomandeQuestionario { get; set; }
		public DbSet<Sondaggi> Sondaggi { get; set; }

		public virtual DbSet<Answer> Answers { get; set; }
		public virtual DbSet<Question> Questions { get; set; }
		public virtual DbSet<Survey> Surveys { get; set; }
	}
}
