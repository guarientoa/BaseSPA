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
	public class SurveysController : ODataController
	{
		private readonly SpaContext _db;
		public SurveysController(ContextFactory contextFactory) { _db = contextFactory.GetContext<SpaContext>(); }
		[EnableQuery]
		public IQueryable<Survey> GetSurveys() => _db.Surveys;
		[EnableQuery]
		public SingleResult<Survey> GetSurvey([FromODataUri] int key) => SingleResult.Create(_db.Surveys.Where(b => b.Id == key));

		[AcceptVerbs("PATCH", "MERGE")]
		public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Survey> patch)
		{
			Validate(patch.GetEntity());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var survey = await _db.Surveys.FindAsync(key);
			if (survey == null)
				return NotFound();

			patch.Patch(survey);
			_db.Entry(survey).State = EntityState.Modified;

			await _db.SaveChangesAsync();
			return Updated(survey);
		}

		public async Task<IHttpActionResult> Post(Survey survey)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_db.Surveys.Add(survey);
			await _db.SaveChangesAsync();

			return Created(survey);
		}

		public async Task<IHttpActionResult> Delete([FromODataUri] int key)
		{
			var entity = await _db.Surveys.FindAsync(key);
			if (entity == null)
				return NotFound();

			_db.Surveys.Remove(entity);
			await _db.SaveChangesAsync();

			return StatusCode(HttpStatusCode.OK);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_db.Dispose();
			base.Dispose(disposing);
		}
	}
}
