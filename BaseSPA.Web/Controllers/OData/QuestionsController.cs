using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using BaseSPA.Core;
using BaseSPA.Core.Models;

namespace BaseSPA.Web.Controllers.OData
{
	public class QuestionsController : ODataController
	{
		private readonly SpaContext _db;

		public QuestionsController(ContextFactory contextFactory) { _db = contextFactory.GetContext<SpaContext>(); }
		 
		[EnableQuery]
		public IQueryable<Question> GetQuestions() => _db.Questions;

		[EnableQuery]
		public SingleResult<Question> GetQuestion([FromODataUri] int key) => SingleResult.Create(_db.Questions.Where(question => question.Id == key));

		[AcceptVerbs("PATCH", "MERGE")]
		public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Question> patch)
		{
			Validate(patch.GetEntity());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var question = await _db.Questions.FindAsync(key);
			if (question == null)
				return NotFound();

			patch.Patch(question);
			_db.Entry(question).State = EntityState.Modified;

			await _db.SaveChangesAsync();

			return Updated(question);
		}

		public async Task<IHttpActionResult> Post(Question question)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_db.Questions.Add(question);
			await _db.SaveChangesAsync();

			return Created(question);
		}

		public async Task<IHttpActionResult> Delete([FromODataUri] int key)
		{
			Question question = await _db.Questions.FindAsync(key);
			if (question == null)
				return NotFound();

			_db.Questions.Remove(question);
			await _db.SaveChangesAsync();

			return StatusCode(HttpStatusCode.NoContent);
		}

		[EnableQuery]
		public SingleResult<Survey> GetSurvey([FromODataUri] int key) => SingleResult.Create(_db.Questions.Where(m => m.Id == key).Select(m => m.Survey));

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_db.Dispose();
			base.Dispose(disposing);
		}
	}
}
