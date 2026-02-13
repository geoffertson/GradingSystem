using Assessment.Application.UseCases.FinalizeGrade;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.API.Controllers
{
    [ApiController]
    [Route("api/grades")]
    public sealed class GradesController : ControllerBase
    {
        private readonly FinalizeGradeHandler _handler;

        public GradesController(FinalizeGradeHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("{gradeId}/finalize")]
        public async Task<IActionResult> FinalizeGrade(
            Guid gradeId,
            CancellationToken cancellationToken)
        {
            var result = await _handler.Handle(
                new FinalizeGradeCommand(gradeId),
                cancellationToken);

            return Ok(result);
        }
    }
}
